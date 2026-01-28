using System.Globalization;
using System.Text.RegularExpressions;

namespace BaiTapLonWinForm.Utils
{
    class RegexUtilities
    {
        public static string ToVietnameseDay(string day)
        {
            return day switch
            {
                "2" => "Thứ 2",
                "3" => "Thứ 3",
                "4" => "Thứ 4",
                "5" => "Thứ 5",
                "6" => "Thứ 6",
                "7" => "Thứ 7",
                "8" => "Chủ nhật",
                _ => ""
            };
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public static bool IsVaidDate(DateTime data)
        {
            var now = DateTime.Now.Year;

            if (now - data.Year > 3 && now - data.Year < 81)
                return true;

            return false;
        }

        public static bool IsValidPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^(03|05|07|08|09)\d{8}$");
        }
    }
}