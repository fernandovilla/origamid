using System.Runtime.InteropServices;

namespace Agendabolo.Utils
{
    public static partial class CharExtensions
    {
        public static string ToSql(this char c)
        {
            return $"'{c}'";
        }

        public static string ToSql(this char? c)
        {
            if (c.HasValue)
            {
                return c.Value.ToSql();
            }

            return "Null";
        }
    }
}
