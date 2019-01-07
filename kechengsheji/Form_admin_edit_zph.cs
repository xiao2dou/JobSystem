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
    public partial class Form_admin_edit_zph : Form
    {

        string consqlserver = "Data Source=.;Initial Catalog=test;Integrated Security=True;";//数据库连接语句
        string sql = null; //sql语句
        SqlConnection con = null;  //sql连接对象
        public Form_admin_edit_zph()
        {
            InitializeComponent();
        }

        private void Form_admin_edit_zph_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(consqlserver);
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int number = Convert.ToInt32(txt_number.Text);
            string theme = txt_theme.Text;
            string time = txt_time.Text;
            string size = txt_size.Text;
            string addr = txt_addr.Text;
            string info = txt_info.Text;

            sql = "insert into fair values(" + number + ",'" + theme + "','" + time + "','" + size + "','" + addr + "','" + info + "');";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            MessageBox.Show("编辑成功");
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_admin_edit_zph_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }
    }
}
