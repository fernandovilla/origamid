using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace Agendabolo.Utils
{
    public class AppSettings
    {
        private static AppSettings _default;
        private object lockObject;

        public AppSettings()
        { }


        public static AppSettings Default
        {
            get
            {
                if (_default == null)
                {
                    _default = LoadSettings();

                }

                return _default;
            }
        }

        private  static AppSettings LoadSettings()
        {
            var jsonString = File.ReadAllText("appsettings.json");
            var json = JsonSerializer.Deserialize(jsonString, typeof(AppSettings));

            if (json != null)
                return (AppSettings)json;
            else
                return null;
        }

        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }
}
