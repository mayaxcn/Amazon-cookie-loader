namespace Amazon_cookie_loader
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.COOKIE_TEXT = new System.Windows.Forms.TextBox();
            this.AMZ_LOGIN_BTN = new System.Windows.Forms.Button();
            this.CLEAR_COOKIE_BTN = new System.Windows.Forms.Button();
            this.CLOSE_AMZ = new System.Windows.Forms.Button();
            this.AREAID = new System.Windows.Forms.ComboBox();
            this.github_link = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.COOKIE_TEXT);
            this.groupBox1.Location = new System.Drawing.Point(2, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 479);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "COOKIE";
            // 
            // COOKIE_TEXT
            // 
            this.COOKIE_TEXT.Location = new System.Drawing.Point(7, 18);
            this.COOKIE_TEXT.Multiline = true;
            this.COOKIE_TEXT.Name = "COOKIE_TEXT";
            this.COOKIE_TEXT.Size = new System.Drawing.Size(547, 455);
            this.COOKIE_TEXT.TabIndex = 0;
            // 
            // AMZ_LOGIN_BTN
            // 
            this.AMZ_LOGIN_BTN.Location = new System.Drawing.Point(568, 56);
            this.AMZ_LOGIN_BTN.Name = "AMZ_LOGIN_BTN";
            this.AMZ_LOGIN_BTN.Size = new System.Drawing.Size(114, 61);
            this.AMZ_LOGIN_BTN.TabIndex = 1;
            this.AMZ_LOGIN_BTN.Text = "打开浏览器";
            this.AMZ_LOGIN_BTN.UseVisualStyleBackColor = true;
            this.AMZ_LOGIN_BTN.Click += new System.EventHandler(this.AMZ_LOGIN_BTN_Click);
            // 
            // CLEAR_COOKIE_BTN
            // 
            this.CLEAR_COOKIE_BTN.Location = new System.Drawing.Point(568, 123);
            this.CLEAR_COOKIE_BTN.Name = "CLEAR_COOKIE_BTN";
            this.CLEAR_COOKIE_BTN.Size = new System.Drawing.Size(114, 61);
            this.CLEAR_COOKIE_BTN.TabIndex = 2;
            this.CLEAR_COOKIE_BTN.Text = "清除COOKIE";
            this.CLEAR_COOKIE_BTN.UseVisualStyleBackColor = true;
            this.CLEAR_COOKIE_BTN.Click += new System.EventHandler(this.CLEAR_COOKIE_BTN_Click);
            // 
            // CLOSE_AMZ
            // 
            this.CLOSE_AMZ.Location = new System.Drawing.Point(568, 190);
            this.CLOSE_AMZ.Name = "CLOSE_AMZ";
            this.CLOSE_AMZ.Size = new System.Drawing.Size(114, 61);
            this.CLOSE_AMZ.TabIndex = 3;
            this.CLOSE_AMZ.Text = "关闭浏览器";
            this.CLOSE_AMZ.UseVisualStyleBackColor = true;
            this.CLOSE_AMZ.Click += new System.EventHandler(this.CLOSE_AMZ_Click);
            // 
            // AREAID
            // 
            this.AREAID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AREAID.FormattingEnabled = true;
            this.AREAID.Items.AddRange(new object[] {
            "选择地区",
            "com",
            "ca"});
            this.AREAID.Location = new System.Drawing.Point(568, 12);
            this.AREAID.Name = "AREAID";
            this.AREAID.Size = new System.Drawing.Size(114, 20);
            this.AREAID.TabIndex = 12;
            // 
            // github_link
            // 
            this.github_link.AutoSize = true;
            this.github_link.LinkColor = System.Drawing.Color.DimGray;
            this.github_link.Location = new System.Drawing.Point(610, 462);
            this.github_link.Name = "github_link";
            this.github_link.Size = new System.Drawing.Size(65, 12);
            this.github_link.TabIndex = 13;
            this.github_link.TabStop = true;
            this.github_link.Text = "Github源码";
            this.github_link.VisitedLinkColor = System.Drawing.Color.DimGray;
            this.github_link.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.github_link_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(576, 451);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 490);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.github_link);
            this.Controls.Add(this.AREAID);
            this.Controls.Add(this.CLOSE_AMZ);
            this.Controls.Add(this.CLEAR_COOKIE_BTN);
            this.Controls.Add(this.AMZ_LOGIN_BTN);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "亚马逊Cookie登录器";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox COOKIE_TEXT;
        private System.Windows.Forms.Button AMZ_LOGIN_BTN;
        private System.Windows.Forms.Button CLEAR_COOKIE_BTN;
        private System.Windows.Forms.Button CLOSE_AMZ;
        private System.Windows.Forms.ComboBox AREAID;
        private System.Windows.Forms.LinkLabel github_link;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

