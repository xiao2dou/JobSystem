namespace kechengsheji
{
    partial class form1
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
            this.label_name = new System.Windows.Forms.Label();
            this.label_passwd = new System.Windows.Forms.Label();
            this.label_welcome = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_pwd = new System.Windows.Forms.TextBox();
            this.btn_reg = new System.Windows.Forms.Button();
            this.label_iden = new System.Windows.Forms.Label();
            this.comboBox_iden = new System.Windows.Forms.ComboBox();
            this.btn_re = new System.Windows.Forms.Button();
            this.btn_log = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Location = new System.Drawing.Point(92, 140);
            this.label_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(64, 16);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "用户名:";
            // 
            // label_passwd
            // 
            this.label_passwd.AutoSize = true;
            this.label_passwd.Location = new System.Drawing.Point(108, 198);
            this.label_passwd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_passwd.Name = "label_passwd";
            this.label_passwd.Size = new System.Drawing.Size(48, 16);
            this.label_passwd.TabIndex = 1;
            this.label_passwd.Text = "密码:";
            // 
            // label_welcome
            // 
            this.label_welcome.AutoSize = true;
            this.label_welcome.Font = new System.Drawing.Font("宋体", 18F);
            this.label_welcome.Location = new System.Drawing.Point(150, 59);
            this.label_welcome.Name = "label_welcome";
            this.label_welcome.Size = new System.Drawing.Size(250, 24);
            this.label_welcome.TabIndex = 2;
            this.label_welcome.Text = "欢迎使用招聘求职系统";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(187, 137);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(199, 26);
            this.txt_name.TabIndex = 3;
            // 
            // txt_pwd
            // 
            this.txt_pwd.Location = new System.Drawing.Point(187, 188);
            this.txt_pwd.Name = "txt_pwd";
            this.txt_pwd.PasswordChar = '*';
            this.txt_pwd.Size = new System.Drawing.Size(199, 26);
            this.txt_pwd.TabIndex = 4;
            // 
            // btn_reg
            // 
            this.btn_reg.Location = new System.Drawing.Point(412, 137);
            this.btn_reg.Name = "btn_reg";
            this.btn_reg.Size = new System.Drawing.Size(89, 23);
            this.btn_reg.TabIndex = 5;
            this.btn_reg.Text = "立即注册";
            this.btn_reg.UseVisualStyleBackColor = true;
            this.btn_reg.Click += new System.EventHandler(this.btn_reg_Click);
            // 
            // label_iden
            // 
            this.label_iden.AutoSize = true;
            this.label_iden.Location = new System.Drawing.Point(108, 254);
            this.label_iden.Name = "label_iden";
            this.label_iden.Size = new System.Drawing.Size(48, 16);
            this.label_iden.TabIndex = 6;
            this.label_iden.Text = "身份:";
            // 
            // comboBox_iden
            // 
            this.comboBox_iden.FormattingEnabled = true;
            this.comboBox_iden.Items.AddRange(new object[] {
            "求职者",
            "企业",
            "管理员"});
            this.comboBox_iden.Location = new System.Drawing.Point(187, 246);
            this.comboBox_iden.Name = "comboBox_iden";
            this.comboBox_iden.Size = new System.Drawing.Size(199, 24);
            this.comboBox_iden.TabIndex = 7;
            this.comboBox_iden.Text = "求职者";
            // 
            // btn_re
            // 
            this.btn_re.Location = new System.Drawing.Point(122, 303);
            this.btn_re.Name = "btn_re";
            this.btn_re.Size = new System.Drawing.Size(75, 23);
            this.btn_re.TabIndex = 8;
            this.btn_re.Text = "重置";
            this.btn_re.UseVisualStyleBackColor = true;
            this.btn_re.Click += new System.EventHandler(this.btn_re_Click);
            // 
            // btn_log
            // 
            this.btn_log.Location = new System.Drawing.Point(352, 303);
            this.btn_log.Name = "btn_log";
            this.btn_log.Size = new System.Drawing.Size(75, 23);
            this.btn_log.TabIndex = 9;
            this.btn_log.Text = "登录";
            this.btn_log.UseVisualStyleBackColor = true;
            this.btn_log.Click += new System.EventHandler(this.btn_log_Click);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 371);
            this.Controls.Add(this.btn_log);
            this.Controls.Add(this.btn_re);
            this.Controls.Add(this.comboBox_iden);
            this.Controls.Add(this.label_iden);
            this.Controls.Add(this.btn_reg);
            this.Controls.Add(this.txt_pwd);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label_welcome);
            this.Controls.Add(this.label_passwd);
            this.Controls.Add(this.label_name);
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "form1";
            this.Text = "欢迎使用";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form1_FormClosing);
            this.Load += new System.EventHandler(this.form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_passwd;
        private System.Windows.Forms.Label label_welcome;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_pwd;
        private System.Windows.Forms.Button btn_reg;
        private System.Windows.Forms.Label label_iden;
        private System.Windows.Forms.Button btn_re;
        private System.Windows.Forms.Button btn_log;
        private System.Windows.Forms.ComboBox comboBox_iden;
    }
}

