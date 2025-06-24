namespace UMS.View
{
    partial class TimetableDashboardForm
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
            this.timetablebtn = new System.Windows.Forms.Button();
            this.roombtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timetablebtn
            // 
            this.timetablebtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.timetablebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.timetablebtn.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timetablebtn.ForeColor = System.Drawing.Color.White;
            this.timetablebtn.Location = new System.Drawing.Point(318, 262);
            this.timetablebtn.Name = "timetablebtn";
            this.timetablebtn.Size = new System.Drawing.Size(214, 60);
            this.timetablebtn.TabIndex = 3;
            this.timetablebtn.Text = "Time Table";
            this.timetablebtn.UseVisualStyleBackColor = false;
            this.timetablebtn.Click += new System.EventHandler(this.timetablebtn_Click);
            // 
            // roombtn
            // 
            this.roombtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.roombtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.roombtn.Font = new System.Drawing.Font("Arial Narrow", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roombtn.ForeColor = System.Drawing.Color.White;
            this.roombtn.Location = new System.Drawing.Point(318, 163);
            this.roombtn.Name = "roombtn";
            this.roombtn.Size = new System.Drawing.Size(214, 60);
            this.roombtn.TabIndex = 2;
            this.roombtn.Text = "Room";
            this.roombtn.UseVisualStyleBackColor = false;
            this.roombtn.Click += new System.EventHandler(this.roombtn_Click);
            // 
            // TimetableDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(164)))), ((int)(((byte)(132)))));
            this.ClientSize = new System.Drawing.Size(850, 484);
            this.Controls.Add(this.timetablebtn);
            this.Controls.Add(this.roombtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TimetableDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TimetableDashboardForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button timetablebtn;
        private System.Windows.Forms.Button roombtn;
    }
}