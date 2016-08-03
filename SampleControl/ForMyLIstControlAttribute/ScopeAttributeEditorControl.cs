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
    public partial class ScopeAttributeEditorControl : UserControl
    {
        private ScopeAttribute _oldScope;
        private ScopeAttribute _newScope;
        private Boolean cancelling;
        public ScopeAttributeEditorControl(ScopeAttribute scope)
        {
            _oldScope = scope;
            _newScope = scope;
            InitializeComponent();
        }

        public ScopeAttribute Scope
        {
            get
            {
                return _newScope;
            }
        }

        private void MinTb_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Int32.Parse(MinTb.Text);
            }
            catch(Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show("无效的值","验证错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }


        private void MaxTb_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                Int32.Parse(MaxTb.Text);
            }catch(Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show("无效的值", "验证错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if(keyData ==Keys.Escape)
            {
                _oldScope = _newScope;
                cancelling = true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void ScopeAttributeEditorControl_Leave(object sender, EventArgs e)
        {
            if(!cancelling)
            {
                _newScope.Max = Convert.ToInt32(MaxTb.Text);
                _newScope.Min = Convert.ToInt32(MinTb.Text);    
            }
        }

        private void ScopeAttributeEditorControl_Load(object sender, EventArgs e)
        {
            MinTb.Text = _oldScope.Min.ToString();
            MaxTb.Text = _oldScope.Max.ToString();
        }



    }
}
