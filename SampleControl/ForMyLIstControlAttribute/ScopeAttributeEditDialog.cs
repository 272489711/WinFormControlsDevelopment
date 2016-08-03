using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace SampleControl
{
    public partial class ScopeAttributeEditDialog : Form
    {
        private ScopeAttribute _scope=null;
        public ScopeAttribute Scope
        {
            get { return _scope; }
            set { _scope = value; }
        }
        public ScopeAttributeEditDialog(ScopeAttribute scope)
        {
            _scope = scope;
            InitializeComponent();
            textBox1.Text = _scope.Min.ToString();
            textBox2.Text = _scope.Max.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _scope.Min = Convert.ToInt32 (textBox1.Text);
            _scope.Max =Convert.ToInt32( textBox2.Text);
            button2_Click(sender, e);
        }


        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Int32.Parse(textBox1.Text);

            }
            catch (FormatException)
            {
                e.Cancel = true;
                MessageBox.Show("无效的值", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Int32.Parse(textBox2.Text);
            }
            catch (FormatException)
            {
                e.Cancel = true;
                MessageBox.Show("无效的值", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }


    }

    public class ScopeAttributeEditor:UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            if(context!=null&&context.Instance!=null)
            {
                return UITypeEditorEditStyle.Modal;
            }
            return base.GetEditStyle(context);
        }

        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService editorService = null;

            if(context!=null&&context.Instance!=null&&provider!=null)
            {
                editorService = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
                if(editorService!=null)
                {
                    MyListControl control = context.Instance as MyListControl;
                    ScopeAttributeEditDialog dlg = new ScopeAttributeEditDialog(control.Scope);
                    if(dlg.ShowDialog()== DialogResult.OK)
                    {
                        value = dlg.Scope;
                        return value;
                    }
                }
            }

            return base.EditValue(context, provider, value);
        }
    }
}
