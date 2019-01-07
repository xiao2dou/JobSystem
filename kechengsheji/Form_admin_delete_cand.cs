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
    public partial class Form_admin_delete_cand : Form
    {
        string cand_uid = null;

        string consqlserver = "Data Source=.;Initial Catalog=test;Integrated Security=True;";//数据库连接语句
        string sql = null; //sql语句
        SqlConnection con = null;  //sql连接对象
        public Form_admin_delete_cand(string name)
        {
            InitializeComponent();
            cand_uid = name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_admin_delete_cand_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void Form_admin_delete_cand_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(consqlserver);
            con.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //apply\invite\result
            sql = "delete from apply where cddusername='" + cand_uid + "';"+
            "delete from invite where cddusername='" + cand_uid + "';"+
            "delete from result where cddusername='" + cand_uid + "';"+
            "delete from record where cddusername='" + cand_uid + "';" +
            "delete from candidate where cddusername='" + cand_uid + "';"; 
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            MessageBox.Show("删除成功,请刷新窗口");
            Close();
        }
    }
}
