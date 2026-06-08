namespace InstagramClone.Shared.Helper
{
    public class DateTimeHelper
    {
        public static DateTime UtcNow()
        {
            return DateTimeOffset.UtcNow.DateTime;
        }
    }
}
