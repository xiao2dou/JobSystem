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
    public partial class Form_cand_myjob_info : Form
    {

        string jobname = null;
        string cand_uid = null;
        int jobnumber = 0;

        string consqlserver = "Data Source=.;Initial Catalog=test;Integrated Security=True;";//数据库连接语句
        string sql = null; //sql语句
        SqlConnection con = null;  //sql连接对象
        public Form_cand_myjob_info(string jname,string id)
        {
            InitializeComponent();
            jobname = jname;
            cand_uid = id;
        }

        private void Form_cand_myjob_info_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(consqlserver);
            con.Open();

            sql = "select * from apply a,job j,enterprise e where j.jobname = '" + jobname + "' and a.jobnumber = j.jobnumber and a.cddusername='" + cand_uid + "' and j.etpname = e.etpname";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            SqlDataReader sread = cmd.ExecuteReader();
            while(sread.Read())
            {
                lbletp.Text = sread["etpname"].ToString().TrimEnd();
                lbljob.Text = sread["jobname"].ToString().TrimEnd();
                lblphone.Text = sread["etpemail"].ToString().TrimEnd();
                lbladdr.Text = sread["etpaddress"].ToString().TrimEnd();
                lblwtime.Text = sread["jobwttime"].ToString().TrimEnd();
                lblwaddr.Text = sread["jobwtaddress"].ToString().TrimEnd();
                lblmtime.Text = sread["jobpttime"].ToString().TrimEnd();
                lblmaddr.Text = sread["jobptaddress"].ToString().TrimEnd();
                jobnumber = Convert.ToInt32(sread["jobnumber"].ToString().TrimEnd());

            }
            sread.Close();


        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_cand_myjob_info_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void btn_del_Click(object sender, EventArgs e)
        {
            //sql = "delete from apply where cddusername='" + cand_uid + "' and apply.jobnumber = job.jobnumber and job.jobname='" + jobname + "'";
            sql = "delete from apply where cddusername='" + cand_uid + "' and jobnumber = " + jobnumber + ";";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            MessageBox.Show("撤回成功");
        }
    }
}
