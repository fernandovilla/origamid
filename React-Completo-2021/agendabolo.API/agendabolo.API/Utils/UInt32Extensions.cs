using System.Runtime.InteropServices;

namespace Sistema.Utils
{
    public static partial class UInt32Extensions
    {
        public static string ToSql(this uint number)
        {
            return number.ToString();
        }

        public static string ToSql(this uint? number)
        {
            if (number.HasValue)
            {
                return number.Value.ToSql();
            }

            return "Null";
        }
    }
}
