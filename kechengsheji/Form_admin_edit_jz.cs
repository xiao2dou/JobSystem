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
    public partial class Form_admin_edit_jz : Form
    {

        string consqlserver = "Data Source=.;Initial Catalog=test;Integrated Security=True;";//数据库连接语句
        string sql = null; //sql语句
        SqlConnection con = null;  //sql连接对象
        public Form_admin_edit_jz()
        {
            InitializeComponent();
        }

        private void Form_admin_edit_jz_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(consqlserver);
            con.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_admin_edit_jz_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(txt_number.Text);
            string descr = txt_descr.Text;
            string addr = txt_addr.Text;
            string salary = txt_salary.Text;

            sql = "insert into parttimejob values(" + number + ",'" + descr + "','" + addr + "','" + salary + "');";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            MessageBox.Show("编辑成功");
            Close();

        }
    }
}
