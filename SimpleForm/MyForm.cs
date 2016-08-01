using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SampleControl;
using System.Threading;
namespace SimpleForm
{
    public class MyForm:Form
    {
        private FirstControl myControl;
        private FlashTrackBar myTrackBar;
        private MyLabel myLabel1;
        private MyButton myButton;
        private MyClock myClock1;
        private ThermoMeterControl thermoMeterControl1;
        private Container components = null;
        public MyForm()
        {
            InitializeComponent();
            InitializeDragEvent();
            new Thread(new ThreadStart( TestForMyBar)).Start();
        }

        public void TestForMyBar()
        {
            for (int i = 0; i <= 100; i++)
            { 
                myTrackBar.Value = i;
                thermoMeterControl1.Temperature = i;
                thermoMeterControl1.Invalidate();
                Thread.Sleep(500);
                //myTrackBar.Invalidate();
            }

            newClose();
        }

        delegate void close();
        private void newClose()
        {
            close CloseSelft = newClose;
            if (this.InvokeRequired)
            {
                this.Invoke(CloseSelft);
            }
            else
            {
                this.Close();
                this.Dispose();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        public void InitializeDragEvent()
        {

            this.myLabel1.MouseKeyDownEx +=mouseDownEvent;
            this.myLabel1.MouseMoveEx += mouseMoveEvent;
            this.myLabel1.MouseKeyUpEx += mouseUpEvent;

            this.myTrackBar.MouseDown += mouseDownEvent;
            this.myTrackBar.MouseMove += mouseMoveEvent;
            this.myTrackBar.MouseUp += mouseUpEvent;

            this.thermoMeterControl1.MouseDown += mouseDownEvent;
            this.thermoMeterControl1.MouseMove += mouseMoveEvent;
            this.thermoMeterControl1.MouseUp += mouseUpEvent;

            this.myButton.MouseDown += mouseDownEvent;
            this.myButton.MouseUp += mouseUpEvent;
            this.myButton.MouseMove += mouseMoveEvent;
        }

        public void InitializeComponent()
        {
            this.thermoMeterControl1 = new SampleControl.ThermoMeterControl();
            this.myClock1 = new SampleControl.MyClock();
            this.myLabel1 = new SampleControl.MyLabel();
            this.myControl = new SampleControl.FirstControl();
            this.myTrackBar = new SampleControl.FlashTrackBar();
            this.myButton = new SampleControl.MyButton();
            this.SuspendLayout();
            // 
            // thermoMeterControl1
            // 
            this.thermoMeterControl1.BigScale = 5;
            this.thermoMeterControl1.BigScaleColor = System.Drawing.Color.MediumBlue;
            this.thermoMeterControl1.DialBackColor = System.Drawing.Color.Gray;
            this.thermoMeterControl1.DialOutLineColor = System.Drawing.Color.Gray;
            this.thermoMeterControl1.DrawColor = System.Drawing.Color.Black;
            this.thermoMeterControl1.DrawFont = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.thermoMeterControl1.HighTemperature = 100F;
            this.thermoMeterControl1.Location = new System.Drawing.Point(205, 189);
            this.thermoMeterControl1.LowTemperature = 0F;
            this.thermoMeterControl1.MercuryBackColor = System.Drawing.Color.LightGray;
            this.thermoMeterControl1.MercuryColor = System.Drawing.Color.Red;
            this.thermoMeterControl1.Name = "thermoMeterControl1";
            this.thermoMeterControl1.Size = new System.Drawing.Size(58, 200);
            this.thermoMeterControl1.SmallScale = 5;
            this.thermoMeterControl1.SmallScaleColor = System.Drawing.Color.DarkOrange;
            this.thermoMeterControl1.TabIndex = 5;
            this.thermoMeterControl1.TempColor = System.Drawing.Color.Black;
            this.thermoMeterControl1.Temperature = 0F;
            this.thermoMeterControl1.TempFont = new System.Drawing.Font("宋体", 12F);
            // 
            // myClock1
            // 
            this.myClock1.ClockForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.myClock1.HourColor = System.Drawing.Color.Lime;
            this.myClock1.Location = new System.Drawing.Point(246, 12);
            this.myClock1.MinuteColor = System.Drawing.Color.Blue;
            this.myClock1.Name = "myClock1";
            this.myClock1.SecondColor = System.Drawing.Color.Red;
            this.myClock1.Size = new System.Drawing.Size(164, 171);
            this.myClock1.TabIndex = 4;
            this.myClock1.Text = "myClock1";
            this.myClock1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownEvent);
            this.myClock1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMoveEvent);
            this.myClock1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUpEvent);
            // 
            // myLabel1
            // 
            this.myLabel1.AutoSize = true;
            this.myLabel1.ClockBackColor = System.Drawing.Color.DarkSlateGray;
            this.myLabel1.ClockForeColor = System.Drawing.Color.LavenderBlush;
            this.myLabel1.Location = new System.Drawing.Point(27, 127);
            this.myLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.myLabel1.Name = "myLabel1";
            this.myLabel1.Size = new System.Drawing.Size(97, 20);
            this.myLabel1.TabIndex = 2;
            // 
            // myControl
            // 
            this.myControl.BackColor = System.Drawing.Color.Cornsilk;
            this.myControl.Location = new System.Drawing.Point(75, 82);
            this.myControl.Name = "myControl";
            this.myControl.Size = new System.Drawing.Size(98, 28);
            this.myControl.TabIndex = 0;
            this.myControl.Text = "Hello,I am the firstControl!";
            this.myControl.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.myControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownEvent);
            this.myControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMoveEvent);
            this.myControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUpEvent);
            // 
            // myTrackBar
            // 
            this.myTrackBar.AllowDrop = true;
            this.myTrackBar.AllowUserEdit = false;
            this.myTrackBar.BackColor = System.Drawing.Color.Black;
            this.myTrackBar.DarkenBy = ((byte)(255));
            this.myTrackBar.ForeColor = System.Drawing.Color.White;
            this.myTrackBar.Location = new System.Drawing.Point(27, 43);
            this.myTrackBar.Name = "myTrackBar";
            this.myTrackBar.ShowPercentage = true;
            this.myTrackBar.Size = new System.Drawing.Size(146, 20);
            this.myTrackBar.TabIndex = 1;
            this.myTrackBar.Text = "程序进度条";
            // 
            // myButton
            // 
            this.myButton.BackColor = System.Drawing.Color.SandyBrown;
            this.myButton.ButtonBorder = 1;
            this.myButton.ButtonBorderColor = System.Drawing.Color.Sienna;
            this.myButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.myButton.Location = new System.Drawing.Point(27, 166);
            this.myButton.Name = "myButton";
            this.myButton.Size = new System.Drawing.Size(107, 51);
            this.myButton.TabIndex = 3;
            this.myButton.Text = "I am a button";
            this.myButton.UseVisualStyleBackColor = false;
            // 
            // MyForm
            // 
            this.ClientSize = new System.Drawing.Size(448, 423);
            this.Controls.Add(this.thermoMeterControl1);
            this.Controls.Add(this.myClock1);
            this.Controls.Add(this.myLabel1);
            this.Controls.Add(this.myControl);
            this.Controls.Add(this.myTrackBar);
            this.Controls.Add(this.myButton);
            this.Location = new System.Drawing.Point(300, 100);
            this.Name = "MyForm";
            this.Text = "控件窗口";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mouseDownEvent);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mouseMoveEvent);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mouseUpEvent);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        int posX;
        int posY;
        bool flag = false;
        private void mouseDownEvent(object o,MouseEventArgs e)
        {
            flag = true;
            posX = e.X;
            posY = e.Y;
        }

        private void mouseMoveEvent(object o, MouseEventArgs e)
        {
            if (flag)
            {
                ((Control)o).Left += e.X-posX;
                ((Control)o).Top += e.Y-posY;
                Console.WriteLine("x:" + (e.X-posX) + " y:" + (e.Y-posY));
                Console.WriteLine("Now x:" + (((Control)o).Location.X) + " y:" + (((Control)o).Location.Y));
            }
        }
        private void mouseUpEvent(object o, MouseEventArgs e)
        {
            flag = false;
        }

      

        


    }
}
