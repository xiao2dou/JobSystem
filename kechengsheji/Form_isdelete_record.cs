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
    public partial class Form_isdelete_record : Form
    {

        string cand_uid;
        int jobnumber;

        string consqlserver = "Data Source=.;Initial Catalog=test;Integrated Security=True;";//数据库连接语句
        string sql = null; //sql语句
        SqlConnection con = null;  //sql连接对象
        public Form_isdelete_record(string name,int number)
        {
            InitializeComponent();
            cand_uid = name;
            jobnumber = number;
        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_isdelete_record_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(consqlserver);
            con.Open();
        }

        private void Form_isdelete_record_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {
            sql = "delete  from record where jobnumber=" + jobnumber + " and cddusername='" + cand_uid + "';";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            MessageBox.Show("删除成功,请刷新窗口");
            Close();
        }
    }
}
