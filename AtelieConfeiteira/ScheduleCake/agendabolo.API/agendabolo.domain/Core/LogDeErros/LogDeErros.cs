using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agendabolo.Core.LogDeErros
{
    public class LogDeErro
    {
        private static volatile LogDeErro _instance;
        private static object obj = new object();

        private LogDeErro()
        {
        }

        public static LogDeErro Default
        {
            get
            {
                if (_instance == null)
                {
                    lock(obj)
                    {
                        if (_instance == null)
                            _instance = new LogDeErro();
                    }                 
                }

                return _instance;
            }
        }

        public void Write(Exception ex)
        {
            //throw new NotImplementedException();
        }
    }
}
