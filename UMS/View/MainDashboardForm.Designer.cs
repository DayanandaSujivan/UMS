namespace UMS.View
{
    partial class MainDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.profilepiclable = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mainpanel = new System.Windows.Forms.Panel();
            this.logoutbtn = new System.Windows.Forms.Button();
            this.settingbtn = new System.Windows.Forms.Button();
            this.timetablebtn = new System.Windows.Forms.Button();
            this.exambtn = new System.Windows.Forms.Button();
            this.studentbtn = new System.Windows.Forms.Button();
            this.coursebtn = new System.Windows.Forms.Button();
            this.userbtn = new System.Windows.Forms.Button();
            this.profilepictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilepictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.panel1.Controls.Add(this.profilepiclable);
            this.panel1.Controls.Add(this.profilepictureBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1782, 193);
            this.panel1.TabIndex = 0;
            // 
            // profilepiclable
            // 
            this.profilepiclable.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profilepiclable.Location = new System.Drawing.Point(1284, 161);
            this.profilepiclable.Name = "profilepiclable";
            this.profilepiclable.Size = new System.Drawing.Size(257, 32);
            this.profilepiclable.TabIndex = 23;
            this.profilepiclable.Text = "label2";
            this.profilepiclable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 34.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(32)))));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(292, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(932, 66);
            this.label1.TabIndex = 21;
            this.label1.Text = "Unicom TIC Management System";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.panel2.Controls.Add(this.logoutbtn);
            this.panel2.Controls.Add(this.settingbtn);
            this.panel2.Controls.Add(this.timetablebtn);
            this.panel2.Controls.Add(this.exambtn);
            this.panel2.Controls.Add(this.studentbtn);
            this.panel2.Controls.Add(this.coursebtn);
            this.panel2.Controls.Add(this.userbtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 193);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(286, 860);
            this.panel2.TabIndex = 1;
            // 
            // mainpanel
            // 
            this.mainpanel.BackColor = System.Drawing.Color.White;
            this.mainpanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainpanel.Location = new System.Drawing.Point(286, 193);
            this.mainpanel.Name = "mainpanel";
            this.mainpanel.Size = new System.Drawing.Size(1496, 860);
            this.mainpanel.TabIndex = 2;
            // 
            // logoutbtn
            // 
            this.logoutbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.logoutbtn.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoutbtn.ForeColor = System.Drawing.Color.Maroon;
            this.logoutbtn.Image = global::UMS.Properties.Resources.logout;
            this.logoutbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logoutbtn.Location = new System.Drawing.Point(12, 494);
            this.logoutbtn.Name = "logoutbtn";
            this.logoutbtn.Size = new System.Drawing.Size(268, 64);
            this.logoutbtn.TabIndex = 5;
            this.logoutbtn.Text = "Logout";
            this.logoutbtn.UseVisualStyleBackColor = false;
            this.logoutbtn.Click += new System.EventHandler(this.logoutbtn_Click);
            // 
            // settingbtn
            // 
            this.settingbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.settingbtn.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingbtn.ForeColor = System.Drawing.Color.Maroon;
            this.settingbtn.Image = global::UMS.Properties.Resources.setting;
            this.settingbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingbtn.Location = new System.Drawing.Point(12, 418);
            this.settingbtn.Name = "settingbtn";
            this.settingbtn.Size = new System.Drawing.Size(268, 64);
            this.settingbtn.TabIndex = 2;
            this.settingbtn.Text = "Setting";
            this.settingbtn.UseVisualStyleBackColor = false;
            this.settingbtn.Click += new System.EventHandler(this.settingbtn_Click);
            // 
            // timetablebtn
            // 
            this.timetablebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.timetablebtn.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timetablebtn.ForeColor = System.Drawing.Color.Maroon;
            this.timetablebtn.Image = global::UMS.Properties.Resources.time_table_1_;
            this.timetablebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.timetablebtn.Location = new System.Drawing.Point(12, 339);
            this.timetablebtn.Name = "timetablebtn";
            this.timetablebtn.Size = new System.Drawing.Size(268, 64);
            this.timetablebtn.TabIndex = 4;
            this.timetablebtn.Text = "Time Table";
            this.timetablebtn.UseVisualStyleBackColor = false;
            // 
            // exambtn
            // 
            this.exambtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.exambtn.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exambtn.ForeColor = System.Drawing.Color.Maroon;
            this.exambtn.Image = global::UMS.Properties.Resources.exam;
            this.exambtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.exambtn.Location = new System.Drawing.Point(12, 258);
            this.exambtn.Name = "exambtn";
            this.exambtn.Size = new System.Drawing.Size(268, 64);
            this.exambtn.TabIndex = 3;
            this.exambtn.Text = "Exams & Marks";
            this.exambtn.UseVisualStyleBackColor = false;
            this.exambtn.Click += new System.EventHandler(this.exambtn_Click);
            // 
            // studentbtn
            // 
            this.studentbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.studentbtn.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentbtn.ForeColor = System.Drawing.Color.Maroon;
            this.studentbtn.Image = global::UMS.Properties.Resources.student;
            this.studentbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.studentbtn.Location = new System.Drawing.Point(12, 179);
            this.studentbtn.Name = "studentbtn";
            this.studentbtn.Size = new System.Drawing.Size(268, 64);
            this.studentbtn.TabIndex = 2;
            this.studentbtn.Text = "Student";
            this.studentbtn.UseVisualStyleBackColor = false;
            this.studentbtn.Click += new System.EventHandler(this.studentbtn_Click);
            // 
            // coursebtn
            // 
            this.coursebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.coursebtn.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coursebtn.ForeColor = System.Drawing.Color.Maroon;
            this.coursebtn.Image = global::UMS.Properties.Resources.course;
            this.coursebtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.coursebtn.Location = new System.Drawing.Point(12, 104);
            this.coursebtn.Name = "coursebtn";
            this.coursebtn.Size = new System.Drawing.Size(268, 64);
            this.coursebtn.TabIndex = 1;
            this.coursebtn.Text = "Course & Subject";
            this.coursebtn.UseVisualStyleBackColor = false;
            this.coursebtn.Click += new System.EventHandler(this.coursebtn_Click);
            // 
            // userbtn
            // 
            this.userbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.userbtn.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userbtn.ForeColor = System.Drawing.Color.Maroon;
            this.userbtn.Image = global::UMS.Properties.Resources.user;
            this.userbtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.userbtn.Location = new System.Drawing.Point(12, 27);
            this.userbtn.Name = "userbtn";
            this.userbtn.Size = new System.Drawing.Size(268, 64);
            this.userbtn.TabIndex = 0;
            this.userbtn.Text = "User";
            this.userbtn.UseVisualStyleBackColor = false;
            this.userbtn.Click += new System.EventHandler(this.userbtn_Click);
            // 
            // profilepictureBox
            // 
            this.profilepictureBox.Location = new System.Drawing.Point(1333, 3);
            this.profilepictureBox.Name = "profilepictureBox";
            this.profilepictureBox.Size = new System.Drawing.Size(166, 155);
            this.profilepictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilepictureBox.TabIndex = 22;
            this.profilepictureBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UMS.Properties.Resources.unicom_logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 193);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // MainDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 1053);
            this.Controls.Add(this.mainpanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainDashboardForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.profilepictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox profilepictureBox;
        private System.Windows.Forms.Label profilepiclable;
        private System.Windows.Forms.Button logoutbtn;
        private System.Windows.Forms.Button settingbtn;
        private System.Windows.Forms.Button timetablebtn;
        private System.Windows.Forms.Button exambtn;
        private System.Windows.Forms.Button studentbtn;
        private System.Windows.Forms.Button coursebtn;
        private System.Windows.Forms.Button userbtn;
        private System.Windows.Forms.Panel mainpanel;
    }
}