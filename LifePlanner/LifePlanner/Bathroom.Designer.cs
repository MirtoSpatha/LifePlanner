
namespace LifePlanner
{
    partial class Bathroom
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
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.LivingRoombtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Bedroombtn = new System.Windows.Forms.Button();
            this.Hallbtn = new System.Windows.Forms.Button();
            this.Kitchenbtn = new System.Windows.Forms.Button();
            this.Bathroombtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox10.Image = global::LifePlanner.Resource1.light;
            this.pictureBox10.Location = new System.Drawing.Point(564, 144);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(40, 45);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 24;
            this.pictureBox10.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel2.Location = new System.Drawing.Point(557, 206);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(60, 23);
            this.panel2.TabIndex = 25;
            this.panel2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panel1.Location = new System.Drawing.Point(643, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(117, 516);
            this.panel1.TabIndex = 26;
            this.panel1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightCyan;
            this.panel3.Controls.Add(this.LivingRoombtn);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.Bedroombtn);
            this.panel3.Controls.Add(this.Hallbtn);
            this.panel3.Controls.Add(this.Kitchenbtn);
            this.panel3.Controls.Add(this.Bathroombtn);
            this.panel3.Enabled = false;
            this.panel3.Location = new System.Drawing.Point(1, -1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 366);
            this.panel3.TabIndex = 28;
            this.panel3.Visible = false;
            // 
            // LivingRoombtn
            // 
            this.LivingRoombtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.LivingRoombtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.LivingRoombtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LivingRoombtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LivingRoombtn.Location = new System.Drawing.Point(-14, 310);
            this.LivingRoombtn.Name = "LivingRoombtn";
            this.LivingRoombtn.Size = new System.Drawing.Size(251, 37);
            this.LivingRoombtn.TabIndex = 12;
            this.LivingRoombtn.Text = "Σαλόνι";
            this.LivingRoombtn.UseVisualStyleBackColor = true;
            this.LivingRoombtn.Click += new System.EventHandler(this.Hallbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Lime;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-2, 1);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(26, 11, 26, 11);
            this.label1.Size = new System.Drawing.Size(223, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "Επιλέξτε δωμάτιο";
            // 
            // Bedroombtn
            // 
            this.Bedroombtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bedroombtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Bedroombtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bedroombtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bedroombtn.Location = new System.Drawing.Point(-14, 250);
            this.Bedroombtn.Name = "Bedroombtn";
            this.Bedroombtn.Size = new System.Drawing.Size(251, 36);
            this.Bedroombtn.TabIndex = 11;
            this.Bedroombtn.Text = "Υπνοδωμάτιο";
            this.Bedroombtn.UseVisualStyleBackColor = true;
            this.Bedroombtn.Click += new System.EventHandler(this.Hallbtn_Click);
            // 
            // Hallbtn
            // 
            this.Hallbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Hallbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Hallbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Hallbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Hallbtn.Location = new System.Drawing.Point(-14, 70);
            this.Hallbtn.Name = "Hallbtn";
            this.Hallbtn.Size = new System.Drawing.Size(251, 37);
            this.Hallbtn.TabIndex = 8;
            this.Hallbtn.Text = "Διάδρομος";
            this.Hallbtn.UseVisualStyleBackColor = true;
            this.Hallbtn.Click += new System.EventHandler(this.Hallbtn_Click);
            // 
            // Kitchenbtn
            // 
            this.Kitchenbtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Kitchenbtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Kitchenbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Kitchenbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Kitchenbtn.Location = new System.Drawing.Point(-14, 190);
            this.Kitchenbtn.Name = "Kitchenbtn";
            this.Kitchenbtn.Size = new System.Drawing.Size(251, 35);
            this.Kitchenbtn.TabIndex = 10;
            this.Kitchenbtn.Text = "Κουζίνα";
            this.Kitchenbtn.UseVisualStyleBackColor = true;
            this.Kitchenbtn.Click += new System.EventHandler(this.Hallbtn_Click);
            // 
            // Bathroombtn
            // 
            this.Bathroombtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Bathroombtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Bathroombtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Bathroombtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bathroombtn.Location = new System.Drawing.Point(-14, 130);
            this.Bathroombtn.Name = "Bathroombtn";
            this.Bathroombtn.Size = new System.Drawing.Size(251, 37);
            this.Bathroombtn.TabIndex = 9;
            this.Bathroombtn.Text = "Τουαλέτα";
            this.Bathroombtn.UseVisualStyleBackColor = true;
            this.Bathroombtn.Click += new System.EventHandler(this.Hallbtn_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::LifePlanner.Resource1.menu1;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(219, -1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 49);
            this.button1.TabIndex = 27;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Bathroom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.BackgroundImage = global::LifePlanner.Resource1.bathroom_Bright;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(761, 554);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox10);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Bathroom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bathroom";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Bathroom_FormClosing);
            this.Load += new System.EventHandler(this.Bathroom_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button LivingRoombtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Bedroombtn;
        private System.Windows.Forms.Button Hallbtn;
        private System.Windows.Forms.Button Kitchenbtn;
        private System.Windows.Forms.Button Bathroombtn;
        private System.Windows.Forms.Button button1;
    }
}