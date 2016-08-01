using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace SampleControl
{
    public  class MyClock:Control
    {

        #region 系统控件初始化
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            this.ResumeLayout(false);

        } 
        #endregion

        private Graphics graphics;

        private Pen pen;

        private Color _foreColor;
        private SolidBrush _foreBrush;
        [Category("时钟颜色"),Description("时钟刻度颜色")]
        public Color ClockForeColor
        {
            get { return _foreColor; }
            set { _foreColor = value;
            _foreBrush.Color = _foreColor;
            }
        }

        private Color _secondColor;
        [Category("时钟颜色"),Description("秒针颜色")]
        public Color SecondColor
        {
            get { return _secondColor; }
            set { _secondColor = value; }
        }
        private Color _minuteColor;
        private Timer timer1;
    
        [Category("时钟颜色"),Description("分针颜色")]
        public Color MinuteColor
        {
            get { return _minuteColor; }
            set { _minuteColor = value; }
        }
        private Color _hourColor;
        [Category("时钟颜色"),Description("时针颜色")]
        public Color HourColor
        {
            get { return _hourColor; }
            set { _hourColor = value; }
        }
       

        private void InitCoordinate(Graphics g)
        {
            if (this.Width == 0 || this.Height == 0)
                return;
            g.TranslateTransform(this.Width / 2, this.Height / 2);//平移坐标原点以画时钟
            g.ScaleTransform(this.Width / 250f, this.Height / 250f);//按比例缩放时钟
        }
        /// <summary>
        /// 画时钟盘
        /// </summary>
        /// <param name="g"></param>
        private void DrawClockDots(Graphics g)
        {
            int dotSize;
            for (int i = 0; i <= 59; ++i)
            {
                if (i % 5 == 0)
                {
                    dotSize = 15;
                }
                else
                {
                    dotSize = 5;
                }
                g.FillEllipse(_foreBrush, - dotSize / 2, -100 - dotSize / 2, dotSize, dotSize);
                g.RotateTransform(6);
            }
        }

       /// <summary>
       /// 画秒针
       /// </summary>
       /// <param name="g"></param>
       /// <param name="p"></param>
        private void DrawSecondHand(Graphics g,Pen p)
        {
            GraphicsState gs = g.Save();
            g.RotateTransform(360.0F * DateTime.Now.Second / 60);
            g.DrawLine(p, 0, 0, 0, -80*ScaleHand());
            g.Restore(gs);
        }

        /// <summary>
        /// 画分针
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        private void DrawMinuteHand(Graphics g, Pen p)
        {
            GraphicsState gs = g.Save();
            g.RotateTransform((360.0F * DateTime.Now.Minute / 60+6.0F*DateTime.Now.Second/60));
            g.DrawLine(p, 0, 0, 0, -60*ScaleHand());
            g.Restore(gs);
        }
        /// <summary>
        /// 画时针
        /// </summary>
        /// <param name="g"></param>
        /// <param name="p"></param>
        private void DrawHourHand(Graphics g, Pen p)
        {
            GraphicsState gs = g.Save();
            g.RotateTransform((360.0F * (DateTime.Now.Hour%12) / 12 + 2.0F*DateTime.Now.Minute/60 + 2.0F * DateTime.Now.Second / 60));
            g.DrawLine(p, 0, 0, 0, -40*ScaleHand());
            g.Restore(gs);
        }

        private void DrawClock(Graphics g)
        {
            InitCoordinate(g);
            DrawClockDots(g);
            pen.Color = _hourColor;
            DrawHourHand(g, pen);
            pen.Color = _minuteColor;
            DrawMinuteHand(g, pen);
            pen.Color = _secondColor;
            DrawSecondHand(g, pen);

        }

        public MyClock()
        {
            this.Size = new System.Drawing.Size(300, 300);
            InitializeComponent();
            pen = new Pen(Color.Black);
            graphics = this.CreateGraphics();
            
            _foreBrush= new SolidBrush(Color.Black);

        }


        protected override void OnPaint(PaintEventArgs e)
        {
            graphics = this.CreateGraphics();
            graphics.TranslateTransform(this.Width / 2, this.Height / 2);
            DrawClock(e.Graphics);
            base.OnPaint(e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            float width = this.Width - 80 * this.Width / 250F;
            float height = this.Height - 80 * this.Height / 250F;
            graphics.FillPie(new SolidBrush(this.BackColor), -width / 2, -height / 2, width, height, 0, 360);
            pen.Color = _hourColor;
            DrawHourHand(graphics, pen);
            pen.Color = _minuteColor;
            DrawMinuteHand(graphics, pen);
            pen.Color = _secondColor;
            DrawSecondHand(graphics, pen);
        }

        private float ScaleHand()
        {
            return  (this.Width > this.Height ? this.Height : this.Width) / 250F;
        }
    }
}
