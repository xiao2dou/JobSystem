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
    public partial class Form_guide : Form
    {
        int guidenumber;

        string consqlserver = "Data Source=.;Initial Catalog=test;Integrated Security=True;";//数据库连接语句
        string sql = null; //sql语句
        SqlConnection con = null;  //sql连接对象
        public Form_guide(int number)
        {
            InitializeComponent();
            guidenumber = number;
        }

        private void Form_guide_Load(object sender, EventArgs e)
        {
            txt_content.ReadOnly = true;
            con = new SqlConnection(consqlserver);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from guide where gubnumber=" + guidenumber + ";";
            SqlDataReader sread_guide = cmd.ExecuteReader();
            while (sread_guide.Read())
            {
                lbl_title.Text = sread_guide["gudtitle"].ToString().TrimEnd();
                txt_content.Text = sread_guide["gudtext"].ToString().TrimEnd();

            }
            sread_guide.Close();
        }

        private void lbl_title_Click(object sender, EventArgs e)
        {

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_guide_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }
    }
}
