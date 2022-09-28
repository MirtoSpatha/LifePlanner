namespace LifePlanner
{
    partial class Options
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options));
            this.chatbot_panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.home_pictureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.calendar_pictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chatbot_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.home_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.calendar_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // chatbot_panel
            // 
            this.chatbot_panel.Controls.Add(this.label1);
            this.chatbot_panel.Controls.Add(this.pictureBox3);
            this.chatbot_panel.Controls.Add(this.pictureBox1);
            this.chatbot_panel.Controls.Add(this.pictureBox2);
            this.chatbot_panel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chatbot_panel.Location = new System.Drawing.Point(211, 182);
            this.chatbot_panel.Margin = new System.Windows.Forms.Padding(2);
            this.chatbot_panel.Name = "chatbot_panel";
            this.chatbot_panel.Size = new System.Drawing.Size(462, 243);
            this.chatbot_panel.TabIndex = 5;
            this.chatbot_panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chatbot_panel_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.Location = new System.Drawing.Point(62, 27);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Διάλεξε τι θες να κάνεις πρώτα!\r\n\r\n";
            this.label1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chatbot_panel_MouseClick);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox3.Image = global::LifePlanner.Resource1.logo_ali;
            this.pictureBox3.Location = new System.Drawing.Point(272, 201);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 8;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chatbot_panel_MouseClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::LifePlanner.Resource1.chatbot;
            this.pictureBox1.Location = new System.Drawing.Point(311, 99);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(151, 144);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chatbot_panel_MouseClick);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::LifePlanner.Resource1.speech_bubble;
            this.pictureBox2.Location = new System.Drawing.Point(2, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(319, 195);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chatbot_panel_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.home_pictureBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.calendar_pictureBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 178);
            this.panel1.TabIndex = 6;
            this.panel1.Visible = false;
            // 
            // home_pictureBox
            // 
            this.home_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.home_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.home_pictureBox.Enabled = false;
            this.home_pictureBox.Image = global::LifePlanner.Resource1.building_home;
            this.home_pictureBox.Location = new System.Drawing.Point(427, 58);
            this.home_pictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.home_pictureBox.Name = "home_pictureBox";
            this.home_pictureBox.Size = new System.Drawing.Size(123, 101);
            this.home_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.home_pictureBox.TabIndex = 5;
            this.home_pictureBox.TabStop = false;
            this.home_pictureBox.Visible = false;
            this.home_pictureBox.Click += new System.EventHandler(this.home_pictureBox_Click);
            this.home_pictureBox.MouseLeave += new System.EventHandler(this.home_pictureBox_MouseLeave);
            this.home_pictureBox.MouseHover += new System.EventHandler(this.home_pictureBox_MouseHover);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label3.Location = new System.Drawing.Point(384, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(232, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Περιήγηση στο Έξυπνο Σπίτι:";
            this.label3.Visible = false;
            // 
            // calendar_pictureBox
            // 
            this.calendar_pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.calendar_pictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.calendar_pictureBox.Enabled = false;
            this.calendar_pictureBox.Image = global::LifePlanner.Resource1.calendar;
            this.calendar_pictureBox.Location = new System.Drawing.Point(58, 58);
            this.calendar_pictureBox.Margin = new System.Windows.Forms.Padding(2);
            this.calendar_pictureBox.Name = "calendar_pictureBox";
            this.calendar_pictureBox.Size = new System.Drawing.Size(123, 101);
            this.calendar_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.calendar_pictureBox.TabIndex = 3;
            this.calendar_pictureBox.TabStop = false;
            this.calendar_pictureBox.Visible = false;
            this.calendar_pictureBox.Click += new System.EventHandler(this.calendar_pictureBox_Click);
            this.calendar_pictureBox.MouseLeave += new System.EventHandler(this.home_pictureBox_MouseLeave);
            this.calendar_pictureBox.MouseHover += new System.EventHandler(this.home_pictureBox_MouseHover);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Font = new System.Drawing.Font("Bookman Old Style", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.Location = new System.Drawing.Point(14, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(286, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Δημιουργία του Ημερήσιου Πλάνου:";
            this.label2.Visible = false;
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(675, 427);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chatbot_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.chatbot_panel.ResumeLayout(false);
            this.chatbot_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.home_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.calendar_pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel chatbot_panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox calendar_pictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox home_pictureBox;
        private System.Windows.Forms.Label label3;
    }
}