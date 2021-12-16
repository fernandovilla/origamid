using Sistema.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Models.Logs
{
    public class LogDeErros
    {
        private string _logFileName;
        private static object _locker = new object();
        private static readonly Encoding EncodingWin1252 = Encoding.GetEncoding(1252);

        public static readonly LogDeErros Default = new LogDeErros(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{AppDomain.CurrentDomain.FriendlyName}.log"));


        public void Write(Exception exception)
        {
            Write(exception, exception.Message);
        }

        public void Write(Exception exception, string message)
        {
            Write(exception, message, string.Empty);
        }

        public void Write(Exception exception, string message, string sqlCommand)
        {
            Write(exception, message, sqlCommand, string.Empty);
        }

        public void Write(Exception exception, string message, string sqlCommand, string values)
        {
            Write(_logFileName, exception, message, sqlCommand, values);
        }

        protected virtual void Write(string logFileName, Exception exception, string message, string sqlCommand, string values)
        {
            lock (_locker)
            {
                using (var stream = new StreamWriter(logFileName, true, EncodingWin1252))
                {
                    stream.WriteLine($"Origin: {AssemblyHelper.Current.Name}");
                    stream.WriteLine($"Date/Time: {DateTime.Now.ToString("0:F")}");
                    stream.WriteLine($"{message.Trim().Replace("\r\n", "\n").Replace("\n", "  ")}");

                    this.WriteStream(stream, exception, 0);

                    if (!string.IsNullOrEmpty(sqlCommand))
                    {
                        stream.WriteLine($"SQL Command: {sqlCommand.Trim().Replace("\r\n", "\n").Replace("\n", " ")}\n");
                    }

                    if (!string.IsNullOrEmpty(values))
                    {
                        stream.WriteLine($"Values: {values.Trim()}\n");
                    }

                    stream.WriteLine();
                    stream.Flush();
                }
            }
        }


        protected virtual void ReduceFileSize(string fileName)
        {
            const int maximum = 102400;

            if (File.Exists(fileName) && new FileInfo(fileName).Length > maximum)
            {
                using (var memroyStream = new MemoryStream(maximum))
                using (var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
                {
                    fileStream.Seek(-maximum, SeekOrigin.End);
                    fileStream.CopyTo(memroyStream);
                    fileStream.SetLength(maximum);
                    fileStream.Position = 0;
                    memroyStream.Position = 0;
                    memroyStream.CopyTo(fileStream);
                }
            }
        }

        private void WriteStream(StreamWriter stream, Exception exception, int tabs)
        {
            if (exception == null)
                return;

            const int identation = 3;

            string tab0 = new string(' ', tabs);
            string tab1 = new string(' ', tabs + identation);

            string message = $"{tab0}{exception.Message} [{exception.GetType().FullName}]";
            stream.WriteLine(message);

            string stackTrace =
                GetLines(exception.StackTrace ?? exception?.InnerException.StackTrace ?? "No Stack Trace")
                .Select(i => tab1 + i.Trim())
                .Aggregate((a, e) => $"{a}\r\n{e}");

            stream.WriteLine(stackTrace);

            if (exception is AggregateException aggregateException)
            {
                foreach (var ex in aggregateException.InnerExceptions)
                    WriteStream(stream, ex, tabs + identation);
            }
        }

        private IEnumerable<string> GetLines(string text)
        {
            using (StringReader reader = new StringReader(text))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }


        private LogDeErros()
        { }

        public LogDeErros(string logFileName)
        {
            _logFileName = logFileName; 
        }
    }
}
