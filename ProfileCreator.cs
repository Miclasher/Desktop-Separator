using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Separator
{
    public partial class ProfileCreator : Form
    {
        public ProfileCreator()
        {
            InitializeComponent();
        }
        public string filePath;

        private void panel1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select wallpaper";
            ofd.Filter = "Image Files(*.PNG; *.JPG;)| *.PNG; *.JPG;";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                filePath = ofd.FileName;
                label3.Text = filePath.Split(@"\").Last();

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(filePath != null & textBox1.Text != "")
            {
                Profile newProfile = new Profile(textBox1.Text);
                try
                {
                    File.Copy(filePath, newProfile.GetPath(textBox1.Text) + @"\Wallpaper.png");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Profile with this name already exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if(filePath != null & textBox1.Text == "")
            {
                MessageBox.Show("Provide profile name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Select wallpaper", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
