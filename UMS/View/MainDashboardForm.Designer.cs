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
            this.profilepictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.logoutbtn = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.studentbtn = new System.Windows.Forms.Button();
            this.coursebtn = new System.Windows.Forms.Button();
            this.userbtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilepictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
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
            // profilepictureBox
            // 
            this.profilepictureBox.Location = new System.Drawing.Point(1333, 3);
            this.profilepictureBox.Name = "profilepictureBox";
            this.profilepictureBox.Size = new System.Drawing.Size(166, 155);
            this.profilepictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.profilepictureBox.TabIndex = 22;
            this.profilepictureBox.TabStop = false;
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.panel2.Controls.Add(this.logoutbtn);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.studentbtn);
            this.panel2.Controls.Add(this.coursebtn);
            this.panel2.Controls.Add(this.userbtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 193);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(286, 860);
            this.panel2.TabIndex = 1;
            // 
            // logoutbtn
            // 
            this.logoutbtn.Location = new System.Drawing.Point(12, 494);
            this.logoutbtn.Name = "logoutbtn";
            this.logoutbtn.Size = new System.Drawing.Size(268, 52);
            this.logoutbtn.TabIndex = 5;
            this.logoutbtn.Text = "Logout";
            this.logoutbtn.UseVisualStyleBackColor = true;
            this.logoutbtn.Click += new System.EventHandler(this.logoutbtn_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(12, 418);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(268, 52);
            this.button6.TabIndex = 2;
            this.button6.Text = "Setting";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(12, 339);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(268, 52);
            this.button5.TabIndex = 4;
            this.button5.Text = "Rooms";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 258);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(268, 52);
            this.button4.TabIndex = 3;
            this.button4.Text = "Exams & Marks";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // studentbtn
            // 
            this.studentbtn.Location = new System.Drawing.Point(12, 179);
            this.studentbtn.Name = "studentbtn";
            this.studentbtn.Size = new System.Drawing.Size(268, 52);
            this.studentbtn.TabIndex = 2;
            this.studentbtn.Text = "Student";
            this.studentbtn.UseVisualStyleBackColor = true;
            // 
            // coursebtn
            // 
            this.coursebtn.Location = new System.Drawing.Point(12, 104);
            this.coursebtn.Name = "coursebtn";
            this.coursebtn.Size = new System.Drawing.Size(268, 52);
            this.coursebtn.TabIndex = 1;
            this.coursebtn.Text = "Course & Subject";
            this.coursebtn.UseVisualStyleBackColor = true;
            // 
            // userbtn
            // 
            this.userbtn.Location = new System.Drawing.Point(12, 27);
            this.userbtn.Name = "userbtn";
            this.userbtn.Size = new System.Drawing.Size(268, 52);
            this.userbtn.TabIndex = 0;
            this.userbtn.Text = "User";
            this.userbtn.UseVisualStyleBackColor = true;
            // 
            // MainDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1782, 1053);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainDashboardForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.profilepictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button studentbtn;
        private System.Windows.Forms.Button coursebtn;
        private System.Windows.Forms.Button userbtn;
    }
}