using iText.IO.Font;
using iText.IO.Image;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.Text;

namespace BaiTapLonWinForm.Utils
{
    public static class PdfHelper
    {
        public static void CreateReceiptPdf(
            string filePath,
            string hocVien,
            string lop,
            decimal soTien,
            decimal daDong,
            string noiDung,
            string lichHoc,
            string khaiGiang,
            string ketThuc
        )
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            PdfWriter writer = new PdfWriter(filePath);

            try
            {
                PdfDocument pdf = new PdfDocument(writer);
                Document doc = new Document(pdf, PageSize.A5.Rotate());

                doc.SetMargins(20, 20, 20, 20);

                // ===== FONT (iText 8.x) =====
                string fontPath = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "Fonts",
                    "NotoSerif-Regular.ttf"
                );

                PdfFont font = PdfFontFactory.CreateFont(
                    fontPath,
                    PdfEncodings.IDENTITY_H,
                    PdfFontFactory.EmbeddingStrategy.FORCE_EMBEDDED
                );



                DeviceRgb green = new DeviceRgb(92, 170, 69);

                // ===== VIỀN NGOÀI =====
                Table outer = new Table(1).UseAllAvailableWidth();
                outer.SetBorder(new SolidBorder(green, 3));

                Cell container = new Cell()
                    .SetPadding(15)
                    .SetBorder(Border.NO_BORDER);

                outer.AddCell(container);

                // ===== HEADER =====
                Table header = new Table(new float[] { 3, 1 })
                    .UseAllAvailableWidth();

                header.AddCell(new Cell()
                    .Add(new Paragraph("TRUNG TÂM ANH NGỮ TRE XANH")
                        .SetFont(font).SetBold().SetFontSize(11))
                    .Add(new Paragraph("27 Đặng Thùy Trâm, P13, Bình Thạnh, TP.HCM")
                        .SetFont(font).SetFontSize(9))
                    .Add(new Paragraph("ĐT: 0901 432 439  -  Email: anhvantrexanh@gmail.com")
                        .SetFont(font).SetFontSize(9))
                    .SetBorder(Border.NO_BORDER)
                );

                // Add logo only if file exists
                string logoPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "logo.png");
                if (File.Exists(logoPath))
                {
                    iText.Layout.Element.Image logo =
                        new iText.Layout.Element.Image(
                            ImageDataFactory.Create(logoPath)
                        );

                    header.AddCell(new Cell()
                        .Add(logo)
                        .SetBorder(Border.NO_BORDER)
                    );
                }
                else
                {
                    header.AddCell(new Cell().SetBorder(Border.NO_BORDER));
                }

                container.Add(header);
                container.Add(new LineSeparator(new SolidLine(1)));

                // ===== TIÊU ĐỀ =====
                container.Add(new Paragraph("BIÊN LAI THU HỌC PHÍ")
                    .SetFont(font)
                    .SetBold()
                    .SetFontSize(15)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetMarginTop(10)
                    .SetMarginBottom(10));

                // ===== THÔNG TIN CHÍNH =====
                Table info = new Table(new float[] { 1.2f, 3, 1, 1.5f })
                    .UseAllAvailableWidth();

                info.AddCell(LabelCell("Họ và tên học viên:", font));
                info.AddCell(ValueCell(hocVien, font));
                info.AddCell(EmptyCell());
                info.AddCell(EmptyCell());

                info.AddCell(LabelCell("Lớp:", font));
                info.AddCell(ValueCell(lop, font));
                info.AddCell(EmptyCell());
                info.AddCell(EmptyCell());

                info.AddCell(LabelCell("Số tiền:", font));
                info.AddCell(ValueCell($"{soTien:N0} đ", font));
                info.AddCell(LabelCell("Đã đóng:", font));
                info.AddCell(ValueCell($"{daDong:N0} đ", font));

                Cell soTienChuCell = ValueCell("", font);
                soTienChuCell.SetProperty(Property.COLSPAN, 3);
                info.AddCell(soTienChuCell);

                container.Add(info);

                container.Add(new Paragraph("Thông tin cụ thể về lớp học:")
                    .SetFont(font).SetBold().SetFontSize(10));

                // ===== CHI TIẾT =====
                Table detail = new Table(new float[] { 1.5f, 2, 1.5f, 2 })
                    .UseAllAvailableWidth();

                detail.AddCell(LabelCell("Khai giảng:", font));
                detail.AddCell(ValueCell(khaiGiang, font));
                detail.AddCell(LabelCell("Kết thúc:", font));
                detail.AddCell(ValueCell(ketThuc, font));

                // ===== LỊCH HỌC =====
                detail.AddCell(LabelCell("Lịch học:", font));

                Cell lichHocCell = ValueCell(lichHoc, font);
                lichHocCell.SetProperty(Property.COLSPAN, 3);
                detail.AddCell(lichHocCell);

                // ===== NỘI DUNG =====
                detail.AddCell(LabelCell("Nội dung:", font));

                Cell noiDungCell = ValueCell(noiDung, font);
                noiDungCell.SetProperty(Property.COLSPAN, 3);
                detail.AddCell(noiDungCell);

                container.Add(detail);
                container.Add(new Paragraph("\n"));

                // ===== CHỮ KÝ =====
                Table sign = new Table(2).UseAllAvailableWidth();

                sign.AddCell(new Cell()
                    .Add(new Paragraph(
                        $"TP.HCM, ngày {DateTime.Now:dd} tháng {DateTime.Now:MM} năm {DateTime.Now:yyyy}")
                        .SetFont(font).SetFontSize(9))
                    .Add(new Paragraph("\nNgười thu tiền")
                        .SetFont(font).SetFontSize(10))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER));

                sign.AddCell(new Cell()
                    .Add(new Paragraph("\nNgười đóng tiền")
                        .SetFont(font).SetFontSize(10))
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER));

                container.Add(sign);

                doc.Add(outer);

                doc.Close();
            }
            catch (Exception ex)
            {
                writer?.Dispose();
                throw new Exception($"Error creating PDF: {ex.Message}", ex);
            }
        }

        // ===== HÀM PHỤ =====
        private static Cell LabelCell(string text, PdfFont font)
        {
            return new Cell()
                .Add(new Paragraph(text)
                    .SetFont(font)
                    .SetFontSize(10))
                .SetBorder(Border.NO_BORDER);
        }

        private static Cell ValueCell(string text, PdfFont font)
        {
            return new Cell()
                .Add(new Paragraph(text)
                    .SetFont(font)
                    .SetFontSize(10))
                .SetBorderBottom(new SolidBorder(1))
                .SetBorderTop(Border.NO_BORDER)
                .SetBorderLeft(Border.NO_BORDER)
                .SetBorderRight(Border.NO_BORDER);
        }

        private static Cell EmptyCell()
        {
            return new Cell().SetBorder(Border.NO_BORDER);
        }
    }
}