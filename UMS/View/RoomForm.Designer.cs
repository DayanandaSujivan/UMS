namespace UMS.View
{
    partial class RoomForm
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
            this.backpicturebox = new System.Windows.Forms.PictureBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.clearbtn = new System.Windows.Forms.Button();
            this.deletebtn = new System.Windows.Forms.Button();
            this.updatebtn = new System.Windows.Forms.Button();
            this.addbtn = new System.Windows.Forms.Button();
            this.roomnametxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.roomtypetxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.backpicturebox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // backpicturebox
            // 
            this.backpicturebox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.backpicturebox.Image = global::UMS.Properties.Resources.back;
            this.backpicturebox.Location = new System.Drawing.Point(83, 36);
            this.backpicturebox.Name = "backpicturebox";
            this.backpicturebox.Size = new System.Drawing.Size(76, 58);
            this.backpicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.backpicturebox.TabIndex = 50;
            this.backpicturebox.TabStop = false;
            this.backpicturebox.Click += new System.EventHandler(this.backpicturebox_Click);
            // 
            // dgv
            // 
            this.dgv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(194, 402);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(555, 207);
            this.dgv.TabIndex = 49;
            // 
            // clearbtn
            // 
            this.clearbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.clearbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.clearbtn.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearbtn.ForeColor = System.Drawing.Color.White;
            this.clearbtn.Location = new System.Drawing.Point(632, 325);
            this.clearbtn.Name = "clearbtn";
            this.clearbtn.Size = new System.Drawing.Size(130, 40);
            this.clearbtn.TabIndex = 48;
            this.clearbtn.Text = "CLEAR";
            this.clearbtn.UseVisualStyleBackColor = false;
            this.clearbtn.Click += new System.EventHandler(this.clearbtn_Click);
            // 
            // deletebtn
            // 
            this.deletebtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.deletebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.deletebtn.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deletebtn.ForeColor = System.Drawing.Color.White;
            this.deletebtn.Location = new System.Drawing.Point(480, 325);
            this.deletebtn.Name = "deletebtn";
            this.deletebtn.Size = new System.Drawing.Size(130, 40);
            this.deletebtn.TabIndex = 47;
            this.deletebtn.Text = "DELETE";
            this.deletebtn.UseVisualStyleBackColor = false;
            this.deletebtn.Click += new System.EventHandler(this.deletebtn_Click);
            // 
            // updatebtn
            // 
            this.updatebtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.updatebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.updatebtn.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updatebtn.ForeColor = System.Drawing.Color.White;
            this.updatebtn.Location = new System.Drawing.Point(322, 325);
            this.updatebtn.Name = "updatebtn";
            this.updatebtn.Size = new System.Drawing.Size(130, 40);
            this.updatebtn.TabIndex = 46;
            this.updatebtn.Text = "UPDATE";
            this.updatebtn.UseVisualStyleBackColor = false;
            this.updatebtn.Click += new System.EventHandler(this.updatebtn_Click);
            // 
            // addbtn
            // 
            this.addbtn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.addbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(103)))), ((int)(((byte)(178)))));
            this.addbtn.Font = new System.Drawing.Font("Arial Narrow", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addbtn.ForeColor = System.Drawing.Color.White;
            this.addbtn.Location = new System.Drawing.Point(168, 325);
            this.addbtn.Name = "addbtn";
            this.addbtn.Size = new System.Drawing.Size(130, 40);
            this.addbtn.TabIndex = 45;
            this.addbtn.Text = "ADD";
            this.addbtn.UseVisualStyleBackColor = false;
            this.addbtn.Click += new System.EventHandler(this.addbtn_Click);
            // 
            // roomnametxt
            // 
            this.roomnametxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.roomnametxt.Location = new System.Drawing.Point(419, 218);
            this.roomnametxt.Name = "roomnametxt";
            this.roomnametxt.Size = new System.Drawing.Size(313, 22);
            this.roomnametxt.TabIndex = 44;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(262, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 16);
            this.label3.TabIndex = 43;
            this.label3.Text = "Room Name";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(257, 142);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(125, 43);
            this.label9.TabIndex = 42;
            this.label9.Text = "Course";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::UMS.Properties.Resources.course;
            this.pictureBox1.Location = new System.Drawing.Point(142, 113);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 72);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(191, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 16);
            this.label1.TabIndex = 40;
            // 
            // roomtypetxt
            // 
            this.roomtypetxt.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.roomtypetxt.Location = new System.Drawing.Point(419, 269);
            this.roomtypetxt.Name = "roomtypetxt";
            this.roomtypetxt.Size = new System.Drawing.Size(313, 22);
            this.roomtypetxt.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 51;
            this.label2.Text = "Room Type";
            // 
            // RoomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(164)))), ((int)(((byte)(132)))));
            this.ClientSize = new System.Drawing.Size(923, 680);
            this.Controls.Add(this.roomtypetxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.backpicturebox);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.clearbtn);
            this.Controls.Add(this.deletebtn);
            this.Controls.Add(this.updatebtn);
            this.Controls.Add(this.addbtn);
            this.Controls.Add(this.roomnametxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RoomForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RoomForm";
            ((System.ComponentModel.ISupportInitialize)(this.backpicturebox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox backpicturebox;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button clearbtn;
        private System.Windows.Forms.Button deletebtn;
        private System.Windows.Forms.Button updatebtn;
        private System.Windows.Forms.Button addbtn;
        private System.Windows.Forms.TextBox roomnametxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox roomtypetxt;
        private System.Windows.Forms.Label label2;
    }
}