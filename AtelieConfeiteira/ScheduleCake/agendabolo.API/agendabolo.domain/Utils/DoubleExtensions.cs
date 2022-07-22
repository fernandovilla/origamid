using System.Globalization;
using System.Runtime.InteropServices;

namespace Agendabolo.Utils
{
    public static partial class DoubleExtensions
    {
        public static string ToSql(this double number)
        {
            return number.ToString(English.Culture);
        }

        public static string ToSql(this double? number)
        {
            if (number.HasValue)
                return number.Value.ToSql();

            return "Null";
        }
    }

    public class English
    {
        public static readonly CultureInfo Culture = CultureInfo.GetCultureInfo("en-US");
    }
}