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
    public partial class Form_admin_delete_enterprise : Form
    {

        string etp_id = null;
        string etpname = null;

        string consqlserver = "Data Source=.;Initial Catalog=test;Integrated Security=True;";//数据库连接语句
        string sql = null; //sql语句
        SqlConnection con = null;  //sql连接对象
        public Form_admin_delete_enterprise(string id,string name)
        {
            InitializeComponent();
            etp_id = id;
            etpname = name;
        }

        private void Form_admin_delete_enterprise_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(consqlserver);
            con.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_admin_delete_enterprise_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql = "delete from job where etpname='" + etpname + "';" +
            "delete from invite where etpname='" + etpname + "';" +
            "delete from result where etpname='" + etpname + "';" +
            "delete from record where etpname='" + etpname + "';" +
            "delete from enterprise where etpusername='" + etp_id + "';";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            MessageBox.Show("删除成功,请刷新窗口");
            Close();
        }
    }
}
