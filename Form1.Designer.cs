namespace Desktop_Separator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            button1 = new Button();
            button3 = new Button();
            button4 = new Button();
            label2 = new Label();
            label1 = new Label();
            notifyIcon1 = new NotifyIcon(components);
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ControlDark;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(92, 140);
            button1.Name = "button1";
            button1.Size = new Size(154, 56);
            button1.TabIndex = 1;
            button1.Text = "Create new profile";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.ControlDark;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Location = new Point(12, 12);
            button3.Name = "button3";
            button3.Size = new Size(154, 78);
            button3.TabIndex = 3;
            button3.Text = "Previous profile";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ControlDark;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Location = new Point(172, 12);
            button4.Name = "button4";
            button4.Size = new Size(154, 78);
            button4.TabIndex = 4;
            button4.Text = "Next profile";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 93);
            label2.Name = "label2";
            label2.Size = new Size(46, 13);
            label2.TabIndex = 5;
            label2.Text = "Ctrl + F6";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(224, 93);
            label1.Name = "label1";
            label1.Size = new Size(46, 13);
            label1.TabIndex = 6;
            label1.Text = "Ctrl + F7";
            // 
            // notifyIcon1
            // 
            notifyIcon1.BalloonTipText = "This program separates your desktop";
            notifyIcon1.BalloonTipTitle = "Desktop Separator";
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "Desktop Separator";
            notifyIcon1.Visible = true;
/*            notifyIcon1.Click += notifyIcon1_Click;*/
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(342, 208);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Desktop Separator";
/*            Resize += Form1_Resize;*/
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private Button button3;
        private Button button4;
        private Label label2;
        private Label label1;
        private NotifyIcon notifyIcon1;
    }
}