using System.Runtime.InteropServices;

namespace Agendabolo.Utils
{
    public static partial class Int16Extensions
    {
        public static string ToSql(this short number)
        {
            return number.ToString();
        }

        public static string ToSql(this short? number)
        {
            if (number.HasValue)
            {
                return number.Value.ToSql();
            }

            return "Null";
        }
    }
}
