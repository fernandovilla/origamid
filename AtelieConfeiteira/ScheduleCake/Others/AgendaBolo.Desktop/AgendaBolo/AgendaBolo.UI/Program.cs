using AgendaBolo.Domain.Model.Ingredientes;

namespace AgendaBolo.UI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {                        
            ApplicationConfiguration.Initialize();
            Application.Run(new Views.mdiPrincipal());
        }
    }
}