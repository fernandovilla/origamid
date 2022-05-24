using System.Runtime.InteropServices;

namespace Sistema.Utils
{
    public static partial class UInt64Extensions
    {
        public static string ToSql(this ulong number)
        {
            return number.ToString();
        }

        public static string ToSql(this ulong? number)
        {
            if (number.HasValue)
            {
                return number.Value.ToSql();
            }

            return "Null";
        }
    }
}
