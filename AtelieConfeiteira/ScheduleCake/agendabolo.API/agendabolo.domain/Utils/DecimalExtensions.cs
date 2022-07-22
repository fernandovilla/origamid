namespace Agendabolo.Utils
{
    public static partial class DecimalExtensions
    {
        public static string ToSql(this decimal number)
        {
            return ((double)number).ToSql();
        }

        public static string ToSql(this decimal? number)
        {
            if (number.HasValue)
            {
                return number.Value.ToSql();
            }

            return "Null";
        }
    }
}
