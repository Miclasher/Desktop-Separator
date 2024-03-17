using Microsoft.Win32;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Desktop_Separator
{
    public partial class Form1 : Form
    {
        public string current;
        public List<string> my_profiles = new List<string>();


        KeyboardHook hook2 = new KeyboardHook();
        KeyboardHook hook1 = new KeyboardHook();
        public Form1()
        {
            hook1.KeyPressed +=
            new EventHandler<KeyPressedEventArgs>(hook_KeyPressed2);
            // register the control + F7 combination as hot key.
            hook1.RegisterHotKey(ModKeys.Control, Keys.F7);
            hook2.KeyPressed +=
            new EventHandler<KeyPressedEventArgs>(hook_KeyPressed1);
            // register the control + F6 combination as hot key.
            hook2.RegisterHotKey(ModKeys.Control, Keys.F6);

            InitializeComponent();
            LoaderOfProfiles();
        }
        void hook_KeyPressed1(object sender, KeyPressedEventArgs e)
        {
            // show the keys pressed in a label.
            button3.PerformClick();
        }
        void hook_KeyPressed2(object sender, KeyPressedEventArgs e)
        {
            // show the keys pressed in a label.
            button4.PerformClick();
        }
        public async Task LoaderOfProfiles()
        {
            current = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DesktopSeparator\profiles.json");
            if (current == "")
            {
                Profile lol = new Profile("default");
                File.WriteAllText((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DesktopSeparator\profiles.json"), "default");
                const string userRoot = @"HKEY_CURRENT_USER\Control Panel\Desktop";
                string src = Registry.GetValue(userRoot, "Wallpaper", "").ToString();
                File.Copy(src, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DesktopSeparator\default\Wallpaper.png");

            }
            string[] temp = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DesktopSeparator");
            my_profiles = new List<string>();
            foreach (string s in temp)
            {
                my_profiles.Add(s.Split(@"\").Last());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ProfileCreator().Show();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            LoaderOfProfiles();
            Profile prof = new Profile(current);
            prof.BringFilesBack();
            string temp;
            int i = my_profiles.IndexOf(current) - 1;
            if (i < 0)
            {
                i = my_profiles.Count() - 1;
            }

            temp = my_profiles[i];

            File.WriteAllText((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DesktopSeparator\profiles.json"), temp);
            prof = new Profile(temp);
            prof.SetProfile();

        }
        public async Task Next()
        {
            LoaderOfProfiles();
            Profile prof = new Profile(current);
            prof.BringFilesBack();
            string temp;
            int i = my_profiles.IndexOf(current) + 1;
            if (i >= my_profiles.Count())
            {
                i = 0;
            }
            temp = my_profiles[i];
            File.WriteAllText((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\DesktopSeparator\profiles.json"), temp);
            prof = new Profile(temp);
            prof.SetProfile();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Next();
        }

/*        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
                this.WindowState = FormWindowState.Normal;
            }

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }*/
    }

}