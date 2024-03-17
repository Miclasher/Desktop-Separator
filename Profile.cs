using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Desktop_Separator
{
    internal class Profile
    {

        public string name;
        public bool is_on = false;
        public Profile(string str_name)
        {
            is_on = false;
            name = str_name;
            DirectoryInfo dirInfo = new DirectoryInfo(GetPath(name));
            if (dirInfo.Exists == false)
            {
                Directory.CreateDirectory(GetPath(name));
                Directory.CreateDirectory(GetPath(name) + "\\Files");
            }
        }
        public void Checker()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(GetPath(name));
            if (dirInfo.Exists == false)
                Directory.CreateDirectory(GetPath(name));
            Directory.CreateDirectory(GetPath(name) + "\\Files");
        }
        public string GetPath(string str_name)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string folder = "\\DesktopSeparator\\";
            string subFolderPath = path + folder;
            string path_to_profile = subFolderPath + str_name;
            return path_to_profile;
        }
        public async Task SetWallpapers() 
        {
            string path_to_wp = GetPath(name) + "\\Wallpaper.png";
            const int SPI_SETDESKWALLPAPER = 20;
            const int SPIF_UPDATEINIFILE = 1;
            const int SPIF_SENDCHANGE = 2;
            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);
            SystemParametersInfo(SPI_SETDESKWALLPAPER, 0, path_to_wp, SPIF_UPDATEINIFILE | SPIF_SENDCHANGE);
        }
        public async Task MoveFiles()
        {
            string source = GetPath(name) + "\\Files";
            string dest = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DirectoryInfo dirInfo = new DirectoryInfo(dest);
            if (dirInfo.Exists == false)
                Directory.CreateDirectory(dest);


            DirectoryInfo dir = new DirectoryInfo(source);
            DirectoryInfo[] dirs = dir.GetDirectories();


            string[] files = Directory.GetFiles(source);
            Int32 i = dirs.Count() + files.Count();
            //   for progress bar

            foreach (string file in files)
            {

                    string name = Path.GetFileName(file);
                    string destFile = Path.Combine(dest, name);
                    // skip some file
                    if (name != "file") File.Move(file, destFile);


            }

            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(dest, subdir.Name);
                if (!Directory.Exists(temppath))

                        Directory.Move(subdir.FullName, temppath);


            }
        }

        public async Task BringFilesBack()
        {
            string dest = GetPath(name) + "\\Files";
            string source = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DirectoryInfo dirInfo = new DirectoryInfo(dest);
            if (dirInfo.Exists == false)
                Directory.CreateDirectory(dest);


            DirectoryInfo dir = new DirectoryInfo(source);
            DirectoryInfo[] dirs = dir.GetDirectories();


            string[] files = Directory.GetFiles(source);
            Int32 i = dirs.Count() + files.Count();
            //   for progress bar

            foreach (string file in files)
            {

                    string name = Path.GetFileName(file);
                    string destFile = Path.Combine(dest, name);
                    // skip some file
                    if (name != "file") File.Move(file, destFile);

            }

            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(dest, subdir.Name);
                if (!Directory.Exists(temppath))

                Directory.Move(subdir.FullName, temppath);


            }
        }
        public async Task BeforeDeleting()
        {
            string dest = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Backup";
            string source = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DirectoryInfo dirInfo = new DirectoryInfo(dest);
            if (dirInfo.Exists == false)
                Directory.CreateDirectory(dest);


            DirectoryInfo dir = new DirectoryInfo(source);
            DirectoryInfo[] dirs = dir.GetDirectories();


            string[] files = Directory.GetFiles(source);
            Int32 i = dirs.Count() + files.Count();
            //   for progress bar

            foreach (string file in files)
            {

                string name = Path.GetFileName(file);
                string destFile = Path.Combine(dest, name);
                // skip some file
                if (name != "file") File.Move(file, destFile);

            }

            foreach (DirectoryInfo subdir in dirs)
            {
                string temppath = Path.Combine(dest, subdir.Name);
                if (!Directory.Exists(temppath))

                    Directory.Move(subdir.FullName, temppath);


            }
        }

        public void SetProfile()
        {
            MoveFiles();
            SetWallpapers();
        }
    }
}
