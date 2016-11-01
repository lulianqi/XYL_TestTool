namespace MyNetwork_Emulator
{
    partial class MyNetworkEmulator
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
            this.bt_start = new System.Windows.Forms.Button();
            this.bt_stop = new System.Windows.Forms.Button();
            this.tb_set_Bandwidth = new System.Windows.Forms.TextBox();
            this.lb_info_1 = new System.Windows.Forms.Label();
            this.bt_test = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt_start
            // 
            this.bt_start.Location = new System.Drawing.Point(852, 383);
            this.bt_start.Name = "bt_start";
            this.bt_start.Size = new System.Drawing.Size(75, 23);
            this.bt_start.TabIndex = 0;
            this.bt_start.Text = "开始";
            this.bt_start.UseVisualStyleBackColor = true;
            this.bt_start.Click += new System.EventHandler(this.bt_start_Click);
            // 
            // bt_stop
            // 
            this.bt_stop.Location = new System.Drawing.Point(933, 383);
            this.bt_stop.Name = "bt_stop";
            this.bt_stop.Size = new System.Drawing.Size(75, 23);
            this.bt_stop.TabIndex = 1;
            this.bt_stop.Text = "停止";
            this.bt_stop.UseVisualStyleBackColor = true;
            this.bt_stop.Click += new System.EventHandler(this.bt_stop_Click);
            // 
            // tb_set_Bandwidth
            // 
            this.tb_set_Bandwidth.Location = new System.Drawing.Point(57, 15);
            this.tb_set_Bandwidth.Name = "tb_set_Bandwidth";
            this.tb_set_Bandwidth.Size = new System.Drawing.Size(202, 21);
            this.tb_set_Bandwidth.TabIndex = 2;
            // 
            // lb_info_1
            // 
            this.lb_info_1.AutoSize = true;
            this.lb_info_1.Location = new System.Drawing.Point(10, 18);
            this.lb_info_1.Name = "lb_info_1";
            this.lb_info_1.Size = new System.Drawing.Size(41, 12);
            this.lb_info_1.TabIndex = 3;
            this.lb_info_1.Text = "带宽：";
            // 
            // bt_test
            // 
            this.bt_test.Location = new System.Drawing.Point(741, 383);
            this.bt_test.Name = "bt_test";
            this.bt_test.Size = new System.Drawing.Size(75, 23);
            this.bt_test.TabIndex = 4;
            this.bt_test.Text = "Test";
            this.bt_test.UseVisualStyleBackColor = true;
            this.bt_test.Click += new System.EventHandler(this.bt_test_Click);
            // 
            // MyNetworkEmulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1020, 418);
            this.Controls.Add(this.bt_test);
            this.Controls.Add(this.lb_info_1);
            this.Controls.Add(this.tb_set_Bandwidth);
            this.Controls.Add(this.bt_stop);
            this.Controls.Add(this.bt_start);
            this.Name = "MyNetworkEmulator";
            this.Text = "弱网测试";
            this.Load += new System.EventHandler(this.MyNetworkEmulator_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bt_start;
        private System.Windows.Forms.Button bt_stop;
        private System.Windows.Forms.TextBox tb_set_Bandwidth;
        private System.Windows.Forms.Label lb_info_1;
        private System.Windows.Forms.Button bt_test;
    }
}

