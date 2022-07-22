using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Agendabolo.Utils
{
    public static partial class ByteExtensions
    {
        public static string ToSql(this byte number)
        {
            return number.ToString();
        }

        public static string ToSql(this byte? number)
        {
            if (number.HasValue)
            {
                return number.Value.ToSql();
            }

            return "Null";
        }

        public static T ToStructure<T>(this byte[] bytes) where T : struct
        {
            IntPtr source = Marshal.AllocHGlobal(bytes.Length);
            Marshal.Copy(bytes, 0, source, bytes.Length);
            T structure = (T)Marshal.PtrToStructure(source, typeof(T));
            Marshal.FreeHGlobal(source);

            return structure;
        }

        public static string ToHex(this byte[] bytes)
        {
            StringBuilder result = new StringBuilder();

            foreach (byte @byte in bytes)
            {
                result.Append($"{@byte:X2}");
            }

            return result.ToString();
        }
    }
}
