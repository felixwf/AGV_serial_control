using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AGV_serial_control
{
    public partial class Form1 : Form
    {

        private SerialPort coom = new SerialPort();
        private StringBuilder sBuilder = new StringBuilder();
 //       private readonly double DISTANCE_LEFT_TO_RIGHT_WHEEL = 0.405;
 //       private readonly double DISTANCE_FRONT_TO_BACK_WHEEL = 1.130;
        private readonly double WHEEL_SEPARATION_WDITH = 0.2025;
        private readonly double WHEEL_SEPARATION_LENGTH = 0.565;
        private readonly double WHEEL_RADIUS = 0.0755;
        private readonly double MPS2RPM = 3162.018737;
        private Int32[] cmd_vel = new Int32[4];
        private Byte[] Speed_Arr = new Byte[22];
        private Byte[] Lifter_Arr = new Byte[6];

        private string Control_Mode = "S_Mode"; // "V_T_Mode"

        public Form1()
        {
            InitializeComponent();
        }

        private void serial_check()
        {
            // 检查是否有串口
            string[] str = SerialPort.GetPortNames();

            if (str == null)
            {
                MessageBox.Show("本机没有串口！", "Error");
                return;
            }

            //添加串口项目
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {//获取有多少个COM口
                if (!cbSerial.Items.Contains(s))
                {
                    cbSerial.Items.Add(s);
                }
            }

            //串口设置默认选择项
            cbSerial.SelectedIndex = 0;         //设置cbSerial的默认选项
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Control_Mode == "S_Mode")
            {
                S_Mode_Motion("front");  
            }
            else
            {
                speed_calculate("front");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Control_Mode == "S_Mode")
            {
                S_Mode_Motion("left");
            }
            else
            {
                speed_calculate("left");
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            if (Control_Mode == "S_Mode")
            {
                S_Mode_Motion("back");
            }
            else
            {
                speed_calculate("back");
            }
        }

        private void cbSerial_SelectedIndexChanged(object sender, EventArgs e)
        {
            coom.Close();
            this.connectSerial.BackColor = Color.Gray;
            this.connectSerial.Text = "connect";
            disable_buttons();
        }

        private void refreshSerial_Click(object sender, EventArgs e)
        {
            serial_check();
        }

        private void enable_buttons()
        {
            this.front.Enabled = true;
            this.left.Enabled = true;
            this.clock.Enabled = true;
            this.anticlock.Enabled = true;
            this.right.Enabled = true;
            this.back.Enabled = true;
            this.liftdown.Enabled = true;
            this.liftup.Enabled = true;
            this.wheel_control_set.Enabled = true;
        }

        private void disable_buttons()
        {
            this.front.Enabled = false;
            this.left.Enabled = false;
            this.clock.Enabled = false;
            this.anticlock.Enabled = false;
            this.right.Enabled = false;
            this.back.Enabled = false;
            this.liftdown.Enabled = false;
            this.liftup.Enabled = false;
            this.wheel_control_set.Enabled = false;
        }

        private void connectSerial_Click(object sender, EventArgs e)
        {

            if (coom.IsOpen)
            {
                coom.Close();
                disable_buttons();
            }
            else
            {
                coom.PortName = this.cbSerial.Text;
                coom.BaudRate = int.Parse(this.baudRate.Text);
                coom.Parity = Parity.None;
                coom.DataBits = 8;
                coom.StopBits = StopBits.One;
                Console.WriteLine(coom.BaudRate);
                try
                {
                    coom.Open();
//                    MessageBox.Show("连接成功");
                    enable_buttons();
                }
                catch(Exception ex)
                {
                    coom = new SerialPort();
                    MessageBox.Show(ex.Message);
                }
            }

            this.connectSerial.Text = coom.IsOpen ? "disconnect" : "connect";
            this.connectSerial.BackColor = coom.IsOpen ? Color.Green : Color.Gray;

            // now you can enable the send button

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            serial_check();
            this.baudRate.Text = "115200";
            this.speedSet.Text = "0.1";
            this.duration.Text = "1.0";
            this.distance.Text = "0.1";
            this.vMax.Text = "0.5";
            this.frequency.Text = "20";
            this.acceleration.Text = "0.1";
            switch (Control_Mode)
            {
                case "S_Mode":
                    this.radioButton1.Checked = false;
                    this.radioButton2.Checked = true;
                    break;
                case "V_T_Mode":
                    this.radioButton1.Checked = true;
                    this.radioButton2.Checked = false;
                    break;
                default:
                    break;
            }
        }


        private void speed_calculate(string direction)
        {
            double speed = double.Parse(this.speedSet.Text);
            double v_x, v_y, v_theta;
            double timeLimit = double.Parse(this.duration.Text);

            switch (direction)
            {
                case "front":
                    v_x = speed;
                    v_y = 0;
                    v_theta = 0;
                    break;
                case "back":
                    v_x = -speed;
                    v_y = 0;
                    v_theta = 0;
                    break;
                case "left":
                    v_x = 0;
                    v_y = speed;
                    v_theta = 0;
                    break;
                case "right":
                    v_x = 0;
                    v_y = -speed;
                    v_theta = 0;
                    break;
                case "clock":
                    v_x = 0;
                    v_y = 0;
                    v_theta = -speed;
                    break;
                case "anticlock":
                    v_x = 0;
                    v_y = 0;
                    v_theta = speed;
                    break;
                default:
                    v_x = speed;
                    v_y = 0;
                    v_theta = 0;
                    break;
            }

            double wheel_front_left = (1 / WHEEL_RADIUS) * (v_x - v_y - (WHEEL_SEPARATION_WDITH + WHEEL_SEPARATION_LENGTH) * v_theta); // rad/s
            double wheel_front_right = (1 / WHEEL_RADIUS) * (v_x + v_y + (WHEEL_SEPARATION_WDITH + WHEEL_SEPARATION_LENGTH) * v_theta);
            double wheel_rear_left = (1 / WHEEL_RADIUS) * (v_x + v_y - (WHEEL_SEPARATION_WDITH + WHEEL_SEPARATION_LENGTH) * v_theta);
            double wheel_rear_right = (1 / WHEEL_RADIUS) * (v_x - v_y + (WHEEL_SEPARATION_WDITH + WHEEL_SEPARATION_LENGTH) * v_theta);

            double temp;
            temp = wheel_front_left * MPS2RPM * WHEEL_RADIUS;
            cmd_vel[0] = (Int32) temp;

            temp = -(wheel_front_right * MPS2RPM * WHEEL_RADIUS);
            cmd_vel[1] = (Int32) temp;

            temp = wheel_rear_left * MPS2RPM * WHEEL_RADIUS;
            cmd_vel[2] = (Int32) temp;

            temp = -(wheel_rear_right * MPS2RPM * WHEEL_RADIUS);
            cmd_vel[3] = (Int32)temp;
            // ROS_INFO("cmd_vel = %d, %d, %d, %d", cmd_vel[0], cmd_vel[1], cmd_vel[2], cmd_vel[3]);

            Speed_Arr[0] = 0x55;
            Speed_Arr[1] = 0xAA;
            Speed_Arr[2] = 0x01;
            Speed_Arr[3] = (Byte)(cmd_vel[0] >> 24 & 0xff);
            Speed_Arr[4] = (Byte)(cmd_vel[0] >> 16 & 0xff);
            Speed_Arr[5] = (Byte)(cmd_vel[0] >> 8 & 0xff);
            Speed_Arr[6] = (Byte)(cmd_vel[0] & 0xff);
            Speed_Arr[7] = (Byte)(cmd_vel[1] >> 24 & 0xff);
            Speed_Arr[8] = (Byte)(cmd_vel[1] >> 16 & 0xff);
            Speed_Arr[9] = (Byte)(cmd_vel[1] >> 8 & 0xff);
            Speed_Arr[10] = (Byte)(cmd_vel[1] & 0xff);
            Speed_Arr[11] = (Byte)(cmd_vel[2] >> 24 & 0xff);
            Speed_Arr[12] = (Byte)(cmd_vel[2] >> 16 & 0xff);
            Speed_Arr[13] = (Byte)(cmd_vel[2] >> 8 & 0xff);
            Speed_Arr[14] = (Byte)(cmd_vel[2] & 0xff);
            Speed_Arr[15] = (Byte)(cmd_vel[3] >> 24 & 0xff);
            Speed_Arr[16] = (Byte)(cmd_vel[3] >> 16 & 0xff);
            Speed_Arr[17] = (Byte)(cmd_vel[3] >> 8 & 0xff);
            Speed_Arr[18] = (Byte)(cmd_vel[3] & 0xff);
            Speed_Arr[19] = (Byte)0x00;
            for (int i = 2; i < 19; i++)
                Speed_Arr[19] += Speed_Arr[i];
            Speed_Arr[20] = (Byte)0x0d;
            Speed_Arr[21] = (Byte)0x0a;


            double timeStart = DateTime.Now.ToOADate();

            double timeEnd = timeStart;
            while((timeEnd - timeStart) * 1e5 < timeLimit)
            {
                Console.WriteLine((timeEnd - timeStart) * 1e5);
                timeEnd = DateTime.Now.ToOADate();
                coom.Write(Speed_Arr, 0, 22);
                System.Threading.Thread.Sleep(50);
            }
            // send 0m/s speed
            for (int i = 3; i < 19; i++)
                Speed_Arr[i] = 0x00;
            Speed_Arr[19] = 0x01;
            coom.Write(Speed_Arr, 0, 22);

        }

        private void clock_Click(object sender, EventArgs e)
        {
            if (Control_Mode == "S_Mode")
            {
                S_Mode_Motion("clock");
            }
            else
            {
                speed_calculate("clock");
            }
        }

        private void right_Click(object sender, EventArgs e)
        {
            if (Control_Mode == "S_Mode")
            {
                S_Mode_Motion("right");
            }
            else
            {
                speed_calculate("right");
            }
        }

        private void anticlock_Click(object sender, EventArgs e)
        {
            if (Control_Mode == "S_Mode")
            {
                S_Mode_Motion("anticlock");
            }
            else
            {
                speed_calculate("anticlock");
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            change_Control_mode("V_T_Mode");
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            change_Control_mode("S_Mode");

        }

        private void change_Control_mode(string mode)
        {
            if (mode == "S_Mode")
            {
                this.speedSet.Visible = false;
                this.duration.Visible = false;
                this.distance.Visible = true;
                this.vMax.Visible = true;
                this.acceleration.Visible = true;

                this.fl_wheel_set.Visible = false;
                this.bl_wheel_set.Visible = false;
                this.fr_wheel_set.Visible = false;
                this.br_wheel_set.Visible = false;
                this.duration_for_wheel_control.Visible = false;
                Control_Mode = "S_Mode";
            }
            else if (mode == "V_T_Mode")
            {
                this.speedSet.Visible = true;
                this.duration.Visible = true;
                this.distance.Visible = false;
                this.vMax.Visible = false;
                this.acceleration.Visible = false;

                this.fl_wheel_set.Visible = false;
                this.bl_wheel_set.Visible = false;
                this.fr_wheel_set.Visible = false;
                this.br_wheel_set.Visible = false;
                this.duration_for_wheel_control.Visible = false;
                Control_Mode = "V_T_Mode";
            }
            else if (mode == "Wheel_Mode")
            {
                this.fl_wheel_set.Visible = true;
                this.bl_wheel_set.Visible = true;
                this.fr_wheel_set.Visible = true;
                this.br_wheel_set.Visible = true;
                this.duration_for_wheel_control.Visible = true;

                
                this.speedSet.Visible = false;
                this.duration.Visible = false;
                this.distance.Visible = false;
                this.vMax.Visible = false;
                this.acceleration.Visible = false;
                Control_Mode = "Wheel_Mode";
            }
        }

        private void S_Mode_Motion(string direction)
        {
            double v_max = double.Parse(this.vMax.Text);
            double a = double.Parse(this.acceleration.Text);
            //double a = 0.2; // 0.1  m/(s^2)
            double S = double.Parse(this.distance.Text);
            double v_x, v_y, v_theta, speed = 0.0, new_speed = 0.0, time_gap = 0.0;
            int timegap = 1000 / int.Parse(this.frequency.Text);
            if (timegap < 10)
            {
                timegap = 10;
            }
            else if(timegap > 100)
            {
                timegap = 100;
            }

            DateTime timeStart = DateTime.Now;
            DateTime timeEnd = DateTime.Now;
            TimeSpan span;
            double S_current = 0.0;

            if (S > v_max * v_max / a)
            {
                // 可以加速到最大速度
                v_max = double.Parse(this.vMax.Text);
            }
            else
            {
                // 无法加速到最大速度
                v_max = Math.Sqrt(S * a);
            }
            while (S_current < S && speed >=0.0)
            {
                timeStart = timeEnd;

                if ((speed < v_max) && (S_current < S - 0.5 * v_max * v_max / a))
                {
                    // 加速阶段
                    new_speed = speed + a * time_gap;
                    Console.WriteLine("++");
                }
                else if (S_current < S - 0.5 * v_max * v_max / a)
                {
                    // 匀速阶段
                    new_speed = speed;
                    Console.WriteLine("==");
                }
                else if (S_current > S - 0.5 * v_max * v_max / a)
                {
                    // 减速阶段
                    new_speed = speed - a * time_gap;
                    Console.WriteLine("--");
                }
                S_current += new_speed * time_gap + 0.5 * (new_speed - speed) * time_gap;
                speed = new_speed;


                switch (direction)
                {
                    case "front":
                        v_x = speed;
                        v_y = 0;
                        v_theta = 0;
                        break;
                    case "back":
                        v_x = -speed;
                        v_y = 0;
                        v_theta = 0;
                        break;
                    case "left":
                        v_x = 0;
                        v_y = speed;
                        v_theta = 0;
                        break;
                    case "right":
                        v_x = 0;
                        v_y = -speed;
                        v_theta = 0;
                        break;
                    case "clock":
                        v_x = 0;
                        v_y = 0;
                        v_theta = -speed;
                        break;
                    case "anticlock":
                        v_x = 0;
                        v_y = 0;
                        v_theta = speed;
                        break;
                    default:
                        v_x = speed;
                        v_y = 0;
                        v_theta = 0;
                        break;
                }

                double wheel_front_left = (1 / WHEEL_RADIUS) * (v_x - v_y - (WHEEL_SEPARATION_WDITH + WHEEL_SEPARATION_LENGTH) * v_theta); // rad/s
                double wheel_front_right = (1 / WHEEL_RADIUS) * (v_x + v_y + (WHEEL_SEPARATION_WDITH + WHEEL_SEPARATION_LENGTH) * v_theta);
                double wheel_rear_left = (1 / WHEEL_RADIUS) * (v_x + v_y - (WHEEL_SEPARATION_WDITH + WHEEL_SEPARATION_LENGTH) * v_theta);
                double wheel_rear_right = (1 / WHEEL_RADIUS) * (v_x - v_y + (WHEEL_SEPARATION_WDITH + WHEEL_SEPARATION_LENGTH) * v_theta);

                double temp;
                temp = wheel_front_left * MPS2RPM * WHEEL_RADIUS;
                cmd_vel[0] = (Int32)temp;

                temp = -(wheel_front_right * MPS2RPM * WHEEL_RADIUS);
                cmd_vel[1] = (Int32)temp;

                temp = wheel_rear_left * MPS2RPM * WHEEL_RADIUS;
                cmd_vel[2] = (Int32)temp;

                temp = -(wheel_rear_right * MPS2RPM * WHEEL_RADIUS);
                cmd_vel[3] = (Int32)temp;
                // ROS_INFO("cmd_vel = %d, %d, %d, %d", cmd_vel[0], cmd_vel[1], cmd_vel[2], cmd_vel[3]);

                // speed arr calculate
                { 
                    Speed_Arr[0] = 0x55;
                    Speed_Arr[1] = 0xAA;
                    Speed_Arr[2] = 0x01;
                    Speed_Arr[3] = (Byte)(cmd_vel[0] >> 24 & 0xff);
                    Speed_Arr[4] = (Byte)(cmd_vel[0] >> 16 & 0xff);
                    Speed_Arr[5] = (Byte)(cmd_vel[0] >> 8 & 0xff);
                    Speed_Arr[6] = (Byte)(cmd_vel[0] & 0xff);
                    Speed_Arr[7] = (Byte)(cmd_vel[1] >> 24 & 0xff);
                    Speed_Arr[8] = (Byte)(cmd_vel[1] >> 16 & 0xff);
                    Speed_Arr[9] = (Byte)(cmd_vel[1] >> 8 & 0xff);
                    Speed_Arr[10] = (Byte)(cmd_vel[1] & 0xff);
                    Speed_Arr[11] = (Byte)(cmd_vel[2] >> 24 & 0xff);
                    Speed_Arr[12] = (Byte)(cmd_vel[2] >> 16 & 0xff);
                    Speed_Arr[13] = (Byte)(cmd_vel[2] >> 8 & 0xff);
                    Speed_Arr[14] = (Byte)(cmd_vel[2] & 0xff);
                    Speed_Arr[15] = (Byte)(cmd_vel[3] >> 24 & 0xff);
                    Speed_Arr[16] = (Byte)(cmd_vel[3] >> 16 & 0xff);
                    Speed_Arr[17] = (Byte)(cmd_vel[3] >> 8 & 0xff);
                    Speed_Arr[18] = (Byte)(cmd_vel[3] & 0xff);
                    Speed_Arr[19] = (Byte)0x00;
                    for (int i = 2; i < 19; i++)
                        Speed_Arr[19] += Speed_Arr[i];
                    Speed_Arr[20] = (Byte)0x0d;
                    Speed_Arr[21] = (Byte)0x0a;
                }
                timeEnd = DateTime.Now;
                span = (TimeSpan)(timeEnd - timeStart);
                time_gap = span.Milliseconds / 1e3;
                coom.Write(Speed_Arr, 0, 22);
                Console.WriteLine("time_start = " + timeStart.Millisecond + "; time_end = " + timeEnd.Millisecond + "; time_gap = " + time_gap + "; speed = " + speed + "; S_current = " + S_current);
                System.Threading.Thread.Sleep(timegap);
            }
            // send 0m/s speed
            for (int i = 3; i < 19; i++)
                Speed_Arr[i] = 0x00;
            Speed_Arr[19] = 0x01;
            coom.Write(Speed_Arr, 0, 22);

        }

        private void liftup_Click(object sender, EventArgs e)
        {
            Lifter_Arr[0] = 0x55;
            Lifter_Arr[1] = 0xaa;
            Lifter_Arr[2] = 0x02;
            Lifter_Arr[3] = 0x11;
            Lifter_Arr[4] = 0x0d;
            Lifter_Arr[5] = 0x0a;

            coom.Write(Lifter_Arr, 0, 6);
        }

        private void liftdown_Click(object sender, EventArgs e)
        {
            Lifter_Arr[0] = 0x55;
            Lifter_Arr[1] = 0xaa;
            Lifter_Arr[2] = 0x02;
            Lifter_Arr[3] = 0x00;
            Lifter_Arr[4] = 0x0d;
            Lifter_Arr[5] = 0x0a;
            coom.Write(Lifter_Arr, 0, 6);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            change_Control_mode("Wheel_Mode");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int fl_rpm = int.Parse(this.fl_wheel_set.Text);
            int fr_rpm = int.Parse(this.fr_wheel_set.Text);
            int bl_rpm = int.Parse(this.bl_wheel_set.Text);
            int br_rpm = int.Parse(this.br_wheel_set.Text);
            double durations = double.Parse(this.duration_for_wheel_control.Text);

            cmd_vel[0] = (Int32)fl_rpm;
            cmd_vel[1] = (Int32)fr_rpm;
            cmd_vel[2] = (Int32)bl_rpm;
            cmd_vel[3] = (Int32)br_rpm;
            DateTime timeStart = DateTime.Now;
            DateTime timeEnd = DateTime.Now;
            int timegap = 50;

            while ((timeEnd - timeStart).TotalMilliseconds < durations * 1000)
            { 
                // speed arr calculate
                {
                    Speed_Arr[0] = 0x55;
                    Speed_Arr[1] = 0xAA;
                    Speed_Arr[2] = 0x01;
                    Speed_Arr[3] = (Byte)(cmd_vel[0] >> 24 & 0xff);
                    Speed_Arr[4] = (Byte)(cmd_vel[0] >> 16 & 0xff);
                    Speed_Arr[5] = (Byte)(cmd_vel[0] >> 8 & 0xff);
                    Speed_Arr[6] = (Byte)(cmd_vel[0] & 0xff);
                    Speed_Arr[7] = (Byte)(cmd_vel[1] >> 24 & 0xff);
                    Speed_Arr[8] = (Byte)(cmd_vel[1] >> 16 & 0xff);
                    Speed_Arr[9] = (Byte)(cmd_vel[1] >> 8 & 0xff);
                    Speed_Arr[10] = (Byte)(cmd_vel[1] & 0xff);
                    Speed_Arr[11] = (Byte)(cmd_vel[2] >> 24 & 0xff);
                    Speed_Arr[12] = (Byte)(cmd_vel[2] >> 16 & 0xff);
                    Speed_Arr[13] = (Byte)(cmd_vel[2] >> 8 & 0xff);
                    Speed_Arr[14] = (Byte)(cmd_vel[2] & 0xff);
                    Speed_Arr[15] = (Byte)(cmd_vel[3] >> 24 & 0xff);
                    Speed_Arr[16] = (Byte)(cmd_vel[3] >> 16 & 0xff);
                    Speed_Arr[17] = (Byte)(cmd_vel[3] >> 8 & 0xff);
                    Speed_Arr[18] = (Byte)(cmd_vel[3] & 0xff);
                    Speed_Arr[19] = (Byte)0x00;
                    for (int i = 2; i < 19; i++)
                        Speed_Arr[19] += Speed_Arr[i];
                    Speed_Arr[20] = (Byte)0x0d;
                    Speed_Arr[21] = (Byte)0x0a;
                }



                
                coom.Write(Speed_Arr, 0, 22);
                // Console.WriteLine("time_start = " + timeStart.Millisecond + "; time_end = " + timeEnd.Millisecond + "; time_gap = " + time_gap + "; speed = " + speed + "; S_current = " + S_current);
                System.Threading.Thread.Sleep(timegap);
                timeEnd = DateTime.Now;
            }
            // send 0m/s speed
            for (int i = 3; i < 19; i++)
                Speed_Arr[i] = 0x00;
            Speed_Arr[19] = 0x01;
            coom.Write(Speed_Arr, 0, 22);

        }
        private void duration_for_wheel_control_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
