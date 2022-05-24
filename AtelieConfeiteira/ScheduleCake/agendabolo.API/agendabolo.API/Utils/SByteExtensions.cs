namespace Sistema.Utils
{
    public static partial class SByteExtensions
    {

        public static string ToSql(this sbyte number)
        {
            return number.ToString();
        }

        public static string ToSql(this sbyte? number)
        {
            if (number.HasValue)
            {
                return number.Value.ToSql();
            }

            return "Null";
        }
    }
}
