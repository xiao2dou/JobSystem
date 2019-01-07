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
    public partial class form1 : Form
    {
        DataSet ds = new DataSet();  //数据缓存
        string consqlserver = "Data Source=.;Initial Catalog=test;Integrated Security=True;";//数据库连接语句
        string sql = null; //sql语句
        SqlConnection con = null;  //sql连接对象
        //SqlDataAdapter da = null;//数据和DataSet的桥梁
        public form1()
        {
            InitializeComponent();
        }

        private void form1_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(consqlserver);
            con.Open();
        }

        private void btn_reg_Click(object sender, EventArgs e)
        {
            
            Form_register register = new Form_register();
            register.Show();

            

        }

        private void btn_re_Click(object sender, EventArgs e)
        {
            txt_name.Text = "";
            txt_pwd.Text = "";
            comboBox_iden.Text = "求职者";
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            string name = txt_name.Text;
            string pwd = txt_pwd.Text;
            string iden = comboBox_iden.Text;
            sql = "select * from users where name='" + name + "' and passwd='" + pwd + "' and iden='"+iden+"'";
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader sread = cmd.ExecuteReader();
            try
            {
                if(sread.Read())
                {
                   // MessageBox.Show("登录成功");
                    clear();
                    switch(iden)
                    {
                        case "求职者":
                            Form_main_qiuzhi fm = new Form_main_qiuzhi(this, name);
                            fm.Show();
                            break;
                        case "企业":
                            Form_main_enterprise fme = new Form_main_enterprise(this, name);
                            fme.Show();
                            break;
                        case "管理员":
                            Form_main_admin fma = new Form_main_admin(this);
                            fma.Show();
                            break;
                    }
                    
                    Hide();
                    //Close();
                }
                else
                {
                    MessageBox.Show("用户名不存在或密码错误或身份错误");
                    clear();
                }
            }
            catch (Exception msg)
            {
                throw new Exception(msg.ToString());
            }
            finally
            {
                sread.Close();
            }

            
            

        }
        private void clear()
        {
            txt_name.Text = "";
            txt_pwd.Text = "";
            comboBox_iden.Text = "求职者";
        }
        //private void btn_temp_Click(object sender, EventArgs e)
        //{
        //    MessageBox.Show("登陆成功，当前为游客模式");
        //}

        private void form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }
    }
}
