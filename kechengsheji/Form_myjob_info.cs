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
    public partial class Form_myjob_info : Form
    {
        int jobnumber;

        string consqlserver = "Data Source=.;Initial Catalog=test;Integrated Security=True;";//数据库连接语句
        string sql = null; //sql语句
        SqlConnection con = null;  //sql连接对象
        public Form_myjob_info(int number)
        {
            InitializeComponent();
            jobnumber = number;
        }

        private void Form_myjob_info_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(consqlserver);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from job where jobnumber = " + jobnumber + ";";
            SqlDataReader sread = cmd.ExecuteReader();
            while(sread.Read())
            {
                txtname.Text = sread["jobname"].ToString().TrimEnd();
                txtindu.Text = sread["jobindusrty"].ToString().TrimEnd();
                txtdead.Text = sread["deadline"].ToString().TrimEnd();
                txtaddr.Text = sread["jobaddress"].ToString().TrimEnd();
                txtzhaonumber.Text = sread["jobcount"].ToString().TrimEnd();
                txtexperience.Text = sread["jobexperience"].ToString().TrimEnd();
                txtsalary.Text = sread["jobsalary"].ToString().TrimEnd();
                txtdegree.Text = sread["jobdegree"].ToString().TrimEnd();
                txttype.Text = sread["jobtype"].ToString().TrimEnd();
                txtinfo.Text = sread["jobintroduction"].ToString().TrimEnd();
                txtwtime.Text = sread["jobwttime"].ToString().TrimEnd();
                txtwaddr.Text = sread["jobwtaddress"].ToString().TrimEnd();
                txtmtime.Text = sread["jobpttime"].ToString().TrimEnd();
                txtmaddr.Text = sread["jobptaddress"].ToString().TrimEnd();
                txtfadate.Text = sread["issuedate"].ToString().TrimEnd();
            }
            sread.Close();

            txtname.ReadOnly = true;
            txtindu.ReadOnly = true;
            txtdead.ReadOnly = true;
            txtaddr.ReadOnly = true;
            txtzhaonumber.ReadOnly = true;
            txtexperience.ReadOnly = true;
            txtsalary.ReadOnly = true;
            txtdegree.ReadOnly = true;
            txttype.ReadOnly = true;
            txtinfo.ReadOnly = true;
            txtwtime.ReadOnly = true;
            txtwaddr.ReadOnly = true;
            txtmtime.ReadOnly = true;
            txtmaddr.ReadOnly = true;
            txtfadate.ReadOnly = true;

            btn_cancel.Visible = false;
            btn_save.Visible = false;
            btn_edit.Visible = true;

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            txtname.ReadOnly = false;
            txtindu.ReadOnly = false;
            txtdead.ReadOnly = false;
            txtaddr.ReadOnly = false;
            txtzhaonumber.ReadOnly = false;
            txtexperience.ReadOnly = false;
            txtsalary.ReadOnly = false;
            txtdegree.ReadOnly = false;
            txttype.ReadOnly = false;
            txtinfo.ReadOnly = false;
            txtwtime.ReadOnly = false;
            txtwaddr.ReadOnly = false;
            txtmtime.ReadOnly = false;
            txtmaddr.ReadOnly = false;
            txtfadate.ReadOnly = false;

            btn_cancel.Visible = true;
            btn_save.Visible = true;
            btn_edit.Visible = false;

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            int zhaonumber = Convert.ToInt32(txtzhaonumber.Text);
            /*  sql = "update enterprise set etpname='" + txt_name.Text + "',etpnature='" + txt_prop.Text + "',etpindustry='"
                  + txt_indu.Text + "',etpsize='" + txt_size.Text + "',etpemail='" + txt_email.Text + "',etpweb='"
                  + txt_web.Text + "',etpaddress='" + txt_addr.Text + "',etppostcode='" + txt_post.Text + "',etpintroduction='"
                  + txt_info.Text + "' where etpusername='" + name + "';"; */
            sql = "update job set jobname='"+txtname.Text+ "',jobindusrty='"+txtindu.Text+ "',issuedate='"
                +txtfadate.Text+ "',deadline='"+txtdead.Text+ "',jobaddress='"+txtaddr.Text+ "',jobcount="
                +zhaonumber+ ",jobexperience='"+txtexperience.Text+ "',jobsalary='"+txtsalary.Text+ "',jobdegree='"
                +txtdegree.Text+ "',jobtype='"+txttype.Text+ "',jobintroduction='"+txtinfo.Text+ "',jobwttime='"
                +txtwtime.Text+ "',jobwtaddress='"+txtwaddr.Text+ "',jobpttime='"+txtmtime.Text+ "',jobptaddress='"
                +txtmaddr.Text+"' where jobnumber = "+jobnumber;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            MessageBox.Show("修改成功");

            cmd.CommandText = "select * from job where jobnumber = " + jobnumber + ";";
            SqlDataReader sread = cmd.ExecuteReader();
            while (sread.Read())
            {
                txtname.Text = sread["jobname"].ToString().TrimEnd();
                txtindu.Text = sread["jobindusrty"].ToString().TrimEnd();
                txtdead.Text = sread["deadline"].ToString().TrimEnd();
                txtaddr.Text = sread["jobaddress"].ToString().TrimEnd();
                txtzhaonumber.Text = sread["jobcount"].ToString().TrimEnd();
                txtexperience.Text = sread["jobexperience"].ToString().TrimEnd();
                txtsalary.Text = sread["jobsalary"].ToString().TrimEnd();
                txtdegree.Text = sread["jobdegree"].ToString().TrimEnd();
                txttype.Text = sread["jobtype"].ToString().TrimEnd();
                txtinfo.Text = sread["jobintroduction"].ToString().TrimEnd();
                txtwtime.Text = sread["jobwttime"].ToString().TrimEnd();
                txtwaddr.Text = sread["jobwtaddress"].ToString().TrimEnd();
                txtmtime.Text = sread["jobpttime"].ToString().TrimEnd();
                txtmaddr.Text = sread["jobptaddress"].ToString().TrimEnd();
                txtfadate.Text = sread["issuedate"].ToString().TrimEnd();
            }
            sread.Close();


            txtname.ReadOnly = true;
            txtindu.ReadOnly = true;
            txtdead.ReadOnly = true;
            txtaddr.ReadOnly = true;
            txtzhaonumber.ReadOnly = true;
            txtexperience.ReadOnly = true;
            txtsalary.ReadOnly = true;
            txtdegree.ReadOnly = true;
            txttype.ReadOnly = true;
            txtinfo.ReadOnly = true;
            txtwtime.ReadOnly = true;
            txtwaddr.ReadOnly = true;
            txtmtime.ReadOnly = true;
            txtmaddr.ReadOnly = true;
            txtfadate.ReadOnly = true;

            btn_cancel.Visible = false;
            btn_save.Visible = false;
            btn_edit.Visible = true;

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from job where jobnumber = " + jobnumber + ";";
            SqlDataReader sread = cmd.ExecuteReader();
            while (sread.Read())
            {
                txtname.Text = sread["jobname"].ToString().TrimEnd();
                txtindu.Text = sread["jobindusrty"].ToString().TrimEnd();
                txtdead.Text = sread["deadline"].ToString().TrimEnd();
                txtaddr.Text = sread["jobaddress"].ToString().TrimEnd();
                txtzhaonumber.Text = sread["jobcount"].ToString().TrimEnd();
                txtexperience.Text = sread["jobexperience"].ToString().TrimEnd();
                txtsalary.Text = sread["jobsalary"].ToString().TrimEnd();
                txtdegree.Text = sread["jobdegree"].ToString().TrimEnd();
                txttype.Text = sread["jobtype"].ToString().TrimEnd();
                txtinfo.Text = sread["jobintroduction"].ToString().TrimEnd();
                txtwtime.Text = sread["jobwttime"].ToString().TrimEnd();
                txtwaddr.Text = sread["jobwtaddress"].ToString().TrimEnd();
                txtmtime.Text = sread["jobpttime"].ToString().TrimEnd();
                txtmaddr.Text = sread["jobptaddress"].ToString().TrimEnd();
                txtfadate.Text = sread["issuedate"].ToString().TrimEnd();
            }
            sread.Close();

            txtname.ReadOnly = true;
            txtindu.ReadOnly = true;
            txtdead.ReadOnly = true;
            txtaddr.ReadOnly = true;
            txtzhaonumber.ReadOnly = true;
            txtexperience.ReadOnly = true;
            txtsalary.ReadOnly = true;
            txtdegree.ReadOnly = true;
            txttype.ReadOnly = true;
            txtinfo.ReadOnly = true;
            txtwtime.ReadOnly = true;
            txtwaddr.ReadOnly = true;
            txtmtime.ReadOnly = true;
            txtmaddr.ReadOnly = true;
            txtfadate.ReadOnly = true;

            btn_cancel.Visible = false;
            btn_save.Visible = false;
            btn_edit.Visible = true;
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_myjob_info_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql = "delete from apply where jobnumber=" + jobnumber +
                "; delete from invite where jobnumber=" + jobnumber +
                "; delete from result where jobnumber = " + jobnumber +
                "; delete from record where jobnumber = " + jobnumber +
                "; delete from job where jobnumber = " + jobnumber + ";";

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            MessageBox.Show("删除成功 请刷新主页面");
            Close();
        }
    }
}
