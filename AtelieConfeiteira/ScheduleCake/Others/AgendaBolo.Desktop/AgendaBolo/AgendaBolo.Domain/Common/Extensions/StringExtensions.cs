namespace AgendaBolo.Domain.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsEmpty(this string value) => string.IsNullOrEmpty(value);
        public static string Left(this string value, int length) => value.PadRight(length, ' ').Substring(0, length).Trim();
        public static string Mid(this string value, int startIndex, int length) => value.PadRight(length, ' ').Substring(startIndex, length).Trim();
        public static string Right(this string value, int length) => value.Mid((value.Length - length), length);
        public static string GetNumbers(this string value)
        {
            if (string.IsNullOrEmpty(value) || value.Count(char.IsDigit) == 0)
                return string.Empty;
            
            return new string(value.Where(char.IsDigit).ToArray());
        }
    }
}
