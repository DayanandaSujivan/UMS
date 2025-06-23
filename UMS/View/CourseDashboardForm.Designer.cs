namespace UMS.View
{
    partial class CourseDashboardForm
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
            this.coursebtn = new System.Windows.Forms.Button();
            this.subjectbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // coursebtn
            // 
            this.coursebtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.coursebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.coursebtn.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.coursebtn.ForeColor = System.Drawing.Color.White;
            this.coursebtn.Location = new System.Drawing.Point(317, 126);
            this.coursebtn.Name = "coursebtn";
            this.coursebtn.Size = new System.Drawing.Size(214, 60);
            this.coursebtn.TabIndex = 0;
            this.coursebtn.Text = "Course";
            this.coursebtn.UseVisualStyleBackColor = false;
            this.coursebtn.Click += new System.EventHandler(this.coursebtn_Click);
            // 
            // subjectbtn
            // 
            this.subjectbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.subjectbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.subjectbtn.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subjectbtn.ForeColor = System.Drawing.Color.White;
            this.subjectbtn.Location = new System.Drawing.Point(317, 225);
            this.subjectbtn.Name = "subjectbtn";
            this.subjectbtn.Size = new System.Drawing.Size(214, 60);
            this.subjectbtn.TabIndex = 1;
            this.subjectbtn.Text = "Subject";
            this.subjectbtn.UseVisualStyleBackColor = false;
            // 
            // CourseDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(164)))), ((int)(((byte)(132)))));
            this.ClientSize = new System.Drawing.Size(850, 484);
            this.Controls.Add(this.subjectbtn);
            this.Controls.Add(this.coursebtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CourseDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CourseDashboardForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button coursebtn;
        private System.Windows.Forms.Button subjectbtn;
    }
}