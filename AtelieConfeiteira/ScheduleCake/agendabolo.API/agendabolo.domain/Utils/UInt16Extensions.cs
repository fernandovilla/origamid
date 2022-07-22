using System.Runtime.InteropServices;

namespace Agendabolo.Utils
{
    public static partial class UInt16Extensions
    {
        public static string ToSql(this ushort number)
        {
            return number.ToString();
        }

        public static string ToSql(this ushort? number)
        {
            if (number.HasValue)
            {
                return number.Value.ToSql();
            }

            return "Null";
        }
    }
}
