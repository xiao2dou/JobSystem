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
    public partial class Form_enp_zhiwei : Form
    {
        string zhiwei = null;
        string cand_uid = null;


        string consqlserver = "Data Source=.;Initial Catalog=test;Integrated Security=True;";//数据库连接语句
        string sql = null; //sql语句
        SqlConnection con = null;  //sql连接对象
        public Form_enp_zhiwei(string zhi,string name)
        {
            InitializeComponent();
            zhiwei = zhi;
            cand_uid = name;
        }

        private void Form_enp_zhiwei_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(consqlserver);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from job where jobname = '" + zhiwei + "';";
            SqlDataReader sread = cmd.ExecuteReader();
            while (sread.Read())
            {
                try
                {
                    //string date = sread["issuedate"].ToString().TrimEnd();
                    //int index = date.IndexOf("星");
                    //date = date.Substring(0, index);
                    //lbl_fadate.Text = date;
                    //date = sread["deadline"].ToString().TrimEnd();
                    //index = date.IndexOf("星");
                    //date = date.Substring(0, index);
                    //lbl_dead.Text = date;
                    //date = sread["jobwttime"].ToString().TrimEnd();
                    //index = date.IndexOf("星");
                    //date = date.Substring(0, index);
                    //lbl_wdate.Text = date;
                    //date = sread["jobpttime"].ToString().TrimEnd();
                    //index = date.IndexOf("星");
                    //date = date.Substring(0, index);
                    //lbl_mdate.Text = date;
                    lbl_name.Text = sread["jobname"].ToString().TrimEnd();
                    lbl_indu.Text = sread["jobindusrty"].ToString().TrimEnd();
                    lbl_dead.Text = sread["deadline"].ToString().TrimEnd();
                    lbl_add.Text = sread["jobaddress"].ToString().TrimEnd();
                    lbl_count.Text = sread["jobcount"].ToString().TrimEnd();
                    lbl_exp.Text = sread["jobexperience"].ToString().TrimEnd();
                    lbl_salary.Text = sread["jobsalary"].ToString().TrimEnd();
                    lbl_degree.Text = sread["jobdegree"].ToString().TrimEnd();
                    lbl_type.Text = sread["jobtype"].ToString().TrimEnd();
                    lbl_info.Text = sread["jobintroduction"].ToString().TrimEnd();
                    lbl_wdate.Text = sread["jobwttime"].ToString().TrimEnd();
                    lbl_wspace.Text = sread["jobwtaddress"].ToString().TrimEnd();
                    lbl_mdate.Text = sread["jobpttime"].ToString().TrimEnd();
                    lbl_mspace.Text = sread["jobptaddress"].ToString().TrimEnd();
                    lbl_enpname.Text = sread["etpname"].ToString().TrimEnd();
                    lbl_fadate.Text = sread["issuedate"].ToString().TrimEnd();
                }
                catch(Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                }
  
            }
            sread.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_enp_zhiwei_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void btn_pass_Click(object sender, EventArgs e)
        {
            string enp_name = lbl_enpname.Text;
            int jobnumber = 0;
            sql = "select jobnumber from job where jobname='" + zhiwei + "' and etpname='" + enp_name + "'";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            SqlDataReader sread_jobnumber = cmd.ExecuteReader();
            while(sread_jobnumber.Read())
            {
                jobnumber = Convert.ToInt32(sread_jobnumber["jobnumber"].ToString().TrimEnd());
            }
            sread_jobnumber.Close();


            sql = "select * from apply where cddusername='" + cand_uid + "' and jobnumber=" + jobnumber + ";";
            cmd.CommandText = sql;
            SqlDataReader sread_check = cmd.ExecuteReader();
            if(sread_check.Read())
            {
                MessageBox.Show("投递失败，您已向该公司该职位投递过简历 请勿重复投递");
                sread_check.Close();
                return;
            }
            else
            {
                sread_check.Close();
                sql = "insert into apply(cddusername,jobnumber) values('" + cand_uid + "'," + jobnumber + ");";
                cmd.CommandText = sql;
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("投递成功,请刷新窗口");
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                }
            }


            
            
        }
    }
}
