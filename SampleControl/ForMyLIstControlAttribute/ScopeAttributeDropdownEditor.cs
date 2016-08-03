using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Design;

namespace SampleControl
{
    public class ScopeAttributeDropdownEditor:UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(System.ComponentModel.ITypeDescriptorContext context)
        {
            if(context!=null&&context.Instance!=null)
            {
                return UITypeEditorEditStyle.DropDown;
            }
            return base.GetEditStyle(context);
        }

        public override object EditValue(System.ComponentModel.ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            IWindowsFormsEditorService editorServer = null;
            if(context!=null&&context.Instance!=null&&provider!=null)
            {
                editorServer = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;
                if(editorServer!=null)
                {
                    MyListControl control = context.Instance as MyListControl;
                    ScopeAttributeEditorControl editorControl = new ScopeAttributeEditorControl(control.Scope);
                    editorServer.DropDownControl(editorControl);
                    value = editorControl.Scope;
                    return value;
                }
            }
            return base.EditValue(context, provider, value);
        }
    }
}
