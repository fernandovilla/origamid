using System;

namespace Agendabolo.Utils
{
    public static partial class DateTimeExtensions
    {
        private static readonly DateTime DateTimeEmpty = new DateTime();

        public static string ToDateSql(this DateTime value) =>
            DateTimeEmpty.Equals(value) ? "Null" : $"'{value:MM/dd/yyyy}'";

        public static string ToDateSql(this DateTime? value) =>
            value.HasValue ? value.Value.ToDateSql() : "Null";

        public static string ToSql(this DateTime timestamp) =>
            DateTimeEmpty.Equals(timestamp) ? "Null" : $"'{timestamp:MM/dd/yyyy HH:mm:ss}'";

        public static string ToSql(this DateTime? timestamp) =>
            timestamp.HasValue ? timestamp.Value.ToSql() : "Null";

        public static string ToTimeSql(this DateTime value) =>
            DateTimeEmpty.Equals(value) ? "Null" : $"'{value:HH:mm:ss}'";

        public static string ToTimeSql(this DateTime? value) =>
            value.HasValue ? value.Value.ToTimeSql() : "Null";
    }
}