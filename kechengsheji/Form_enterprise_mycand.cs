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
    public partial class Form_enterprise_mycand : Form
    {

        string name = null;
        string jobname = null;
        string etpname = null;
        int jobnumber = 0;
        //DataSet ds = new DataSet();  //数据缓存
        string consqlserver = "Data Source=.;Initial Catalog=test;Integrated Security=True;";//数据库连接语句
        string sql = null; //sql语句
        SqlConnection con = null;  //sql连接对象
        public Form_enterprise_mycand(string n,string jn,int number,string en)
        {
            InitializeComponent();
            name = n;
            jobname = jn;
            jobnumber = number;
            etpname = en;
            
        }

        private void Form_enterprise_mycand_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(consqlserver);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from candidate where cddusername = '" + name + "';";
            SqlDataReader sread_cand = cmd.ExecuteReader();
            while (sread_cand.Read())
            {
                lbl_name.Text = sread_cand["cddname"].ToString().TrimEnd();
                lbl_gender.Text = sread_cand["cddsex"].ToString().TrimEnd();
                lbl_birth.Text = sread_cand["cddbirthday"].ToString().TrimEnd();
                lbl_addr.Text = sread_cand["cddcity"].ToString().TrimEnd();
                lbl_phonenumber.Text = sread_cand["cddtelnumber"].ToString().TrimEnd();
                lbl_degree.Text = sread_cand["cdddegree"].ToString().TrimEnd();
                lbl_school.Text = sread_cand["cddschool"].ToString().TrimEnd();
                lbl_major.Text = sread_cand["cddmajor"].ToString().TrimEnd();
                lbl_experience.Text = sread_cand["cddexperience"].ToString().TrimEnd();
                lbl_info.Text = sread_cand["cddintorduction"].ToString().TrimEnd();
                lbl_email.Text = sread_cand["cddemail"].ToString().TrimEnd();
            }
            lbl_target.Text = jobname;
            sread_cand.Close();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_enterprise_mycand_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void btn_refuse_Click(object sender, EventArgs e)
        {
            string result = "拒绝聘用";
            sql = "insert into result values('" + name + "'," + jobnumber + ",'" + etpname + "','"+result+"');"+
                "insert into record values('" + name + "', " + jobnumber + ", '" + etpname + "', '"+result+"'); ";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            sql = "delete from apply where cddusername='" + name + "' and jobnumber=" + jobnumber + ";";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            MessageBox.Show("拒绝成功 ,请刷新主窗口");
            Close();


        }

        private void btn_py_Click(object sender, EventArgs e)
        {
            string result = "聘用";
            sql = "insert into result values('" + name + "'," + jobnumber + ",'" + etpname + "','" + result + "');"+
                "insert into record values('" + name + "', " + jobnumber + ", '" + etpname + "', '" + result + "'); ";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            sql = "delete from apply where cddusername='" + name + "' and jobnumber=" + jobnumber + ";";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            MessageBox.Show("聘用成功 ,请刷新主窗口");
            Close();
        }
    }
}
