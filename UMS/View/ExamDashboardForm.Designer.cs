namespace UMS.View
{
    partial class ExamDashboardForm
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
            this.markbtn = new System.Windows.Forms.Button();
            this.exambtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // markbtn
            // 
            this.markbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.markbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.markbtn.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.markbtn.ForeColor = System.Drawing.Color.White;
            this.markbtn.Location = new System.Drawing.Point(293, 245);
            this.markbtn.Name = "markbtn";
            this.markbtn.Size = new System.Drawing.Size(214, 60);
            this.markbtn.TabIndex = 3;
            this.markbtn.Text = "Marks";
            this.markbtn.UseVisualStyleBackColor = false;
            this.markbtn.Click += new System.EventHandler(this.markbtn_Click);
            // 
            // exambtn
            // 
            this.exambtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.exambtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.exambtn.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exambtn.ForeColor = System.Drawing.Color.White;
            this.exambtn.Location = new System.Drawing.Point(293, 146);
            this.exambtn.Name = "exambtn";
            this.exambtn.Size = new System.Drawing.Size(214, 60);
            this.exambtn.TabIndex = 2;
            this.exambtn.Text = "Exam";
            this.exambtn.UseVisualStyleBackColor = false;
            this.exambtn.Click += new System.EventHandler(this.exambtn_Click);
            // 
            // ExamDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(164)))), ((int)(((byte)(132)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.markbtn);
            this.Controls.Add(this.exambtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ExamDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExamDashboardForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button markbtn;
        private System.Windows.Forms.Button exambtn;
    }
}