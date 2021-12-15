using System;
using System.IO;
using System.Reflection;

namespace Sistema.Utils
{
    public class AssemblyHelper
    {
        public static AssemblyHelper Current = new AssemblyHelper(Assembly.GetExecutingAssembly());


        private Assembly assembly;

        public string Name => this.assembly.GetName().Name;

        public string Title => ((AssemblyTitleAttribute)this.assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false)[0]).Title;

        public Version Version => this.assembly.GetName().Version;
        
        public string CodeBase => this.assembly.CodeBase;
        
        public DateTime CreationTime => File.GetCreationTime(new Uri(this.CodeBase).LocalPath);
        

        public AssemblyHelper(Assembly assembly)
        {
            this.assembly = assembly;
        }
    }
}
