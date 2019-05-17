namespace AGV_serial_control
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.front = new System.Windows.Forms.Button();
            this.back = new System.Windows.Forms.Button();
            this.left = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.anticlock = new System.Windows.Forms.Button();
            this.clock = new System.Windows.Forms.Button();
            this.duration = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbSerial = new System.Windows.Forms.ComboBox();
            this.refreshSerial = new System.Windows.Forms.Button();
            this.connectSerial = new System.Windows.Forms.Button();
            this.baudRate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.speedSet = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.distance = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.vMax = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.frequency = new System.Windows.Forms.TextBox();
            this.acceleration = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.liftup = new System.Windows.Forms.Button();
            this.liftdown = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.fl_wheel_set = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.fr_wheel_set = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.bl_wheel_set = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.br_wheel_set = new System.Windows.Forms.TextBox();
            this.wheel_control_set = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.duration_for_wheel_control = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // front
            // 
            this.front.Location = new System.Drawing.Point(349, 90);
            this.front.Name = "front";
            this.front.Size = new System.Drawing.Size(93, 85);
            this.front.TabIndex = 0;
            this.front.Text = "front";
            this.front.UseVisualStyleBackColor = true;
            this.front.Click += new System.EventHandler(this.button1_Click);
            // 
            // back
            // 
            this.back.Location = new System.Drawing.Point(349, 209);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(93, 85);
            this.back.TabIndex = 1;
            this.back.Text = "back";
            this.back.UseVisualStyleBackColor = true;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // left
            // 
            this.left.Location = new System.Drawing.Point(224, 209);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(93, 85);
            this.left.TabIndex = 2;
            this.left.Text = "left";
            this.left.UseVisualStyleBackColor = true;
            this.left.Click += new System.EventHandler(this.button3_Click);
            // 
            // right
            // 
            this.right.Location = new System.Drawing.Point(480, 209);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(93, 85);
            this.right.TabIndex = 3;
            this.right.Text = "right";
            this.right.UseVisualStyleBackColor = true;
            this.right.Click += new System.EventHandler(this.right_Click);
            // 
            // anticlock
            // 
            this.anticlock.Location = new System.Drawing.Point(224, 90);
            this.anticlock.Name = "anticlock";
            this.anticlock.Size = new System.Drawing.Size(93, 85);
            this.anticlock.TabIndex = 4;
            this.anticlock.Text = "anticlock";
            this.anticlock.UseVisualStyleBackColor = true;
            this.anticlock.Click += new System.EventHandler(this.anticlock_Click);
            // 
            // clock
            // 
            this.clock.Location = new System.Drawing.Point(480, 90);
            this.clock.Name = "clock";
            this.clock.Size = new System.Drawing.Size(93, 85);
            this.clock.TabIndex = 5;
            this.clock.Text = "clock";
            this.clock.UseVisualStyleBackColor = true;
            this.clock.Click += new System.EventHandler(this.clock_Click);
            // 
            // duration
            // 
            this.duration.Location = new System.Drawing.Point(62, 178);
            this.duration.Name = "duration";
            this.duration.Size = new System.Drawing.Size(100, 25);
            this.duration.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(59, 160);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "duration(s)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "port";
            // 
            // cbSerial
            // 
            this.cbSerial.FormattingEnabled = true;
            this.cbSerial.Location = new System.Drawing.Point(62, 39);
            this.cbSerial.Name = "cbSerial";
            this.cbSerial.Size = new System.Drawing.Size(121, 23);
            this.cbSerial.TabIndex = 11;
            this.cbSerial.SelectedIndexChanged += new System.EventHandler(this.cbSerial_SelectedIndexChanged);
            // 
            // refreshSerial
            // 
            this.refreshSerial.Location = new System.Drawing.Point(189, 39);
            this.refreshSerial.Name = "refreshSerial";
            this.refreshSerial.Size = new System.Drawing.Size(75, 23);
            this.refreshSerial.TabIndex = 12;
            this.refreshSerial.Text = "refresh";
            this.refreshSerial.UseVisualStyleBackColor = true;
            this.refreshSerial.Click += new System.EventHandler(this.refreshSerial_Click);
            // 
            // connectSerial
            // 
            this.connectSerial.Location = new System.Drawing.Point(415, 38);
            this.connectSerial.Name = "connectSerial";
            this.connectSerial.Size = new System.Drawing.Size(75, 23);
            this.connectSerial.TabIndex = 13;
            this.connectSerial.Text = "connect";
            this.connectSerial.UseVisualStyleBackColor = true;
            this.connectSerial.Click += new System.EventHandler(this.connectSerial_Click);
            // 
            // baudRate
            // 
            this.baudRate.Location = new System.Drawing.Point(309, 36);
            this.baudRate.Name = "baudRate";
            this.baudRate.Size = new System.Drawing.Size(100, 25);
            this.baudRate.TabIndex = 14;
            this.baudRate.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(306, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 15;
            this.label3.Text = "baudrate";
            // 
            // speedSet
            // 
            this.speedSet.Location = new System.Drawing.Point(62, 224);
            this.speedSet.Name = "speedSet";
            this.speedSet.Size = new System.Drawing.Size(100, 25);
            this.speedSet.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "speed(m/s)";
            // 
            // distance
            // 
            this.distance.Location = new System.Drawing.Point(62, 297);
            this.distance.Name = "distance";
            this.distance.Size = new System.Drawing.Size(100, 25);
            this.distance.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(59, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 15);
            this.label5.TabIndex = 19;
            this.label5.Text = "distance(m)";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(62, 136);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(68, 19);
            this.radioButton1.TabIndex = 20;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "V * T";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(62, 255);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(36, 19);
            this.radioButton2.TabIndex = 21;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "S";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 325);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 15);
            this.label6.TabIndex = 23;
            this.label6.Text = "v_max(m/s)";
            // 
            // vMax
            // 
            this.vMax.Location = new System.Drawing.Point(62, 343);
            this.vMax.Name = "vMax";
            this.vMax.Size = new System.Drawing.Size(100, 25);
            this.vMax.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(59, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 15);
            this.label7.TabIndex = 25;
            this.label7.Text = "frequency(10~100Hz)";
            // 
            // frequency
            // 
            this.frequency.Location = new System.Drawing.Point(62, 96);
            this.frequency.Name = "frequency";
            this.frequency.Size = new System.Drawing.Size(100, 25);
            this.frequency.TabIndex = 24;
            // 
            // acceleration
            // 
            this.acceleration.Location = new System.Drawing.Point(62, 389);
            this.acceleration.Name = "acceleration";
            this.acceleration.Size = new System.Drawing.Size(100, 25);
            this.acceleration.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 371);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 15);
            this.label8.TabIndex = 27;
            this.label8.Text = "acceleration(m/s^2)";
            // 
            // liftup
            // 
            this.liftup.Location = new System.Drawing.Point(224, 325);
            this.liftup.Name = "liftup";
            this.liftup.Size = new System.Drawing.Size(153, 85);
            this.liftup.TabIndex = 28;
            this.liftup.Text = "liftup";
            this.liftup.UseVisualStyleBackColor = true;
            this.liftup.Click += new System.EventHandler(this.liftup_Click);
            // 
            // liftdown
            // 
            this.liftdown.Location = new System.Drawing.Point(415, 325);
            this.liftdown.Name = "liftdown";
            this.liftdown.Size = new System.Drawing.Size(158, 85);
            this.liftdown.TabIndex = 29;
            this.liftdown.Text = "liftdown";
            this.liftdown.UseVisualStyleBackColor = true;
            this.liftdown.Click += new System.EventHandler(this.liftdown_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(607, 90);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(132, 19);
            this.radioButton3.TabIndex = 30;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "wheel_control";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // fl_wheel_set
            // 
            this.fl_wheel_set.Location = new System.Drawing.Point(607, 132);
            this.fl_wheel_set.Name = "fl_wheel_set";
            this.fl_wheel_set.Size = new System.Drawing.Size(100, 25);
            this.fl_wheel_set.TabIndex = 31;
            this.fl_wheel_set.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(604, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(23, 15);
            this.label9.TabIndex = 32;
            this.label9.Text = "fl";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(604, 160);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(23, 15);
            this.label10.TabIndex = 34;
            this.label10.Text = "fr";
            // 
            // fr_wheel_set
            // 
            this.fr_wheel_set.Location = new System.Drawing.Point(607, 178);
            this.fr_wheel_set.Name = "fr_wheel_set";
            this.fr_wheel_set.Size = new System.Drawing.Size(100, 25);
            this.fr_wheel_set.TabIndex = 33;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(604, 205);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 15);
            this.label11.TabIndex = 36;
            this.label11.Text = "bl";
            // 
            // bl_wheel_set
            // 
            this.bl_wheel_set.Location = new System.Drawing.Point(607, 223);
            this.bl_wheel_set.Name = "bl_wheel_set";
            this.bl_wheel_set.Size = new System.Drawing.Size(100, 25);
            this.bl_wheel_set.TabIndex = 35;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(604, 251);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 15);
            this.label12.TabIndex = 38;
            this.label12.Text = "br";
            // 
            // br_wheel_set
            // 
            this.br_wheel_set.Location = new System.Drawing.Point(607, 269);
            this.br_wheel_set.Name = "br_wheel_set";
            this.br_wheel_set.Size = new System.Drawing.Size(100, 25);
            this.br_wheel_set.TabIndex = 37;
            // 
            // wheel_control_set
            // 
            this.wheel_control_set.Location = new System.Drawing.Point(607, 357);
            this.wheel_control_set.Name = "wheel_control_set";
            this.wheel_control_set.Size = new System.Drawing.Size(100, 53);
            this.wheel_control_set.TabIndex = 39;
            this.wheel_control_set.Text = "SET";
            this.wheel_control_set.UseVisualStyleBackColor = true;
            this.wheel_control_set.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(604, 304);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(95, 15);
            this.label13.TabIndex = 41;
            this.label13.Text = "duration(s)";
            // 
            // duration_for_wheel_control
            // 
            this.duration_for_wheel_control.Location = new System.Drawing.Point(607, 322);
            this.duration_for_wheel_control.Name = "duration_for_wheel_control";
            this.duration_for_wheel_control.Size = new System.Drawing.Size(100, 25);
            this.duration_for_wheel_control.TabIndex = 40;
            this.duration_for_wheel_control.TextChanged += new System.EventHandler(this.duration_for_wheel_control_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 464);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.duration_for_wheel_control);
            this.Controls.Add(this.wheel_control_set);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.br_wheel_set);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.bl_wheel_set);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.fr_wheel_set);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.fl_wheel_set);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.liftdown);
            this.Controls.Add(this.liftup);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.acceleration);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.frequency);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.vMax);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.distance);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.speedSet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.baudRate);
            this.Controls.Add(this.connectSerial);
            this.Controls.Add(this.refreshSerial);
            this.Controls.Add(this.cbSerial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.duration);
            this.Controls.Add(this.clock);
            this.Controls.Add(this.anticlock);
            this.Controls.Add(this.right);
            this.Controls.Add(this.left);
            this.Controls.Add(this.back);
            this.Controls.Add(this.front);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button front;
        private System.Windows.Forms.Button back;
        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Button anticlock;
        private System.Windows.Forms.Button clock;
        private System.Windows.Forms.TextBox duration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbSerial;
        private System.Windows.Forms.Button refreshSerial;
        private System.Windows.Forms.Button connectSerial;
        private System.Windows.Forms.TextBox baudRate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox speedSet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox distance;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox vMax;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox frequency;
        private System.Windows.Forms.TextBox acceleration;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button liftup;
        private System.Windows.Forms.Button liftdown;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.TextBox fl_wheel_set;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox fr_wheel_set;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox bl_wheel_set;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox br_wheel_set;
        private System.Windows.Forms.Button wheel_control_set;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox duration_for_wheel_control;
    }
}

