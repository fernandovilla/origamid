using System;
using System.Linq;
using System.Text;

namespace Sistema.Utils
{
    public static class StringExtensions
    {
        private const string WrongChars = "'ÁÉÍÓÚÂÊÎÔÛÃÕÄËÏÖÜÀÈÌÒÙÇÝŸÑ'´`~^¨";
        private const string ValidChars = " AEIOUAEIOUAOAEIOUAEIOUCYYN      ";


        public static string ToSql(this string text)
        {
            return text == null ? "Null" : $"'{text.Replace(@"'", @"''")}'";
        }

        
        public static string Right(this string text, int length)
        {
            if (length > text.Length)
            {
                length = text.Length;
            }

            return text.Substring(text.Length - length);
        }

        public static string Left(this string text, int length)
        {
            if (length > text.Length)
            {
                length = text.Length;
            }

            return text.Substring(0, length);
        }

        public static bool Contem(this string text, params string[] values)
        {
            return values.Contains(text);
        }

        public static string ToHex(this string chars)
        {
            StringBuilder result = new StringBuilder();

            foreach (int @char in chars)
            {
                result.Append($"{@char:X2}");
            }

            return result.ToString();
        }

        public static byte[] ToByteArray(this string text)
        {
            byte[] result = Encoding.UTF8.GetBytes(text);

            return result;
        }

        public static string ToText(this string text)
        {
            StringBuilder result = new StringBuilder(text.Length);

            foreach (char c in text)
            {
                char x = char.ToUpper(c);

                int index = StringExtensions.WrongChars.IndexOf(x);

                if (index >= 0)
                {
                    x = StringExtensions.ValidChars[index];
                }

                result.Append(x);
            }

            return result.ToString();
        }

        public static string Truncate(this string text, int maxLength)
        {
            if (text == null || text.Length <= maxLength) return text;

            return text.Substring(0, maxLength);
        }
    }
}
