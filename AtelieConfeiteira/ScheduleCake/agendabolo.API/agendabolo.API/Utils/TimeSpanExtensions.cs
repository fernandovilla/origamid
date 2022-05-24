using System;

namespace Sistema.Utils
{
    public static partial class TimeSpanExtensions
    {
        public static string ToSql(this TimeSpan timeSpan)
        {
            return $"'{timeSpan.ToString(@"hh\:mm\:ss")}'";
        }

        public static string ToSql(this TimeSpan? timeSpan)
        {
            if (timeSpan.HasValue)
            {
                return timeSpan.Value.ToSql();
            }

            return "Null";
        }
    }
}