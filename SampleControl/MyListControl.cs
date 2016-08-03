using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace SampleControl
{
    public class MyListControl:Control
    {
        private List<Int32> _list = new List<int>();
        private ScopeAttribute _scope = new ScopeAttribute();
        public MyListControl()
        {

        }
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]//此处会将该属性值串行到源代码中（否则默认串行在.resx资源里）
        public List<Int32> Item
        {
            get
            {
                return _list;
            }
            set
            {
                _list = value;
            }
        }
        [TypeConverter(typeof(ScopeAttributeTypeConverter))]
        //[Editor(typeof(ScopeAttributeEditor),typeof(UITypeEditor))]
        [Editor(typeof(ScopeAttributeDropdownEditor),typeof(UITypeEditor))]
        public ScopeAttribute Scope
        {
            get
            {
                return _scope;
            }
            set
            {
                _scope = value;
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.DrawRectangle(Pens.Black, new Rectangle(Point.Empty, new Size(Size.Width - 1, this.Size.Height - 1)));
            
            for(Int32 i = 0;i<_list.Count;++i)
            {
                g.DrawString(_list[i].ToString(), Font, Brushes.Black, 1, i * FontHeight);
            }
        }

    }
}
