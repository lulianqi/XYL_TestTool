using MyCommonControl;
using MyCommonControl.Control;
namespace TT_Huala_OrderPay
{
    partial class TT_Huala_OrderPay
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TT_Huala_OrderPay));
            this.bt_test = new System.Windows.Forms.Button();
            this.cb_AutoPay = new System.Windows.Forms.CheckBox();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.tb_shopName = new System.Windows.Forms.TextBox();
            this.cb_AutoShopPost = new System.Windows.Forms.CheckBox();
            this.tb_shopPwd = new System.Windows.Forms.TextBox();
            this.bt_shopLogin = new System.Windows.Forms.Button();
            this.cb_postType = new System.Windows.Forms.ComboBox();
            this.tb_sellerId = new System.Windows.Forms.TextBox();
            this.tb_shopToken = new System.Windows.Forms.TextBox();
            this.bt_buyer_login = new System.Windows.Forms.Button();
            this.tb_buyer_pwd = new System.Windows.Forms.TextBox();
            this.tb_buyer_name = new System.Windows.Forms.TextBox();
            this.cb_SellerAffirm = new System.Windows.Forms.CheckBox();
            this.ck_antoRefush = new System.Windows.Forms.CheckBox();
            this.bt_scanOrder = new System.Windows.Forms.Button();
            this.ck_antoSacnPay = new System.Windows.Forms.CheckBox();
            this.tb_filterUserId = new MyCommonControl.Control.TextBoxWithWatermak();
            this.bt_update_hualaSys = new System.Windows.Forms.Button();
            this.lv_orderSnList = new MyCommonControl.ListViewWithButton();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dataRecordBox_MesInfo = new MyCommonControl.DataRecordBox();
            this.bt_update_hualaWx = new System.Windows.Forms.Button();
            this.cb_AutoOpenId = new System.Windows.Forms.CheckBox();
            this.cb_payType = new System.Windows.Forms.ComboBox();
            this.cb_AutoScanOpenId = new System.Windows.Forms.CheckBox();
            this.bt_update_hualaFwc = new System.Windows.Forms.Button();
            this.tb_filterSellerId = new MyCommonControl.Control.TextBoxWithWatermak();
            this.tb_filterDayNum = new MyCommonControl.Control.TextBoxWithWatermak();
            this.SuspendLayout();
            // 
            // bt_test
            // 
            this.bt_test.Location = new System.Drawing.Point(-1, 486);
            this.bt_test.Name = "bt_test";
            this.bt_test.Size = new System.Drawing.Size(75, 23);
            this.bt_test.TabIndex = 1;
            this.bt_test.Text = "Test";
            this.bt_test.UseVisualStyleBackColor = true;
            this.bt_test.Visible = false;
            this.bt_test.Click += new System.EventHandler(this.bt_test_Click);
            // 
            // cb_AutoPay
            // 
            this.cb_AutoPay.AutoSize = true;
            this.cb_AutoPay.Location = new System.Drawing.Point(8, 41);
            this.cb_AutoPay.Name = "cb_AutoPay";
            this.cb_AutoPay.Size = new System.Drawing.Size(66, 16);
            this.cb_AutoPay.TabIndex = 2;
            this.cb_AutoPay.Text = "AutoPay";
            this.cb_AutoPay.UseVisualStyleBackColor = true;
            this.cb_AutoPay.CheckedChanged += new System.EventHandler(this.cb_AutoPay_CheckedChanged);
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(6, 11);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(181, 21);
            this.tb_name.TabIndex = 3;
            // 
            // tb_shopName
            // 
            this.tb_shopName.Location = new System.Drawing.Point(6, 63);
            this.tb_shopName.Name = "tb_shopName";
            this.tb_shopName.Size = new System.Drawing.Size(63, 21);
            this.tb_shopName.TabIndex = 5;
            // 
            // cb_AutoShopPost
            // 
            this.cb_AutoShopPost.AutoSize = true;
            this.cb_AutoShopPost.Location = new System.Drawing.Point(8, 146);
            this.cb_AutoShopPost.Name = "cb_AutoShopPost";
            this.cb_AutoShopPost.Size = new System.Drawing.Size(96, 16);
            this.cb_AutoShopPost.TabIndex = 4;
            this.cb_AutoShopPost.Text = "AutoShopPost";
            this.cb_AutoShopPost.UseVisualStyleBackColor = true;
            this.cb_AutoShopPost.CheckedChanged += new System.EventHandler(this.cb_AutoShopPost_CheckedChanged);
            // 
            // tb_shopPwd
            // 
            this.tb_shopPwd.Location = new System.Drawing.Point(75, 63);
            this.tb_shopPwd.Name = "tb_shopPwd";
            this.tb_shopPwd.Size = new System.Drawing.Size(60, 21);
            this.tb_shopPwd.TabIndex = 6;
            // 
            // bt_shopLogin
            // 
            this.bt_shopLogin.Location = new System.Drawing.Point(141, 62);
            this.bt_shopLogin.Name = "bt_shopLogin";
            this.bt_shopLogin.Size = new System.Drawing.Size(46, 23);
            this.bt_shopLogin.TabIndex = 7;
            this.bt_shopLogin.Text = "Login";
            this.bt_shopLogin.UseVisualStyleBackColor = true;
            this.bt_shopLogin.Click += new System.EventHandler(this.bt_shopLogin_Click);
            // 
            // cb_postType
            // 
            this.cb_postType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_postType.FormattingEnabled = true;
            this.cb_postType.Items.AddRange(new object[] {
            "商家派送",
            "客户自提",
            "第三方派送"});
            this.cb_postType.Location = new System.Drawing.Point(75, 90);
            this.cb_postType.Name = "cb_postType";
            this.cb_postType.Size = new System.Drawing.Size(112, 20);
            this.cb_postType.TabIndex = 8;
            // 
            // tb_sellerId
            // 
            this.tb_sellerId.Location = new System.Drawing.Point(6, 90);
            this.tb_sellerId.Name = "tb_sellerId";
            this.tb_sellerId.Size = new System.Drawing.Size(63, 21);
            this.tb_sellerId.TabIndex = 9;
            // 
            // tb_shopToken
            // 
            this.tb_shopToken.Location = new System.Drawing.Point(6, 116);
            this.tb_shopToken.Name = "tb_shopToken";
            this.tb_shopToken.Size = new System.Drawing.Size(181, 21);
            this.tb_shopToken.TabIndex = 10;
            // 
            // bt_buyer_login
            // 
            this.bt_buyer_login.Location = new System.Drawing.Point(141, 178);
            this.bt_buyer_login.Name = "bt_buyer_login";
            this.bt_buyer_login.Size = new System.Drawing.Size(46, 23);
            this.bt_buyer_login.TabIndex = 13;
            this.bt_buyer_login.Text = "Login";
            this.bt_buyer_login.UseVisualStyleBackColor = true;
            this.bt_buyer_login.Click += new System.EventHandler(this.bt_buyer_login_Click);
            // 
            // tb_buyer_pwd
            // 
            this.tb_buyer_pwd.Location = new System.Drawing.Point(75, 179);
            this.tb_buyer_pwd.Name = "tb_buyer_pwd";
            this.tb_buyer_pwd.Size = new System.Drawing.Size(60, 21);
            this.tb_buyer_pwd.TabIndex = 12;
            // 
            // tb_buyer_name
            // 
            this.tb_buyer_name.Location = new System.Drawing.Point(6, 179);
            this.tb_buyer_name.Name = "tb_buyer_name";
            this.tb_buyer_name.Size = new System.Drawing.Size(63, 21);
            this.tb_buyer_name.TabIndex = 11;
            // 
            // cb_SellerAffirm
            // 
            this.cb_SellerAffirm.AutoSize = true;
            this.cb_SellerAffirm.Location = new System.Drawing.Point(106, 146);
            this.cb_SellerAffirm.Name = "cb_SellerAffirm";
            this.cb_SellerAffirm.Size = new System.Drawing.Size(84, 16);
            this.cb_SellerAffirm.TabIndex = 14;
            this.cb_SellerAffirm.Text = "SellerSure";
            this.cb_SellerAffirm.UseVisualStyleBackColor = true;
            // 
            // ck_antoRefush
            // 
            this.ck_antoRefush.AutoSize = true;
            this.ck_antoRefush.Location = new System.Drawing.Point(446, 298);
            this.ck_antoRefush.Name = "ck_antoRefush";
            this.ck_antoRefush.Size = new System.Drawing.Size(72, 16);
            this.ck_antoRefush.TabIndex = 16;
            this.ck_antoRefush.Text = "自动刷新";
            this.ck_antoRefush.UseVisualStyleBackColor = true;
            this.ck_antoRefush.CheckedChanged += new System.EventHandler(this.ck_antoRefush_CheckedChanged);
            // 
            // bt_scanOrder
            // 
            this.bt_scanOrder.Location = new System.Drawing.Point(192, 294);
            this.bt_scanOrder.Name = "bt_scanOrder";
            this.bt_scanOrder.Size = new System.Drawing.Size(75, 23);
            this.bt_scanOrder.TabIndex = 17;
            this.bt_scanOrder.Text = "刷新";
            this.bt_scanOrder.UseVisualStyleBackColor = true;
            this.bt_scanOrder.Click += new System.EventHandler(this.bt_scanOrder_Click);
            // 
            // ck_antoSacnPay
            // 
            this.ck_antoSacnPay.AutoSize = true;
            this.ck_antoSacnPay.Location = new System.Drawing.Point(524, 298);
            this.ck_antoSacnPay.Name = "ck_antoSacnPay";
            this.ck_antoSacnPay.Size = new System.Drawing.Size(72, 16);
            this.ck_antoSacnPay.TabIndex = 18;
            this.ck_antoSacnPay.Text = "自动支付";
            this.ck_antoSacnPay.UseVisualStyleBackColor = true;
            // 
            // tb_filterUserId
            // 
            this.tb_filterUserId.Location = new System.Drawing.Point(330, 296);
            this.tb_filterUserId.Name = "tb_filterUserId";
            this.tb_filterUserId.Size = new System.Drawing.Size(53, 21);
            this.tb_filterUserId.TabIndex = 19;
            this.tb_filterUserId.WatermarkText = "用户ID";
            // 
            // bt_update_hualaSys
            // 
            this.bt_update_hualaSys.Location = new System.Drawing.Point(6, 307);
            this.bt_update_hualaSys.Name = "bt_update_hualaSys";
            this.bt_update_hualaSys.Size = new System.Drawing.Size(75, 23);
            this.bt_update_hualaSys.TabIndex = 20;
            this.bt_update_hualaSys.Text = "Update Sys";
            this.bt_update_hualaSys.UseVisualStyleBackColor = true;
            this.bt_update_hualaSys.Click += new System.EventHandler(this.bt_update_hualaSys_Click);
            // 
            // lv_orderSnList
            // 
            this.lv_orderSnList.ButtonIndex = 8;
            this.lv_orderSnList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9});
            this.lv_orderSnList.FullRowSelect = true;
            this.lv_orderSnList.Location = new System.Drawing.Point(194, 319);
            this.lv_orderSnList.Name = "lv_orderSnList";
            this.lv_orderSnList.Size = new System.Drawing.Size(720, 190);
            this.lv_orderSnList.TabIndex = 15;
            this.lv_orderSnList.UseCompatibleStateImageBehavior = false;
            this.lv_orderSnList.View = System.Windows.Forms.View.Details;
            this.lv_orderSnList.ButtonClickEvent += new System.EventHandler(this.lv_orderSnList_ButtonClickEvent);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "商家ID";
            this.columnHeader1.Width = 48;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "用户ID";
            this.columnHeader2.Width = 48;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "电话";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "商品金额";
            this.columnHeader4.Width = 64;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "订单金额";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "订单SN";
            this.columnHeader6.Width = 149;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "订单类型";
            this.columnHeader7.Width = 61;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "时间";
            this.columnHeader8.Width = 136;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "操作";
            this.columnHeader9.Width = 65;
            // 
            // dataRecordBox_MesInfo
            // 
            this.dataRecordBox_MesInfo.CanFill = true;
            this.dataRecordBox_MesInfo.Location = new System.Drawing.Point(195, 0);
            this.dataRecordBox_MesInfo.MaxLine = 5000;
            this.dataRecordBox_MesInfo.MianDirectory = "DataRecord";
            this.dataRecordBox_MesInfo.Name = "dataRecordBox_MesInfo";
            this.dataRecordBox_MesInfo.Size = new System.Drawing.Size(720, 291);
            this.dataRecordBox_MesInfo.TabIndex = 0;
            // 
            // bt_update_hualaWx
            // 
            this.bt_update_hualaWx.Location = new System.Drawing.Point(97, 307);
            this.bt_update_hualaWx.Name = "bt_update_hualaWx";
            this.bt_update_hualaWx.Size = new System.Drawing.Size(75, 23);
            this.bt_update_hualaWx.TabIndex = 21;
            this.bt_update_hualaWx.Text = "Update Wx";
            this.bt_update_hualaWx.UseVisualStyleBackColor = true;
            this.bt_update_hualaWx.Click += new System.EventHandler(this.bt_update_hualaWx_Click);
            // 
            // cb_AutoOpenId
            // 
            this.cb_AutoOpenId.AutoSize = true;
            this.cb_AutoOpenId.Location = new System.Drawing.Point(74, 41);
            this.cb_AutoOpenId.Name = "cb_AutoOpenId";
            this.cb_AutoOpenId.Size = new System.Drawing.Size(84, 16);
            this.cb_AutoOpenId.TabIndex = 22;
            this.cb_AutoOpenId.Text = "AutoOpenId";
            this.cb_AutoOpenId.UseVisualStyleBackColor = true;
            // 
            // cb_payType
            // 
            this.cb_payType.FormattingEnabled = true;
            this.cb_payType.Items.AddRange(new object[] {
            "wx",
            "ali"});
            this.cb_payType.Location = new System.Drawing.Point(602, 294);
            this.cb_payType.Name = "cb_payType";
            this.cb_payType.Size = new System.Drawing.Size(112, 20);
            this.cb_payType.TabIndex = 23;
            // 
            // cb_AutoScanOpenId
            // 
            this.cb_AutoScanOpenId.AutoSize = true;
            this.cb_AutoScanOpenId.Location = new System.Drawing.Point(720, 296);
            this.cb_AutoScanOpenId.Name = "cb_AutoScanOpenId";
            this.cb_AutoScanOpenId.Size = new System.Drawing.Size(84, 16);
            this.cb_AutoScanOpenId.TabIndex = 24;
            this.cb_AutoScanOpenId.Text = "AutoOpenId";
            this.cb_AutoScanOpenId.UseVisualStyleBackColor = true;
            // 
            // bt_update_hualaFwc
            // 
            this.bt_update_hualaFwc.Location = new System.Drawing.Point(6, 336);
            this.bt_update_hualaFwc.Name = "bt_update_hualaFwc";
            this.bt_update_hualaFwc.Size = new System.Drawing.Size(75, 23);
            this.bt_update_hualaFwc.TabIndex = 25;
            this.bt_update_hualaFwc.Text = "Update Fwc";
            this.bt_update_hualaFwc.UseVisualStyleBackColor = true;
            this.bt_update_hualaFwc.Click += new System.EventHandler(this.bt_update_hualaFwc_Click);
            // 
            // tb_filterSellerId
            // 
            this.tb_filterSellerId.Location = new System.Drawing.Point(274, 296);
            this.tb_filterSellerId.Name = "tb_filterSellerId";
            this.tb_filterSellerId.Size = new System.Drawing.Size(53, 21);
            this.tb_filterSellerId.TabIndex = 26;
            this.tb_filterSellerId.WatermarkText = "店铺ID";
            // 
            // tb_filterDayNum
            // 
            this.tb_filterDayNum.Location = new System.Drawing.Point(387, 296);
            this.tb_filterDayNum.Name = "tb_filterDayNum";
            this.tb_filterDayNum.Size = new System.Drawing.Size(53, 21);
            this.tb_filterDayNum.TabIndex = 27;
            this.tb_filterDayNum.Text = "3";
            this.tb_filterDayNum.WatermarkText = "查询天数";
            // 
            // TT_Huala_OrderPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(915, 510);
            this.Controls.Add(this.tb_filterDayNum);
            this.Controls.Add(this.tb_filterSellerId);
            this.Controls.Add(this.bt_update_hualaFwc);
            this.Controls.Add(this.cb_AutoScanOpenId);
            this.Controls.Add(this.cb_payType);
            this.Controls.Add(this.cb_AutoOpenId);
            this.Controls.Add(this.bt_update_hualaWx);
            this.Controls.Add(this.bt_update_hualaSys);
            this.Controls.Add(this.tb_filterUserId);
            this.Controls.Add(this.ck_antoSacnPay);
            this.Controls.Add(this.bt_scanOrder);
            this.Controls.Add(this.ck_antoRefush);
            this.Controls.Add(this.lv_orderSnList);
            this.Controls.Add(this.cb_SellerAffirm);
            this.Controls.Add(this.bt_buyer_login);
            this.Controls.Add(this.tb_buyer_pwd);
            this.Controls.Add(this.tb_buyer_name);
            this.Controls.Add(this.tb_shopToken);
            this.Controls.Add(this.tb_sellerId);
            this.Controls.Add(this.cb_postType);
            this.Controls.Add(this.bt_shopLogin);
            this.Controls.Add(this.tb_shopPwd);
            this.Controls.Add(this.tb_shopName);
            this.Controls.Add(this.cb_AutoShopPost);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.cb_AutoPay);
            this.Controls.Add(this.bt_test);
            this.Controls.Add(this.dataRecordBox_MesInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TT_Huala_OrderPay";
            this.Text = "TT_Huala_OrderPay";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TT_Huala_OrderPay_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TT_Huala_OrderPay_FormClosed);
            this.Load += new System.EventHandler(this.TT_Huala_OrderPay_Load);
            this.Resize += new System.EventHandler(this.TT_Huala_OrderPay_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MyCommonControl.DataRecordBox dataRecordBox_MesInfo;
        private System.Windows.Forms.Button bt_test;
        private System.Windows.Forms.CheckBox cb_AutoPay;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_shopName;
        private System.Windows.Forms.CheckBox cb_AutoShopPost;
        private System.Windows.Forms.TextBox tb_shopPwd;
        private System.Windows.Forms.Button bt_shopLogin;
        private System.Windows.Forms.ComboBox cb_postType;
        private System.Windows.Forms.TextBox tb_sellerId;
        private System.Windows.Forms.TextBox tb_shopToken;
        private System.Windows.Forms.TextBox tb_buyer_pwd;
        private System.Windows.Forms.TextBox tb_buyer_name;
        private System.Windows.Forms.Button bt_buyer_login;
        private System.Windows.Forms.CheckBox cb_SellerAffirm;
        private ListViewWithButton lv_orderSnList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.CheckBox ck_antoRefush;
        private System.Windows.Forms.Button bt_scanOrder;
        private System.Windows.Forms.CheckBox ck_antoSacnPay;
        private TextBoxWithWatermak tb_filterUserId;
        private System.Windows.Forms.Button bt_update_hualaSys;
        private System.Windows.Forms.Button bt_update_hualaWx;
        private System.Windows.Forms.CheckBox cb_AutoOpenId;
        private System.Windows.Forms.ComboBox cb_payType;
        private System.Windows.Forms.CheckBox cb_AutoScanOpenId;
        private System.Windows.Forms.Button bt_update_hualaFwc;
        private TextBoxWithWatermak tb_filterSellerId;
        private TextBoxWithWatermak tb_filterDayNum;
    }
}

