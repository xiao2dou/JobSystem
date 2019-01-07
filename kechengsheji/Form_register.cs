using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kechengsheji
{
    public partial class Form_register : Form
    {
        string consqlserver = "Data Source=.;Initial Catalog=test;Integrated Security=True;";//数据库连接语句
        string sql = null; //sql语句
        SqlConnection con = null;  //sql连接对象
        public Form_register()
        {
            InitializeComponent();
        }

        private void label_messname_Click(object sender, EventArgs e)
        {

        }

        private void com_iden_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            //Form_register_success succ = new Form_register_success();
            //succ.Show();
            string name = txt_name.Text;
            string passwd1 = txt_pwd1.Text;
            string passwd2 = txt_pwd2.Text;
            string iden = com_iden.Text;
            //string email = txt_email.Text;
            sql = "select * from users where name = '"+name+"'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader sread = cmd.ExecuteReader();
            try
            {
                if (sread.Read())
                {
                    MessageBox.Show("用户名已存在，请重新输入");
                    clear();
                    sread.Close();
                    return;
                }
                else
                {
                    sread.Close();
                    if (passwd1.Length < 6)
                    {
                        MessageBox.Show("密码长度须不小于6位，请重新输入");
                        clear();
                        return;
                    }
                    if (!passwd1.Equals(passwd2))
                    {
                        MessageBox.Show("两次密码输入不一致，请重新输入");
                        clear();
                        return;
                    }
                    else
                    {
                        switch(iden)
                        {
                            case "求职者":
                                sql = "insert into users values('" + name + "','" + passwd1 + "','" + iden + "');"
                                    + "insert into candidate(cddusername,cddpassword) values('"+name+"','"+passwd1+"');";
                                cmd = new SqlCommand(sql, con);
                                cmd.ExecuteNonQuery();
                                break;
                            case "企业":
                                sql = "insert into users values('" + name + "','" + passwd1 + "','" + iden + "');"
                                    + "insert into enterprise(etpusername,etppassword) values('" + name + "','" + passwd1 + "');";
                                cmd = new SqlCommand(sql, con);
                                cmd.ExecuteNonQuery();
                                break;
                        }
                        //sql = "insert into users values('" + name + "','" + passwd1 + "','" + iden + "');";
                        //cmd = new SqlCommand(sql, con);
                        //cmd.ExecuteNonQuery();
                        MessageBox.Show("注册成功，请返回登录");
                        clear();
                    }
                }
            }
            catch (Exception msg)
            {
                throw new Exception(msg.ToString());
            }


            string passwd = txt_pwd1.Text;

            
        }
        private void clear()
        {
            //txt_email.Text = "";
            txt_name.Text = "";
            txt_pwd1.Text = "";
            txt_pwd2.Text = "";
            com_iden.Text = "求职者";
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_register_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(consqlserver);
            con.Open();
        }

        private void Form_register_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }
    }
}
