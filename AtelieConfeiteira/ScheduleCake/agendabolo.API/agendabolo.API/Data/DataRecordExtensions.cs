using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Data
{
    public static class DataRecordExtensions
    {
        public static string GetString(this IDataRecord record, string fieldName)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return null;
            }

            return record.GetString(ordinal);
        }

        public static string GetString(this IDataRecord record, string fieldName, string defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return record.GetString(ordinal);
        }

        public static short GetInt16(this IDataRecord record, string fieldName)
        {
            int ordinal = record.GetOrdinal(fieldName);

            return record.GetInt16(ordinal);
        }

        public static short GetInt16(this IDataRecord record, string fieldName, short defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return record.GetInt16(ordinal);
        }

        public static ushort GetUInt16(this IDataRecord record, string fieldName)
        {
            int ordinal = record.GetOrdinal(fieldName);

            return Convert.ToUInt16(record.GetValue(ordinal));
        }

        public static ushort GetUInt16(this IDataRecord record, string fieldName, ushort defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return Convert.ToUInt16(record.GetValue(ordinal));
        }

        public static int GetInt32(this IDataRecord record, string fieldName)
        {
            int ordinal = record.GetOrdinal(fieldName);

            return record.GetInt32(ordinal);
        }

        public static int GetInt32(this IDataRecord record, string fieldName, int defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return record.GetInt32(ordinal);
        }

        public static int? GetInt32(this IDataRecord record, string fieldName, int? defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return record.GetInt32(ordinal);
        }

        public static uint GetUInt32(this IDataRecord record, string fieldName)
        {
            int ordinal = record.GetOrdinal(fieldName);

            return Convert.ToUInt32(record.GetValue(ordinal));
        }

        public static uint GetUInt32(this IDataRecord record, string fieldName, uint defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return Convert.ToUInt32(record.GetValue(ordinal));
        }

        public static long GetInt64(this IDataRecord record, string fieldName)
        {
            int ordinal = record.GetOrdinal(fieldName);

            return record.GetInt64(ordinal);
        }

        public static long GetInt64(this IDataRecord record, string fieldName, long defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return record.GetInt64(ordinal);
        }

        public static long? GetInt64(this IDataRecord record, string fieldName, long? defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return record.GetInt64(ordinal);
        }

        public static ulong GetUInt64(this IDataRecord record, string fieldName)
        {
            int ordinal = record.GetOrdinal(fieldName);

            return Convert.ToUInt64(record.GetValue(ordinal));
        }

        public static ulong GetUInt64(this IDataRecord record, string fieldName, ulong defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return Convert.ToUInt64(record.GetValue(ordinal));
        }

        public static Guid GetGuid(this IDataRecord record, string fieldName)
        {
            int ordinal = record.GetOrdinal(fieldName);

            return record.GetGuid(ordinal);
        }

        public static Guid GetGuid(this IDataRecord record, string fieldName, Guid defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return record.GetGuid(ordinal);
        }

        public static bool GetBoolean(this IDataRecord record, string fieldName)
        {
            int ordinal = record.GetOrdinal(fieldName);

            return record.GetBoolean(ordinal);
        }

        public static bool GetBoolean(this IDataRecord record, string fieldName, bool defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return record.GetBoolean(ordinal);
        }

        public static DateTime GetDateTime(this IDataRecord record, string fieldName)
        {
            int ordinal = record.GetOrdinal(fieldName);

            return record.GetDateTime(ordinal);
        }

        public static DateTime GetDateTime(this IDataRecord record, string fieldName, DateTime defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return record.GetDateTime(ordinal);
        }

        public static DateTime? GetDateTime(this IDataRecord record, string fieldName, DateTime? defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return record.GetDateTime(ordinal);
        }

        public static bool IsDBNull(this IDataRecord record, string fieldName)
        {
            int ordinal = record.GetOrdinal(fieldName);

            return record.IsDBNull(ordinal);
        }

        public static byte GetByte(this IDataRecord record, string fieldName)
        {
            int ordinal = record.GetOrdinal(fieldName);

            return record.GetByte(ordinal);
        }

        public static byte GetByte(this IDataRecord record, string fieldName, byte defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return record.GetByte(ordinal);
        }

        public static byte[] GetBytes(this IDataRecord record, int column)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                byte[] buffer = new byte[8192];
                long offset = 0L;
                long count;

                do
                {
                    count = record.GetBytes(column, offset, buffer, 0, buffer.Length);
                    stream.Write(buffer, 0, (int)count);
                    offset += count;
                } while (count >= buffer.Length);

                return stream.ToArray();
            }
        }

        public static byte[] GetBytes(this IDataRecord record, string fieldName)
        {
            int ordinal = record.GetOrdinal(fieldName);

            return record.GetBytes(ordinal);
        }

        public static byte[] GetBytes(this IDataRecord record, string fieldName, byte[] defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return record.GetBytes(ordinal);
        }

        public static object GetValue(this IDataRecord record, string fieldName)
        {
            int ordinal = record.GetOrdinal(fieldName);

            return record.GetValue(ordinal);
        }

        public static object GetValue(this IDataRecord record, string fieldName, object defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return record.GetValue(ordinal);
        }

        public static float GetFloat(this IDataRecord record, string fieldName)
        {
            int ordinal = record.GetOrdinal(fieldName);

            return record.GetFloat(ordinal);
        }

        public static float GetFloat(this IDataRecord record, string fieldName, float defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return record.GetFloat(ordinal);
        }

        public static decimal GetDecimal(this IDataRecord record, string fieldName)
        {
            int ordinal = record.GetOrdinal(fieldName);

            return record.GetDecimal(ordinal);
        }

        public static decimal GetDecimal(this IDataRecord record, string fieldName, decimal defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return record.GetDecimal(ordinal);
        }

        public static double GetDouble(this IDataRecord record, string fieldName)
        {
            int ordinal = record.GetOrdinal(fieldName);

            return record.GetDouble(ordinal);
        }

        public static double GetDouble(this IDataRecord record, string fieldName, double defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return record.GetDouble(ordinal);
        }

        public static bool GetBooleanDomain(this IDataRecord record, string fieldName)
        {
            int ordinal = record.GetOrdinal(fieldName);

            return record.GetInt32(ordinal) != 0;
        }

        public static bool GetBooleanDomain(this IDataRecord record, string fieldName, bool defaultValue)
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return record.GetInt32(ordinal) != 0;
        }
                
        public static T GetEnum<T>(this IDataRecord record, int column) where T : struct
        {
            object value = record.GetValue(column);

            T result = (T)Enum.ToObject(typeof(T), value);

            return result;
        }

        public static T GetEnum<T>(this IDataRecord record, string fieldName) where T : struct
        {
            int ordinal = record.GetOrdinal(fieldName);

            return record.GetEnum<T>(ordinal);
        }

        public static T GetEnum<T>(this IDataRecord record, string fieldName, T defaultValue) where T : struct
        {
            int ordinal = record.GetOrdinal(fieldName);

            if (record.IsDBNull(ordinal))
            {
                return defaultValue;
            }

            return record.GetEnum<T>(fieldName);
        }

        //public static XmlDocument GetXmlDocument(this IDataRecord record, int column)
        //{
        //    XmlDocument xml = new XmlDocument();

        //    byte[] bytes = record.GetBytes(column);

        //    string text = Encoding.UTF8.GetString(bytes);

        //    xml.LoadXml(text);

        //    return xml;
        //}

        //public static XmlDocument GetXmlDocument(this IDataRecord record, string fieldName)
        //{
        //    int ordinal = record.GetOrdinal(fieldName);

        //    return record.GetXmlDocument(ordinal);
        //}
    }
}
