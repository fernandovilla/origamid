using System.Data;

namespace AgendaBolo.Domain.Common.Extensions
{
    public static class DatareaderExtensions
    {
        public static char GetChar(this IDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.GetChar(ordinal);
        }

        public static long GetChars(this IDataReader reader, string fieldName, long fieldoffset, char[] buffer, int bufferoffset, int length)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.GetChars(ordinal, fieldoffset, buffer, bufferoffset, length);
        }

        public static byte GetByte(this IDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.GetByte(ordinal);
        }

        public static long GetBytes(this IDataReader reader, string fieldName, long fieldoffset, byte[] buffer, int bufferoffset, int length)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.GetBytes(ordinal, fieldoffset, buffer, bufferoffset, length);
        }

        public static string GetString(this IDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);

            if (reader.GetString(ordinal) == null)
            {
                return string.Empty;
            }
            else
            {

                return reader.GetString(ordinal);
            }
        }

        public static int GetInteger(this IDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.GetInt32(ordinal);
        }

        public static uint GetUint(this IDataReader reader, string fieldname)
        {            
            var value = reader.GetInt32(fieldname);
            if (value < 0)
                return 0;

            return (uint)value;
        }

        public static Int16 GetInt16(this IDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.GetInt16(ordinal);
        }

        public static Int32 GetInt32(this IDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.GetInt32(ordinal);
        }

        public static Int64 GetInt64(this IDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.GetInt64(ordinal);
        }

        public static long GetLong(this IDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.GetInt64(ordinal);
        }

        public static float GetFloat(this IDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.GetFloat(ordinal);
        }

        public static double GetDouble(this IDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.GetDouble(ordinal);
        }

        public static decimal GetDecimal(this IDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.GetDecimal(ordinal);
        }

        public static bool GetBoolean(this IDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.GetBoolean(ordinal);
        }

        public static IDataReader GetData(this IDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.GetData(ordinal);
        }

        public static DateTime GetDateTime(this IDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.GetDateTime(ordinal);
        }

        public static Guid GetGuid(this IDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.GetGuid(ordinal);
        }

        public static object GetValue(this IDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.GetValue(fieldName);
        }

        public static object[] GetValues(this IDataReader reader, string fieldName)
        {
            int ordinal = reader.GetOrdinal(fieldName);
            return reader.GetValues(fieldName);
        }


        //public static object GetDefault(this IDataReader reader, string fieldName)
        //{
        //    int ordinal = reader.GetOrdinal(fieldName);
        //    return null;
        //}
    }

}
