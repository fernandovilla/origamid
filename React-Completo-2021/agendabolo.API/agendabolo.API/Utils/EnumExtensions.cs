using System;
using System.Collections;
using System.ComponentModel;
using System.Globalization;

namespace Sistema.Utils
{
    public static partial class EnumExtensions
    {
        private delegate string ConvertionMethod(IConvertible value);

        private static Hashtable Convertions = new Hashtable()
        {
            [TypeCode.Byte] = (ConvertionMethod)(value => value.ToByte(CultureInfo.CurrentCulture).ToSql()),
            [TypeCode.SByte] = (ConvertionMethod)(value => value.ToSByte(CultureInfo.CurrentCulture).ToSql()),
            [TypeCode.Int16] = (ConvertionMethod)(value => value.ToInt16(CultureInfo.CurrentCulture).ToSql()),
            [TypeCode.UInt16] = (ConvertionMethod)(value => value.ToUInt16(CultureInfo.CurrentCulture).ToSql()),
            [TypeCode.Int32] = (ConvertionMethod)(value => value.ToInt32(CultureInfo.CurrentCulture).ToSql()),
            [TypeCode.UInt32] = (ConvertionMethod)(value => value.ToUInt32(CultureInfo.CurrentCulture).ToSql()),
            [TypeCode.Int64] = (ConvertionMethod)(value => value.ToInt64(CultureInfo.CurrentCulture).ToSql()),
            [TypeCode.UInt64] = (ConvertionMethod)(value => value.ToUInt64(CultureInfo.CurrentCulture).ToSql()),
        };


        public static string ToSql(this Enum value)
        {
            if (value == null)
                return "Null";

            TypeCode typeCode = value.GetTypeCode();

            ConvertionMethod convertion = (ConvertionMethod)EnumExtensions.Convertions[typeCode] ?? (ConvertionMethod)(args => { throw new NotImplementedException(); });

            string result = convertion(value);

            return result;
        }

        public static string GetDescription<T>(this T source) where T : struct
        {
            var fieldInfo = source.GetType().GetField(source.ToString());
            var attributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes != null && attributes.Length > 0 ? attributes[0].Description : source.ToString();
        }

        public static T GetValueFromDescription<T>(this string description) where T : struct
        {
            var type = typeof(T);

            if (!type.IsEnum)
                throw new InvalidOperationException();

            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name.ToUpper() == description)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Not found.", nameof(description));
        }
    }
}
