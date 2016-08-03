namespace SampleControl
{
    partial class ScopeAttributeEditorControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.MinLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MinTb = new System.Windows.Forms.TextBox();
            this.MaxTb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // MinLbl
            // 
            this.MinLbl.AutoSize = true;
            this.MinLbl.Location = new System.Drawing.Point(3, 9);
            this.MinLbl.Name = "MinLbl";
            this.MinLbl.Size = new System.Drawing.Size(23, 12);
            this.MinLbl.TabIndex = 0;
            this.MinLbl.Text = "Min";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Max";
            // 
            // MinTb
            // 
            this.MinTb.Location = new System.Drawing.Point(31, 3);
            this.MinTb.Name = "MinTb";
            this.MinTb.Size = new System.Drawing.Size(32, 21);
            this.MinTb.TabIndex = 2;
            this.MinTb.Validating += new System.ComponentModel.CancelEventHandler(this.MinTb_Validating);
            // 
            // MaxTb
            // 
            this.MaxTb.Location = new System.Drawing.Point(30, 27);
            this.MaxTb.Name = "MaxTb";
            this.MaxTb.Size = new System.Drawing.Size(33, 21);
            this.MaxTb.TabIndex = 3;
            this.MaxTb.Validating += new System.ComponentModel.CancelEventHandler(this.MaxTb_Validating);
            // 
            // ScopeAttributeEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.MaxTb);
            this.Controls.Add(this.MinTb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.MinLbl);
            this.Name = "ScopeAttributeEditorControl";
            this.Size = new System.Drawing.Size(75, 53);
            this.Load += new System.EventHandler(this.ScopeAttributeEditorControl_Load);
            this.Leave += new System.EventHandler(this.ScopeAttributeEditorControl_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label MinLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox MinTb;
        private System.Windows.Forms.TextBox MaxTb;
    }
}
