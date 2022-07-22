namespace Agendabolo.Utils
{
    public static partial class Int32Extensions
    {
        public static string ToSql(this int number)
        {
            return number.ToString();
        }

        public static string ToSql(this int? number)
        {
            if (number.HasValue)
            {
                return number.Value.ToSql();
            }

            return "Null";
        }
    }
}
