namespace zhenxiuhe_1
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.ribbonControl1 = new DevComponents.DotNetBar.RibbonControl();
            this.ribbonPanel2 = new DevComponents.DotNetBar.RibbonPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkedListBox5 = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkedListBox2 = new System.Windows.Forms.CheckedListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkedListBox4 = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkedListBox3 = new System.Windows.Forms.CheckedListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.ribbonPanel3 = new DevComponents.DotNetBar.RibbonPanel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.ribbonTabItem1 = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem2 = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonTabItem_error = new DevComponents.DotNetBar.RibbonTabItem();
            this.office2007StartButton1 = new DevComponents.DotNetBar.Office2007StartButton();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.ribbonControl1.SuspendLayout();
            this.ribbonPanel2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ribbonPanel3.SuspendLayout();
            this.ribbonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "zhenxiuhe";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.CanCustomize = false;
            this.ribbonControl1.CaptionVisible = true;
            this.ribbonControl1.Controls.Add(this.ribbonPanel2);
            this.ribbonControl1.Controls.Add(this.ribbonPanel3);
            this.ribbonControl1.Controls.Add(this.ribbonPanel1);
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonControl1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ribbonTabItem1,
            this.ribbonTabItem2,
            this.ribbonTabItem_error});
            this.ribbonControl1.KeyTipsFont = new System.Drawing.Font("Tahoma", 7F);
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            this.ribbonControl1.QuickToolbarItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.office2007StartButton1,
            this.buttonItem1});
            this.ribbonControl1.Size = new System.Drawing.Size(800, 600);
            this.ribbonControl1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonControl1.TabGroupHeight = 14;
            this.ribbonControl1.TabIndex = 0;
            this.ribbonControl1.Text = "ribbonControl1";
            // 
            // ribbonPanel2
            // 
            this.ribbonPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonPanel2.Controls.Add(this.groupBox5);
            this.ribbonPanel2.Controls.Add(this.groupBox2);
            this.ribbonPanel2.Controls.Add(this.groupBox4);
            this.ribbonPanel2.Controls.Add(this.groupBox3);
            this.ribbonPanel2.Controls.Add(this.groupBox1);
            this.ribbonPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel2.Location = new System.Drawing.Point(0, 55);
            this.ribbonPanel2.Name = "ribbonPanel2";
            this.ribbonPanel2.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel2.Size = new System.Drawing.Size(800, 543);
            this.ribbonPanel2.TabIndex = 2;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.Color.Transparent;
            this.groupBox5.Controls.Add(this.checkedListBox5);
            this.groupBox5.Location = new System.Drawing.Point(515, 396);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(281, 141);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "未知区域";
            // 
            // checkedListBox5
            // 
            this.checkedListBox5.BackColor = System.Drawing.Color.LemonChiffon;
            this.checkedListBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox5.FormattingEnabled = true;
            this.checkedListBox5.Location = new System.Drawing.Point(3, 17);
            this.checkedListBox5.Name = "checkedListBox5";
            this.checkedListBox5.Size = new System.Drawing.Size(275, 116);
            this.checkedListBox5.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.checkedListBox2);
            this.groupBox2.Location = new System.Drawing.Point(263, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 537);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "地下商城";
            // 
            // checkedListBox2
            // 
            this.checkedListBox2.BackColor = System.Drawing.Color.LemonChiffon;
            this.checkedListBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox2.FormattingEnabled = true;
            this.checkedListBox2.Location = new System.Drawing.Point(3, 17);
            this.checkedListBox2.Name = "checkedListBox2";
            this.checkedListBox2.Size = new System.Drawing.Size(240, 516);
            this.checkedListBox2.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.checkedListBox4);
            this.groupBox4.Location = new System.Drawing.Point(518, 191);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(274, 188);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "楚天明珠";
            // 
            // checkedListBox4
            // 
            this.checkedListBox4.BackColor = System.Drawing.Color.LemonChiffon;
            this.checkedListBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox4.FormattingEnabled = true;
            this.checkedListBox4.Location = new System.Drawing.Point(3, 17);
            this.checkedListBox4.Name = "checkedListBox4";
            this.checkedListBox4.Size = new System.Drawing.Size(268, 164);
            this.checkedListBox4.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.checkedListBox3);
            this.groupBox3.Location = new System.Drawing.Point(520, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 171);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "华城豪庭";
            // 
            // checkedListBox3
            // 
            this.checkedListBox3.BackColor = System.Drawing.Color.LemonChiffon;
            this.checkedListBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox3.FormattingEnabled = true;
            this.checkedListBox3.Location = new System.Drawing.Point(3, 17);
            this.checkedListBox3.Name = "checkedListBox3";
            this.checkedListBox3.Size = new System.Drawing.Size(268, 148);
            this.checkedListBox3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.checkedListBox1);
            this.groupBox1.Location = new System.Drawing.Point(6, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(251, 537);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "二医";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.LemonChiffon;
            this.checkedListBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(3, 17);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(245, 516);
            this.checkedListBox1.TabIndex = 0;
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonPanel3.Controls.Add(this.richTextBox1);
            this.ribbonPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel3.Location = new System.Drawing.Point(0, 55);
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel3.Size = new System.Drawing.Size(800, 543);
            this.ribbonPanel3.TabIndex = 3;
            this.ribbonPanel3.Visible = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(794, 540);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.ribbonPanel1.Controls.Add(this.webBrowser1);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 55);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(800, 543);
            this.ribbonPanel1.TabIndex = 1;
            this.ribbonPanel1.Visible = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(794, 540);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("http://www.zhenxiuhe.com/base/admin/index.php", System.UriKind.Absolute);
            // 
            // ribbonTabItem1
            // 
            this.ribbonTabItem1.Name = "ribbonTabItem1";
            this.ribbonTabItem1.Panel = this.ribbonPanel1;
            this.ribbonTabItem1.Text = "web页";
            // 
            // ribbonTabItem2
            // 
            this.ribbonTabItem2.Checked = true;
            this.ribbonTabItem2.Name = "ribbonTabItem2";
            this.ribbonTabItem2.Panel = this.ribbonPanel2;
            this.ribbonTabItem2.Text = "订单状态";
            // 
            // ribbonTabItem_error
            // 
            this.ribbonTabItem_error.Name = "ribbonTabItem_error";
            this.ribbonTabItem_error.Panel = this.ribbonPanel3;
            this.ribbonTabItem_error.Text = "错误日志";
            // 
            // office2007StartButton1
            // 
            this.office2007StartButton1.AutoExpandOnClick = true;
            this.office2007StartButton1.CanCustomize = false;
            this.office2007StartButton1.HotTrackingStyle = DevComponents.DotNetBar.eHotTrackingStyle.Image;
            this.office2007StartButton1.Image = ((System.Drawing.Image)(resources.GetObject("office2007StartButton1.Image")));
            this.office2007StartButton1.ImagePaddingHorizontal = 2;
            this.office2007StartButton1.ImagePaddingVertical = 2;
            this.office2007StartButton1.Name = "office2007StartButton1";
            this.office2007StartButton1.ShowSubItems = false;
            this.office2007StartButton1.Text = "&File";
            this.office2007StartButton1.Click += new System.EventHandler(this.office2007StartButton1_Click);
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.Text = "珍馐盒";
            this.buttonItem1.Click += new System.EventHandler(this.buttonItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "zhenxiuhe_taoliuwei";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ribbonControl1.ResumeLayout(false);
            this.ribbonControl1.PerformLayout();
            this.ribbonPanel2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ribbonPanel3.ResumeLayout(false);
            this.ribbonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private DevComponents.DotNetBar.RibbonControl ribbonControl1;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel2;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem1;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem2;
        private DevComponents.DotNetBar.Office2007StartButton office2007StartButton1;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox checkedListBox4;
        private System.Windows.Forms.CheckedListBox checkedListBox3;
        private System.Windows.Forms.CheckedListBox checkedListBox2;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckedListBox checkedListBox5;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private DevComponents.DotNetBar.RibbonTabItem ribbonTabItem_error;

    }
}

