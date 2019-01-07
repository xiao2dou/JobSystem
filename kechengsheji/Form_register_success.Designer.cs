namespace kechengsheji
{
    partial class Form_register_success
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
            this.label_mess = new System.Windows.Forms.Label();
            this.btn_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_mess
            // 
            this.label_mess.AutoSize = true;
            this.label_mess.Font = new System.Drawing.Font("宋体", 12F);
            this.label_mess.Location = new System.Drawing.Point(63, 40);
            this.label_mess.Name = "label_mess";
            this.label_mess.Size = new System.Drawing.Size(184, 16);
            this.label_mess.TabIndex = 0;
            this.label_mess.Text = "注册成功!!! 请返回登陆";
            // 
            // btn_close
            // 
            this.btn_close.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_close.Location = new System.Drawing.Point(106, 82);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 1;
            this.btn_close.Text = "确定";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // Form_register_success
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 117);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.label_mess);
            this.Name = "Form_register_success";
            this.Text = "注册成功";
            this.Load += new System.EventHandler(this.Form_register_success_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_mess;
        private System.Windows.Forms.Button btn_close;
    }
}