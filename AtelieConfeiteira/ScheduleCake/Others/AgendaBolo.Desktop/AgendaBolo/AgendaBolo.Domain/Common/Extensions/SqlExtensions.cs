using System.Globalization;

namespace AgendaBolo.Domain.Common.Extensions
{
    public enum SqlData
    {
        ApenasData,
        DataHora
    }

    public static class SqlExtensions
    {
        public static string ToSql(this string value)
        {
            return "'" + value + "'";
        }

        public static string ToSql(this string value, bool nullSeVazio)
        {
            if (value.IsEmpty() && nullSeVazio)
                return "null";

            return value.ToSql();
        }

        public static string ToSql(this double value)
        {
            return value.ToString("0.00", CultureInfo.InvariantCulture);
        }

        public static string ToSql(this decimal value)
        {
            return value.ToString("0.00", CultureInfo.InvariantCulture);
        }

        public static string ToSql(this int value)
        {
            return value.ToSql(false);
        }

        public static string ToSql(this int? value)
        {
            if (value == null)
                return "null";

            return ((int)value).ToSql();
        }

        public static string ToSql(this int value, bool nullSeZero)
        {
            if (value == 0 && nullSeZero)
                return "null";

            return value.ToString();
        }

        public static string ToSql(this int? value, bool nullSeZero)
        {
            if (value == null)
                return "null";

            if (value == 0 && nullSeZero)
                return "null";                

            return ((int)value).ToSql();
        }



        public static string ToSql(this DateTime value)
        {
            return value.ToSql(SqlData.DataHora);
        }

        public static string ToSql(this DateTime? value)
        {
            if (value == null)
                return "null";

            return "'" + Convert.ToDateTime(value).ToString("MM/dd/yyyy") + "'";
        }

        public static string ToSql(this DateTime value, SqlData sqlData)
        {
            if (value != default(DateTime))
            {
                if (sqlData == SqlData.ApenasData)
                {
                    return "'" + value.ToString("MM/dd/yyyy") + "'";
                }
                else
                {
                    return "'" + value.ToString("MM/dd/yyyy HH:mm:ss") + "'";
                }
            }

            return "null";
        }

        public static string ToSql(this bool value)
        {
            if (value)
                return "'1'";

            return "'0'";
        }

        public static string ToSql(this Enum value)
        {
            Type tipo = value.GetType();

            if (!tipo.IsEnum)
                throw new ArgumentException("Argumento não é um tipo Enum.");

            return ((IConvertible)value).ToInt32(CultureInfo.InvariantCulture).ToString();
        }

        public static string ChangeField(this string sql, string fieldName, string value)
        {
            return sql.Replace(fieldName, value);
        }
    }
}
