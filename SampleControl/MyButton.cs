using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleControl
{
    public partial class MyButton : Button
    {
        private Pen _pen;
        private Color _color;
        private int _border;

        public int ButtonBorder
        {
            get { return _border; }
            set {
                _border = value;
                _pen.Width = _border;
 
            }
        }
        public Color ButtonBorderColor
        {
            get { return _color; }
            set { _color = value;
            _pen.Color = _color;
            }
        }
        public MyButton()
        {
            _pen = new Pen(_color, _border);
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            System.Drawing.Drawing2D.GraphicsPath buttonPath =new System.Drawing.Drawing2D.GraphicsPath();
            System.Drawing.Rectangle newRectangle = this.ClientRectangle;
            newRectangle.Inflate(-5, -10);
            pe.Graphics.DrawEllipse(_pen,newRectangle);
            newRectangle.Inflate(1, 1);
            buttonPath.AddEllipse(newRectangle);
            this.Region = new System.Drawing.Region(buttonPath);
            
           
        }
    }
}
