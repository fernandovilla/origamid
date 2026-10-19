using Serilog;

namespace Gestao.App.Libraries
{
    public class LoggerX(IConfigurationManager Configuration)
    {
        //private static LoggerX _log;
        //private Serilog.Core.Logger _error = null;
        //private Serilog.Core.Logger _information = null;


        //private static Serilog.Core.Logger GetError => _error ??= CreateError();
        //private static Serilog.Core.Logger GetInfo => _information ??= CreateInformation();


        //private static Serilog.Core.Logger CreateError()
        //{
        //    var serilogConfig = Configuration.GetSection("Serilog-Error");
        //    _log._error = new LoggerConfiguration()
        //        .ReadFrom
        //        .Configuration(serilogConfig).CreateLogger();
        //}

        //private static Serilog.Core.Logger CreateInformation()
        //{
        //    if (_log == null)
        //        _log = new Logger();

        //    var serilogConfig = Configuration.GetSection("Serilog-Info");
        //    _log._error = new LoggerConfiguration()
        //        .ReadFrom
        //        .Configuration(serilogConfig).CreateLogger();
        //}


        //public static void Error(string message, Exception? ex = null)
        //{
        //    if (ex != null)
        //        GetError.Error(ex, message);
        //    else
        //        GetError.Error(message);
        //}

        //public static void Information(string message, object[]? propertyValues = null)
        //{
        //    GetInfo.Information(message, propertyValues);
        //}
    }
}
