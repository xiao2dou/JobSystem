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
    public partial class Form_enterprise_info : Form
    {
        string etp_name = null;
        string cand_uid = null;
        //DataSet ds = new DataSet();  //数据缓存
        string consqlserver = "Data Source=.;Initial Catalog=test;Integrated Security=True;";//数据库连接语句
        //string sql = null; //sql语句
        SqlConnection con = null;  //sql连接对象
        public Form_enterprise_info(string name,string uid)
        {
            InitializeComponent();
            etp_name = name;
            cand_uid = uid;
        }

        private void Form_enterprise_info_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(consqlserver);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from enterprise where etpname = '"+etp_name+"';";
            SqlDataReader sread = cmd.ExecuteReader();
            while(sread.Read())
            {
                lbl_name.Text = sread["etpname"].ToString().TrimEnd();
                lbl_prop.Text = sread["etpnature"].ToString().TrimEnd();
                lbl_indu.Text = sread["etpindustry"].ToString().TrimEnd();
                lbl_size.Text = sread["etpsize"].ToString().TrimEnd();
                lbl_email.Text = sread["etpemail"].ToString().TrimEnd();
                lbl_web.Text = sread["etpweb"].ToString().TrimEnd();
                lbl_post.Text = sread["etppostcode"].ToString().TrimEnd();
                lbl_add.Text = sread["etpaddress"].ToString().TrimEnd();
                lbl_info.Text = sread["etpintroduction"].ToString().TrimEnd();
               // break;
            }
            sread.Close();
            
            lv_zhiwei.FullRowSelect = true;
            
            cmd.CommandText = "select * from job where etpname = '"+etp_name+"';";
            SqlDataReader sread_zhiwei = cmd.ExecuteReader();

            while (sread_zhiwei.Read())
            {
                ListViewItem it = new ListViewItem();
                //string date = sread_zhiwei["jobwttime"].ToString();
                //int index = date.IndexOf("星");
                //date = date.Substring(0, index);
                it.Text = sread_zhiwei["jobname"].ToString().TrimEnd();
                it.SubItems.Add(sread_zhiwei["jobcount"].ToString().TrimEnd());
                it.SubItems.Add(sread_zhiwei["jobexperience"].ToString().TrimEnd());
                it.SubItems.Add(sread_zhiwei["jobdegree"].ToString().TrimEnd());
                it.SubItems.Add(sread_zhiwei["jobsalary"].ToString().TrimEnd());
                it.SubItems.Add(sread_zhiwei["jobwttime"].ToString().TrimEnd());
                it.SubItems.Add(sread_zhiwei["jobwttime"].ToString().TrimEnd());
                it.SubItems.Add(sread_zhiwei["jobintroduction"].ToString().TrimEnd());
                lv_zhiwei.Items.Add(it);
            }
            sread_zhiwei.Close();

        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_enterprise_info_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void lv_zhiwei_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = lv_zhiwei.SelectedItems.Count;
            if (selectCount > 0)
            {
                string zhiweiname = lv_zhiwei.SelectedItems[0].Text;
                Form_enp_zhiwei zhiwei = new Form_enp_zhiwei(zhiweiname,cand_uid);
                zhiwei.Show();

            }
        }

        private void lv_zhiwei_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
