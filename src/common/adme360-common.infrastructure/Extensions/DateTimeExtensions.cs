using System;

namespace adme360.common.infrastructure.Extensions
{
    public static class DateTimeExtensions
    {
        public static string ToUrlFriendlyDate(this DateTime dt)
        {
            return dt.ToString("yyyy-MM-dd");
        }
    }
}