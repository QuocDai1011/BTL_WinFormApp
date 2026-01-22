using System;
using System.Collections.Generic;

namespace BaiTapLonWinForm.Models;

public partial class StudentFaceImage
{
    public int ImageId { get; set; }

    public int StudentId { get; set; }

    public string ImagePath { get; set; } = null!;

    public DateTime? UploadedDate { get; set; }
}
