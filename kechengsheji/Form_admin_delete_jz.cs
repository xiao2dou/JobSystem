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
    public partial class Form_admin_delete_jz : Form
    {
        int jz_number = 0;

        string consqlserver = "Data Source=.;Initial Catalog=test;Integrated Security=True;";//数据库连接语句
        string sql = null; //sql语句
        SqlConnection con = null;  //sql连接对象
        public Form_admin_delete_jz(int number)
        {
            InitializeComponent();
            jz_number = number;
        }

        private void Form_admin_delete_jz_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(consqlserver);
            con.Open();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //apply\invite\result
            sql = "delete from parttimejob where ptjnumber=" + jz_number + ";";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            MessageBox.Show("删除成功,请刷新窗口");
            Close();
        }

        private void Form_admin_delete_jz_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            sql = "delete from parttimejob where ptjnumber=" + jz_number + ";";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            MessageBox.Show("删除成功,请刷新窗口");
            Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Close();
        }
    }
}
