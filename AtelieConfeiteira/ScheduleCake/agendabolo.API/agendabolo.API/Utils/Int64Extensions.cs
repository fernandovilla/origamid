using System.Runtime.InteropServices;

namespace Sistema.Utils
{
    public static partial class Int64Extensions
    {
        public static string ToSql(this long number)
        {
            return number.ToString();
        }

        public static string ToSql(this long? number)
        {
            if (number.HasValue)
            {
                return number.Value.ToSql();
            }

            return "Null";
        }
    }
}
