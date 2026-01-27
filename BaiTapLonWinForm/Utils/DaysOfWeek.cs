namespace BaiTapLonWinForm.Utils
{
    public class DaysOfWeek
    {
        public static DateTime GetMondayOfWeek(DateTime date)
        {
            int diff = date.DayOfWeek == System.DayOfWeek.Sunday
                ? -6
                : System.DayOfWeek.Monday - date.DayOfWeek;

            return date.Date.AddDays(diff);
        }

    }
}
