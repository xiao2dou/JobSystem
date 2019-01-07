namespace kechengsheji
{
    partial class Form_register
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_name = new System.Windows.Forms.Label();
            this.label_pwd1 = new System.Windows.Forms.Label();
            this.label_pwd2 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_pwd1 = new System.Windows.Forms.TextBox();
            this.txt_pwd2 = new System.Windows.Forms.TextBox();
            this.label_messname = new System.Windows.Forms.Label();
            this.label_messpwd1 = new System.Windows.Forms.Label();
            this.label_messpwd2 = new System.Windows.Forms.Label();
            this.btn_register = new System.Windows.Forms.Button();
            this.label_iden = new System.Windows.Forms.Label();
            this.label_messiden = new System.Windows.Forms.Label();
            this.com_iden = new System.Windows.Forms.ComboBox();
            this.label_welcome = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_name
            // 
            this.label_name.AutoSize = true;
            this.label_name.Font = new System.Drawing.Font("宋体", 12F);
            this.label_name.Location = new System.Drawing.Point(44, 82);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(64, 16);
            this.label_name.TabIndex = 0;
            this.label_name.Text = "用户名:";
            // 
            // label_pwd1
            // 
            this.label_pwd1.AutoSize = true;
            this.label_pwd1.Font = new System.Drawing.Font("宋体", 12F);
            this.label_pwd1.Location = new System.Drawing.Point(60, 109);
            this.label_pwd1.Name = "label_pwd1";
            this.label_pwd1.Size = new System.Drawing.Size(48, 16);
            this.label_pwd1.TabIndex = 1;
            this.label_pwd1.Text = "密码:";
            // 
            // label_pwd2
            // 
            this.label_pwd2.AutoSize = true;
            this.label_pwd2.Font = new System.Drawing.Font("宋体", 12F);
            this.label_pwd2.Location = new System.Drawing.Point(28, 136);
            this.label_pwd2.Name = "label_pwd2";
            this.label_pwd2.Size = new System.Drawing.Size(80, 16);
            this.label_pwd2.TabIndex = 2;
            this.label_pwd2.Text = "确认密码:";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(138, 77);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(100, 21);
            this.txt_name.TabIndex = 4;
            // 
            // txt_pwd1
            // 
            this.txt_pwd1.Location = new System.Drawing.Point(138, 104);
            this.txt_pwd1.Name = "txt_pwd1";
            this.txt_pwd1.PasswordChar = '*';
            this.txt_pwd1.Size = new System.Drawing.Size(100, 21);
            this.txt_pwd1.TabIndex = 5;
            // 
            // txt_pwd2
            // 
            this.txt_pwd2.Location = new System.Drawing.Point(138, 131);
            this.txt_pwd2.Name = "txt_pwd2";
            this.txt_pwd2.PasswordChar = '*';
            this.txt_pwd2.Size = new System.Drawing.Size(100, 21);
            this.txt_pwd2.TabIndex = 6;
            // 
            // label_messname
            // 
            this.label_messname.AutoSize = true;
            this.label_messname.Location = new System.Drawing.Point(269, 80);
            this.label_messname.Name = "label_messname";
            this.label_messname.Size = new System.Drawing.Size(227, 12);
            this.label_messname.TabIndex = 8;
            this.label_messname.Text = "*请输入您的用户名(字符、数字、下划线)";
            this.label_messname.Click += new System.EventHandler(this.label_messname_Click);
            // 
            // label_messpwd1
            // 
            this.label_messpwd1.AutoSize = true;
            this.label_messpwd1.Location = new System.Drawing.Point(269, 107);
            this.label_messpwd1.Name = "label_messpwd1";
            this.label_messpwd1.Size = new System.Drawing.Size(149, 12);
            this.label_messpwd1.TabIndex = 9;
            this.label_messpwd1.Text = "*请输入您的密码，6位以上";
            // 
            // label_messpwd2
            // 
            this.label_messpwd2.AutoSize = true;
            this.label_messpwd2.Location = new System.Drawing.Point(269, 134);
            this.label_messpwd2.Name = "label_messpwd2";
            this.label_messpwd2.Size = new System.Drawing.Size(95, 12);
            this.label_messpwd2.TabIndex = 10;
            this.label_messpwd2.Text = "*请确认您的密码";
            // 
            // btn_register
            // 
            this.btn_register.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_register.Location = new System.Drawing.Point(138, 201);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(75, 23);
            this.btn_register.TabIndex = 12;
            this.btn_register.Text = "注册";
            this.btn_register.UseVisualStyleBackColor = true;
            this.btn_register.Click += new System.EventHandler(this.btn_register_Click);
            // 
            // label_iden
            // 
            this.label_iden.AutoSize = true;
            this.label_iden.Font = new System.Drawing.Font("宋体", 12F);
            this.label_iden.Location = new System.Drawing.Point(60, 162);
            this.label_iden.Name = "label_iden";
            this.label_iden.Size = new System.Drawing.Size(48, 16);
            this.label_iden.TabIndex = 13;
            this.label_iden.Text = "身份:";
            // 
            // label_messiden
            // 
            this.label_messiden.AutoSize = true;
            this.label_messiden.Location = new System.Drawing.Point(269, 162);
            this.label_messiden.Name = "label_messiden";
            this.label_messiden.Size = new System.Drawing.Size(95, 12);
            this.label_messiden.TabIndex = 15;
            this.label_messiden.Text = "*请选择您的身份";
            // 
            // com_iden
            // 
            this.com_iden.FormattingEnabled = true;
            this.com_iden.Items.AddRange(new object[] {
            "求职者",
            "企业"});
            this.com_iden.Location = new System.Drawing.Point(138, 158);
            this.com_iden.Name = "com_iden";
            this.com_iden.Size = new System.Drawing.Size(121, 20);
            this.com_iden.TabIndex = 16;
            this.com_iden.Text = "求职者";
            this.com_iden.SelectedIndexChanged += new System.EventHandler(this.com_iden_SelectedIndexChanged);
            // 
            // label_welcome
            // 
            this.label_welcome.AutoSize = true;
            this.label_welcome.Font = new System.Drawing.Font("宋体", 18F);
            this.label_welcome.Location = new System.Drawing.Point(200, 21);
            this.label_welcome.Name = "label_welcome";
            this.label_welcome.Size = new System.Drawing.Size(106, 24);
            this.label_welcome.TabIndex = 17;
            this.label_welcome.Text = "欢迎注册";
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_close.Location = new System.Drawing.Point(271, 201);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 18;
            this.btn_close.Text = "返回";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // Form_register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(509, 250);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.label_welcome);
            this.Controls.Add(this.com_iden);
            this.Controls.Add(this.label_messiden);
            this.Controls.Add(this.label_iden);
            this.Controls.Add(this.btn_register);
            this.Controls.Add(this.label_messpwd2);
            this.Controls.Add(this.label_messpwd1);
            this.Controls.Add(this.label_messname);
            this.Controls.Add(this.txt_pwd2);
            this.Controls.Add(this.txt_pwd1);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label_pwd2);
            this.Controls.Add(this.label_pwd1);
            this.Controls.Add(this.label_name);
            this.Name = "Form_register";
            this.Text = "注册";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_register_FormClosing);
            this.Load += new System.EventHandler(this.Form_register_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_name;
        private System.Windows.Forms.Label label_pwd1;
        private System.Windows.Forms.Label label_pwd2;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_pwd1;
        private System.Windows.Forms.TextBox txt_pwd2;
        private System.Windows.Forms.Label label_messname;
        private System.Windows.Forms.Label label_messpwd1;
        private System.Windows.Forms.Label label_messpwd2;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.Label label_iden;
        private System.Windows.Forms.Label label_messiden;
        private System.Windows.Forms.ComboBox com_iden;
        private System.Windows.Forms.Label label_welcome;
        private System.Windows.Forms.Button btn_close;
    }
}