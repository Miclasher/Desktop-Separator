using Desktop_Separator;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Desktop_Separator
{

    internal static class Program
    {

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>


        [STAThread]
        public static void Main()

        {
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DesktopSeparator\profiles.json") == false)
                try
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DesktopSeparator");
                    using (FileStream fs = File.Create(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DesktopSeparator\profiles.json")) ;
                }
                catch { }
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}




