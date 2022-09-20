
namespace LifePlanner
{
    partial class Feeder
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Feeder));
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.food_percentage = new System.Windows.Forms.Label();
            this.water_percentage = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.timer_btn = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.food_timer = new System.Windows.Forms.Label();
            this.water_timer = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.water = new System.Windows.Forms.PictureBox();
            this.food = new System.Windows.Forms.PictureBox();
            this.food_clock = new System.Windows.Forms.Timer(this.components);
            this.water_clock = new System.Windows.Forms.Timer(this.components);
            this.chatbot_panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.water)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.food)).BeginInit();
            this.chatbot_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 15);
            this.label3.TabIndex = 32;
            this.label3.Text = "Ποσότητα φαγητού:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(450, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 15);
            this.label4.TabIndex = 33;
            this.label4.Text = "Ποσότητα νερού:";
            // 
            // food_percentage
            // 
            this.food_percentage.AutoSize = true;
            this.food_percentage.Location = new System.Drawing.Point(167, 40);
            this.food_percentage.Name = "food_percentage";
            this.food_percentage.Size = new System.Drawing.Size(32, 15);
            this.food_percentage.TabIndex = 34;
            this.food_percentage.Text = "70%";
            // 
            // water_percentage
            // 
            this.water_percentage.AutoSize = true;
            this.water_percentage.Location = new System.Drawing.Point(555, 40);
            this.water_percentage.Name = "water_percentage";
            this.water_percentage.Size = new System.Drawing.Size(32, 15);
            this.water_percentage.TabIndex = 35;
            this.water_percentage.Text = "70%";
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(48, 193);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 57);
            this.button1.TabIndex = 38;
            this.button1.Text = "Γέμισμα φαγητού";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(454, 193);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 57);
            this.button2.TabIndex = 39;
            this.button2.Text = "Γέμισμα νερού";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(136, 104);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(174, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(177, 15);
            this.label7.TabIndex = 41;
            this.label7.Text = "Ορισμός αυτόματου ταΐσματος:";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(136, 216);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 42;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(235, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 15);
            this.label8.TabIndex = 43;
            this.label8.Text = "Νερό:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(235, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 15);
            this.label9.TabIndex = 44;
            this.label9.Text = "Φαγητό:";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(264, 104);
            this.numericUpDown3.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown3.TabIndex = 46;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(264, 216);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown4.TabIndex = 47;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(133, 191);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 15);
            this.label10.TabIndex = 48;
            this.label10.Text = "Ώρες:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(133, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 15);
            this.label11.TabIndex = 49;
            this.label11.Text = "Ώρες:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(261, 77);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 15);
            this.label12.TabIndex = 50;
            this.label12.Text = "Λεπτά:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(261, 191);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 15);
            this.label13.TabIndex = 51;
            this.label13.Text = "Λεπτά:";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.timer_btn);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.numericUpDown4);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.numericUpDown2);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.numericUpDown3);
            this.panel1.Location = new System.Drawing.Point(48, 280);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 308);
            this.panel1.TabIndex = 52;
            // 
            // timer_btn
            // 
            this.timer_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.timer_btn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.timer_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.timer_btn.Location = new System.Drawing.Point(204, 246);
            this.timer_btn.Name = "timer_btn";
            this.timer_btn.Size = new System.Drawing.Size(112, 57);
            this.timer_btn.TabIndex = 53;
            this.timer_btn.Text = "Ορισμός αυτόματης ταΐστρας";
            this.timer_btn.UseVisualStyleBackColor = true;
            this.timer_btn.Click += new System.EventHandler(this.button3_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(166, 95);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(122, 15);
            this.label14.TabIndex = 54;
            this.label14.Text = "Γέμισμα φαγητού σε:";
            this.label14.Visible = false;
            // 
            // food_timer
            // 
            this.food_timer.AutoSize = true;
            this.food_timer.Location = new System.Drawing.Point(166, 133);
            this.food_timer.Name = "food_timer";
            this.food_timer.Size = new System.Drawing.Size(48, 15);
            this.food_timer.TabIndex = 55;
            this.food_timer.Text = "label15";
            this.food_timer.Visible = false;
            // 
            // water_timer
            // 
            this.water_timer.AutoSize = true;
            this.water_timer.Location = new System.Drawing.Point(341, 133);
            this.water_timer.Name = "water_timer";
            this.water_timer.Size = new System.Drawing.Size(48, 15);
            this.water_timer.TabIndex = 57;
            this.water_timer.Text = "label16";
            this.water_timer.Visible = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(341, 95);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 15);
            this.label17.TabIndex = 56;
            this.label17.Text = "Γέμισμα νερού σε:";
            this.label17.Visible = false;
            // 
            // water
            // 
            this.water.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.water.Location = new System.Drawing.Point(454, 75);
            this.water.Name = "water";
            this.water.Size = new System.Drawing.Size(112, 94);
            this.water.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.water.TabIndex = 37;
            this.water.TabStop = false;
            // 
            // food
            // 
            this.food.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.food.Location = new System.Drawing.Point(48, 75);
            this.food.Name = "food";
            this.food.Size = new System.Drawing.Size(112, 94);
            this.food.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.food.TabIndex = 36;
            this.food.TabStop = false;
            // 
            // food_clock
            // 
            this.food_clock.Interval = 1000;
            this.food_clock.Tick += new System.EventHandler(this.food_clock_Tick);
            // 
            // water_clock
            // 
            this.water_clock.Interval = 1000;
            this.water_clock.Tick += new System.EventHandler(this.water_clock_Tick);
            // 
            // chatbot_panel
            // 
            this.chatbot_panel.BackColor = System.Drawing.Color.LightCyan;
            this.chatbot_panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatbot_panel.Controls.Add(this.label1);
            this.chatbot_panel.Controls.Add(this.label2);
            this.chatbot_panel.Controls.Add(this.pictureBox8);
            this.chatbot_panel.Controls.Add(this.pictureBox6);
            this.chatbot_panel.Controls.Add(this.pictureBox7);
            this.chatbot_panel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chatbot_panel.Location = new System.Drawing.Point(86, 255);
            this.chatbot_panel.Margin = new System.Windows.Forms.Padding(2);
            this.chatbot_panel.Name = "chatbot_panel";
            this.chatbot_panel.Size = new System.Drawing.Size(527, 351);
            this.chatbot_panel.TabIndex = 64;
            this.chatbot_panel.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label1.Location = new System.Drawing.Point(62, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(247, 112);
            this.label1.TabIndex = 11;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.label2.Location = new System.Drawing.Point(52, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 16);
            this.label2.TabIndex = 3;
            // 
            // pictureBox8
            // 
            this.pictureBox8.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox8.Image = global::LifePlanner.Resource1.speech_bubble;
            this.pictureBox8.Location = new System.Drawing.Point(2, -1);
            this.pictureBox8.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(368, 264);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 10;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox6.Image = global::LifePlanner.Resource1.logo_ali;
            this.pictureBox6.Location = new System.Drawing.Point(325, 284);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox6.TabIndex = 8;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox7.Image = global::LifePlanner.Resource1.chatbot;
            this.pictureBox7.Location = new System.Drawing.Point(361, 206);
            this.pictureBox7.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(151, 144);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 0;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.label1_Click);
            // 
            // Feeder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(613, 605);
            this.Controls.Add(this.chatbot_panel);
            this.Controls.Add(this.water_timer);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.food_timer);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.water);
            this.Controls.Add(this.food);
            this.Controls.Add(this.water_percentage);
            this.Controls.Add(this.food_percentage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Feeder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Feeder";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Feeder_FormClosing);
            this.Load += new System.EventHandler(this.Feeder_Load);
            this.Shown += new System.EventHandler(this.Feeder_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.water)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.food)).EndInit();
            this.chatbot_panel.ResumeLayout(false);
            this.chatbot_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label food_percentage;
        private System.Windows.Forms.Label water_percentage;
        private System.Windows.Forms.PictureBox food;
        private System.Windows.Forms.PictureBox water;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button timer_btn;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label food_timer;
        private System.Windows.Forms.Label water_timer;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.Timer food_clock;
        public System.Windows.Forms.Timer water_clock;
        private System.Windows.Forms.Panel chatbot_panel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
    }
}