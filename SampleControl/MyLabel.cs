using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleControl
{
    public partial class MyLabel : UserControl
    {
        public MouseEventHandler MouseKeyDownEx=null;
        public MouseEventHandler MouseKeyUpEx=null;
        public MouseEventHandler MouseMoveEx=null;

        private Color colFColor;
        private Color colBColor;
        [Category("时钟颜色"),Description("背景颜色")]
        public Color ClockBackColor
        {
            get {
                return colBColor;
            }
            set {
                colBColor = value;
                label1.BackColor = colBColor;
            }
        }

        [Category("时钟颜色"), Description("时钟字体颜色")]
        public Color ClockForeColor
        {
            get
            {
                return colFColor;
            }
            set
            {
                colFColor = value;
                label1.ForeColor = colFColor;
            }
        }



        public MyLabel()
        {
            InitializeComponent();
        }

        private void MyLabel_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToLongTimeString();
        }

        private void MyLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if(MouseKeyDownEx!=null)
            MouseKeyDownEx(this, e);
        }

    

        private void label1_MouseMove(object sender, MouseEventArgs e)
        {
            if(MouseMoveEx!=null)
            MouseMoveEx(this, e);
        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            if(MouseKeyUpEx!=null)
           MouseKeyUpEx(this, e);
        }
    }
}
