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
    public partial class Form_main_qiuzhi : Form
    {
        string name = null;
        form1 loginform = null;
        DataSet ds = new DataSet();  //数据缓存
        string consqlserver = "Data Source=.;Initial Catalog=test;Integrated Security=True;";//数据库连接语句
        string sql = null; //sql语句
        SqlConnection con = null;  //sql连接对象
        public Form_main_qiuzhi(form1 myform,string n)
        {
            name = n;
            loginform = myform;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label_welcome_Click(object sender, EventArgs e)
        {

        }

        private void Form_main_qiuzhi_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Form_main_qiuzhi_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginform.Close();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form_main_qiuzhi_Load(object sender, EventArgs e)
        {
            label_name.Text = name;
            listView_enterprise.FullRowSelect = true;
            con = new SqlConnection(consqlserver);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from enterprise";
            SqlDataReader sread = cmd.ExecuteReader();
            while(sread.Read())
            {
                ListViewItem it = new ListViewItem();
                it.Text = sread["etpname"].ToString().TrimEnd();
                it.SubItems.Add(sread["etpindustry"].ToString().TrimEnd());
                it.SubItems.Add(sread["etpsize"].ToString().TrimEnd());
                it.SubItems.Add(sread["etpaddress"].ToString().TrimEnd());
                listView_enterprise.Items.Add(it);
            }

            sread.Close();

            listView_zhiwei.FullRowSelect = true;
            cmd.CommandText = "select * from job";
            SqlDataReader sread_zhiwei = cmd.ExecuteReader();
            while (sread_zhiwei.Read())
            {
                try
                {
                    //string date = sread_zhiwei["jobwttime"].ToString().TrimEnd();
                    //int index = date.IndexOf("星");
                    //date = date.Substring(0, index);
                    ListViewItem it = new ListViewItem();
                    it.Text = sread_zhiwei["jobname"].ToString().TrimEnd();
                    it.SubItems.Add(sread_zhiwei["etpname"].ToString().TrimEnd());
                    it.SubItems.Add(sread_zhiwei["jobaddress"].ToString().TrimEnd());
                    it.SubItems.Add(sread_zhiwei["jobexperience"].ToString().TrimEnd());
                    it.SubItems.Add(sread_zhiwei["jobdegree"].ToString().TrimEnd());
                    it.SubItems.Add(sread_zhiwei["jobsalary"].ToString().TrimEnd());
                    it.SubItems.Add(sread_zhiwei["jobwttime"].ToString().TrimEnd());
                    it.SubItems.Add(sread_zhiwei["jobintroduction"].ToString().TrimEnd());
                    listView_zhiwei.Items.Add(it);
                }
                catch(Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                }
            }

            sread_zhiwei.Close();

            cmd.CommandText = "select * from candidate where cddusername='" + name + "';";
            SqlDataReader sread_userinfo = cmd.ExecuteReader();
            while (sread_userinfo.Read())
            {
                try
                {
                    //string date = sread_userinfo["jobwttime"].ToString().TrimEnd();
                    //int index = date.IndexOf("星");
                    //date = date.Substring(0, index);
                    //ListViewItem it = new ListViewItem();
                    //it.Text = sread_userinfo["jobname"].ToString().TrimEnd();
                    //it.SubItems.Add(sread_userinfo["etpname"].ToString().TrimEnd());
                    //it.SubItems.Add(sread_userinfo["jobaddress"].ToString().TrimEnd());
                    //it.SubItems.Add(sread_userinfo["jobexperience"].ToString().TrimEnd());
                    //it.SubItems.Add(sread_userinfo["jobdegree"].ToString().TrimEnd());
                    //it.SubItems.Add(sread_userinfo["jobsalary"].ToString().TrimEnd());
                    //it.SubItems.Add(date);
                    //it.SubItems.Add(sread_userinfo["jobintroduction"].ToString().TrimEnd());

                    txt_name.Text = sread_userinfo["cddname"].ToString().TrimEnd();
                    lbl_gender.Text = sread_userinfo["cddsex"].ToString().TrimEnd();
                    txt_birth.Text = sread_userinfo["cddbirthday"].ToString().TrimEnd();
                    txt_addr.Text = sread_userinfo["cddcity"].ToString().TrimEnd();
                    txt_idcard.Text = sread_userinfo["cddidnumber"].ToString().TrimEnd();
                    txt_phonenumber.Text = sread_userinfo["cddtelnumber"].ToString().TrimEnd();
                    txt_email.Text = sread_userinfo["cddemail"].ToString().TrimEnd();
                    txt_xueli.Text = sread_userinfo["cdddegree"].ToString().TrimEnd();
                    txt_major.Text = sread_userinfo["cddmajor"].ToString().TrimEnd();
                    txt_experience.Text = sread_userinfo["cddexperience"].ToString().TrimEnd();
                    txt_info.Text = sread_userinfo["cddintorduction"].ToString().TrimEnd();
                    txt_school.Text = sread_userinfo["cddschool"].ToString().TrimEnd();
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                }
            }

            sread_userinfo.Close();

            txt_name.ReadOnly = true;
            txt_birth.ReadOnly = true;
            txt_addr.ReadOnly = true;
            txt_idcard.ReadOnly = true;
            txt_phonenumber.ReadOnly = true;
            txt_email.ReadOnly = true;
            txt_xueli.ReadOnly = true;
            txt_major.ReadOnly = true;
            txt_experience.ReadOnly = true;
            txt_info.ReadOnly = true;
            txt_school.ReadOnly = true;
            com_gender.Visible = false;
            btn_cancel.Visible = false;
            btn_save.Visible = false;


            lv_myjob.FullRowSelect = true;
            sql = "select * from apply a,job j where a.jobnumber = j.jobnumber and a.cddusername='" + name + "';";
            cmd.CommandText = sql;
            SqlDataReader sread_myjob = cmd.ExecuteReader();
            
            while(sread_myjob.Read())
            {
                ListViewItem it = new ListViewItem();
                it.Text = sread_myjob["jobname"].ToString().TrimEnd();
                it.SubItems.Add(sread_myjob["etpname"].ToString().TrimEnd());
                it.SubItems.Add(sread_myjob["jobwttime"].ToString().TrimEnd());
                it.SubItems.Add(sread_myjob["jobpttime"].ToString().TrimEnd());
                lv_myjob.Items.Add(it);
            }
            sread_myjob.Close();


            lv_result.FullRowSelect = true;
            sql = "select * from job j,result r where r.cddusername='"+name+"' and r.jobnumber = j.jobnumber";
            cmd.CommandText = sql;
            try
            {
                SqlDataReader sread_result = cmd.ExecuteReader();

                while (sread_result.Read())
                {
                    ListViewItem it = new ListViewItem();
                    it.Text = sread_result["jobname"].ToString().TrimEnd();
                    it.SubItems.Add(sread_result["jobnumber"].ToString().TrimEnd());
                    it.SubItems.Add(sread_result["etpname"].ToString().TrimEnd());
                    it.SubItems.Add(sread_result["result"].ToString().TrimEnd());
                    lv_result.Items.Add(it);
                }
                sread_result.Close();
            }
            catch(Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }



            //page2
            lv_zph.FullRowSelect = true;
            cmd.CommandText = "select * from fair ";
            try
            {
                SqlDataReader sread_fair = cmd.ExecuteReader();

                while (sread_fair.Read())
                {
                    ListViewItem it = new ListViewItem();
                    it.Text = sread_fair["fairnumer"].ToString().TrimEnd();
                    it.SubItems.Add(sread_fair["theme"].ToString().TrimEnd());
                    it.SubItems.Add(sread_fair["fairdate"].ToString().TrimEnd());
                    it.SubItems.Add(sread_fair["fairsize"].ToString().TrimEnd());
                    it.SubItems.Add(sread_fair["fairlocation"].ToString().TrimEnd());
                    it.SubItems.Add(sread_fair["fariintroduction"].ToString().TrimEnd());
                    lv_zph.Items.Add(it);
                }
                sread_fair.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }

            //page3
            lv_jz.FullRowSelect = true;
            cmd.CommandText = "select * from parttimejob ";
            try
            {
                SqlDataReader sread_part = cmd.ExecuteReader();

                while (sread_part.Read())
                {
                    ListViewItem it = new ListViewItem();
                    it.Text = sread_part["ptjnumber"].ToString().TrimEnd();
                    it.SubItems.Add(sread_part["ptjintroduction"].ToString().TrimEnd());
                    it.SubItems.Add(sread_part["ptjaddress"].ToString().TrimEnd());
                    it.SubItems.Add(sread_part["ptjsalary"].ToString().TrimEnd());
                    lv_jz.Items.Add(it);
                }
                sread_part.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }

            //page4
            lv_guide.FullRowSelect = true;
            cmd.CommandText = "select * from guide ";
            try
            {
                SqlDataReader sread_guide = cmd.ExecuteReader();

                while (sread_guide.Read())
                {
                    ListViewItem it = new ListViewItem();
                    it.Text = sread_guide["gubnumber"].ToString().TrimEnd();
                    it.SubItems.Add(sread_guide["gudtitle"].ToString().TrimEnd());
                    it.SubItems.Add(sread_guide["gudtext"].ToString().TrimEnd());
                
                    lv_guide.Items.Add(it);
                }
                sread_guide.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView_enterprise_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = listView_enterprise.SelectedItems.Count;
            if (selectCount > 0)
            {
                string etpname = listView_enterprise.SelectedItems[0].Text;
                Form_enterprise_info etpform = new Form_enterprise_info(etpname,name);
                etpform.Show();

            }
        }

        private void listView_enterprise_Click(object sender, EventArgs e)
        {
            
        }

        private void listView_zhiwei_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView_zhiwei_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = listView_zhiwei.SelectedItems.Count;
            if (selectCount > 0)
            {
                string zhiwei_name = listView_zhiwei.SelectedItems[0].Text;
                Form_enp_zhiwei zhiweiform = new Form_enp_zhiwei(zhiwei_name,name);
                zhiweiform.Show();

            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            txt_name.ReadOnly = false;
            txt_birth.ReadOnly = false;
            txt_addr.ReadOnly = false;
            txt_idcard.ReadOnly = false;
            txt_phonenumber.ReadOnly = false;
            txt_email.ReadOnly = false;
            txt_xueli.ReadOnly = false;
            txt_major.ReadOnly = false;
            txt_experience.ReadOnly = false;
            txt_info.ReadOnly = false;
            txt_school.ReadOnly = false;
            com_gender.Visible = true;
            btn_cancel.Visible = true;
            btn_save.Visible = true;
            lbl_gender.Visible = false;
            btn_edit.Visible = false;
          
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            

            sql = "update candidate set cddname='"+txt_name.Text+"',cddsex = '"+com_gender.Text+"',cddbirthday='"
                +txt_birth.Text+"',cddcity='"+txt_addr.Text+"',cddidnumber='"+txt_idcard.Text+"',cddemail='"
                +txt_email.Text+"',cdddegree='"+txt_xueli.Text+"',cddschool='"+txt_school.Text+"',cddmajor='"
                +txt_major.Text+"',cddexperience='"+txt_experience.Text+"',cddintorduction='"+txt_info.Text+"',cddtelnumber='"
                +txt_phonenumber.Text +"' where cddusername='"+name+"';";
            //SqlCommand cmd = new SqlCommand(sql, con);
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            MessageBox.Show("修改成功");


            cmd.CommandText = "select * from candidate where cddusername='" + name + "';";
            SqlDataReader sread_userinfo = cmd.ExecuteReader();
            while (sread_userinfo.Read())
            {
                try
                {

                    txt_name.Text = sread_userinfo["cddname"].ToString().TrimEnd();
                    lbl_gender.Text = sread_userinfo["cddsex"].ToString().TrimEnd();
                    txt_birth.Text = sread_userinfo["cddbirthday"].ToString().TrimEnd();
                    txt_addr.Text = sread_userinfo["cddcity"].ToString().TrimEnd();
                    txt_idcard.Text = sread_userinfo["cddidnumber"].ToString().TrimEnd();
                    txt_phonenumber.Text = sread_userinfo["cddtelnumber"].ToString().TrimEnd();
                    txt_email.Text = sread_userinfo["cddemail"].ToString().TrimEnd();
                    txt_xueli.Text = sread_userinfo["cdddegree"].ToString().TrimEnd();
                    txt_major.Text = sread_userinfo["cddmajor"].ToString().TrimEnd();
                    txt_experience.Text = sread_userinfo["cddexperience"].ToString().TrimEnd();
                    txt_info.Text = sread_userinfo["cddintorduction"].ToString().TrimEnd();
                    txt_school.Text = sread_userinfo["cddschool"].ToString().TrimEnd();
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                }
            }
            sread_userinfo.Close();

            txt_name.ReadOnly = true;
            txt_birth.ReadOnly = true;
            txt_addr.ReadOnly = true;
            txt_idcard.ReadOnly = true;
            txt_phonenumber.ReadOnly = true;
            txt_email.ReadOnly = true;
            txt_xueli.ReadOnly = true;
            txt_major.ReadOnly = true;
            txt_experience.ReadOnly = true;
            txt_info.ReadOnly = true;
            txt_school.ReadOnly = true;
            com_gender.Visible = false;
            btn_cancel.Visible = false;
            btn_save.Visible = false;
            btn_edit.Visible = true;
            lbl_gender.Visible = true;

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from candidate where cddusername='" + name + "';";
            SqlDataReader sread_userinfo = cmd.ExecuteReader();
            while (sread_userinfo.Read())
            {
                try
                {

                    txt_name.Text = sread_userinfo["cddname"].ToString().TrimEnd();
                    lbl_gender.Text = sread_userinfo["cddsex"].ToString().TrimEnd();
                    txt_birth.Text = sread_userinfo["cddbirthday"].ToString().TrimEnd();
                    txt_addr.Text = sread_userinfo["cddcity"].ToString().TrimEnd();
                    txt_idcard.Text = sread_userinfo["cddidnumber"].ToString().TrimEnd();
                    txt_phonenumber.Text = sread_userinfo["cddtelnumber"].ToString().TrimEnd();
                    txt_email.Text = sread_userinfo["cddemail"].ToString().TrimEnd();
                    txt_xueli.Text = sread_userinfo["cdddegree"].ToString().TrimEnd();
                    txt_major.Text = sread_userinfo["cddmajor"].ToString().TrimEnd();
                    txt_experience.Text = sread_userinfo["cddexperience"].ToString().TrimEnd();
                    txt_info.Text = sread_userinfo["cddintorduction"].ToString().TrimEnd();
                    txt_school.Text = sread_userinfo["cddschool"].ToString().TrimEnd();
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                }
            }
            sread_userinfo.Close();
            txt_name.ReadOnly = true;
            txt_birth.ReadOnly = true;
            txt_addr.ReadOnly = true;
            txt_idcard.ReadOnly = true;
            txt_phonenumber.ReadOnly = true;
            txt_email.ReadOnly = true;
            txt_xueli.ReadOnly = true;
            txt_major.ReadOnly = true;
            txt_experience.ReadOnly = true;
            txt_info.ReadOnly = true;
            txt_school.ReadOnly = true;
            com_gender.Visible = false;
            btn_cancel.Visible = false;
            btn_save.Visible = false;
            btn_edit.Visible = true;
            lbl_gender.Visible = true;
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void lv_guide_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = lv_guide.SelectedItems.Count;
            if (selectCount > 0)
            {
                int guidenumber = Convert.ToInt32( lv_guide.SelectedItems[0].Text);
                Form_guide fg = new Form_guide(guidenumber);
                fg.Show();

            }
        }

        private void lv_myjob_DoubleClick(object sender, EventArgs e)
        {
            
            int selectCount = lv_myjob.SelectedItems.Count;
            if (selectCount > 0)
            {
                //MessageBox.Show("1");
                string jobname = lv_myjob.SelectedItems[0].Text;
                //int guidenumber = Convert.ToInt32(lv_guide.SelectedItems[0].Text);
                Form_cand_myjob_info fcmi = new Form_cand_myjob_info(jobname,name);
                fcmi.Show();

            }
        }

        private void btn_re_Click(object sender, EventArgs e)
        {
            listView_enterprise.Items.Clear();
            lv_guide.Items.Clear();
            lv_jz.Items.Clear();
            lv_myjob.Items.Clear();
            listView_zhiwei.Items.Clear();
            lv_zph.Items.Clear();
            lv_result.Items.Clear();

            label_name.Text = name;
            listView_enterprise.FullRowSelect = true;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from enterprise";
            SqlDataReader sread = cmd.ExecuteReader();
            while (sread.Read())
            {
                ListViewItem it = new ListViewItem();
                it.Text = sread["etpname"].ToString().TrimEnd();
                it.SubItems.Add(sread["etpindustry"].ToString().TrimEnd());
                it.SubItems.Add(sread["etpsize"].ToString().TrimEnd());
                it.SubItems.Add(sread["etpaddress"].ToString().TrimEnd());
                listView_enterprise.Items.Add(it);
            }

            sread.Close();

            listView_zhiwei.FullRowSelect = true;
            cmd.CommandText = "select * from job";
            SqlDataReader sread_zhiwei = cmd.ExecuteReader();
            while (sread_zhiwei.Read())
            {
                try
                {
                    //string date = sread_zhiwei["jobwttime"].ToString().TrimEnd();
                    //int index = date.IndexOf("星");
                    //date = date.Substring(0, index);
                    ListViewItem it = new ListViewItem();
                    it.Text = sread_zhiwei["jobname"].ToString().TrimEnd();
                    it.SubItems.Add(sread_zhiwei["etpname"].ToString().TrimEnd());
                    it.SubItems.Add(sread_zhiwei["jobaddress"].ToString().TrimEnd());
                    it.SubItems.Add(sread_zhiwei["jobexperience"].ToString().TrimEnd());
                    it.SubItems.Add(sread_zhiwei["jobdegree"].ToString().TrimEnd());
                    it.SubItems.Add(sread_zhiwei["jobsalary"].ToString().TrimEnd());
                    it.SubItems.Add(sread_zhiwei["jobwttime"].ToString().TrimEnd());
                    it.SubItems.Add(sread_zhiwei["jobintroduction"].ToString().TrimEnd());
                    listView_zhiwei.Items.Add(it);
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                }
            }

            sread_zhiwei.Close();

            cmd.CommandText = "select * from candidate where cddusername='" + name + "';";
            SqlDataReader sread_userinfo = cmd.ExecuteReader();
            while (sread_userinfo.Read())
            {
                try
                {
                    //string date = sread_userinfo["jobwttime"].ToString().TrimEnd();
                    //int index = date.IndexOf("星");
                    //date = date.Substring(0, index);
                    //ListViewItem it = new ListViewItem();
                    //it.Text = sread_userinfo["jobname"].ToString().TrimEnd();
                    //it.SubItems.Add(sread_userinfo["etpname"].ToString().TrimEnd());
                    //it.SubItems.Add(sread_userinfo["jobaddress"].ToString().TrimEnd());
                    //it.SubItems.Add(sread_userinfo["jobexperience"].ToString().TrimEnd());
                    //it.SubItems.Add(sread_userinfo["jobdegree"].ToString().TrimEnd());
                    //it.SubItems.Add(sread_userinfo["jobsalary"].ToString().TrimEnd());
                    //it.SubItems.Add(date);
                    //it.SubItems.Add(sread_userinfo["jobintroduction"].ToString().TrimEnd());

                    txt_name.Text = sread_userinfo["cddname"].ToString().TrimEnd();
                    lbl_gender.Text = sread_userinfo["cddsex"].ToString().TrimEnd();
                    txt_birth.Text = sread_userinfo["cddbirthday"].ToString().TrimEnd();
                    txt_addr.Text = sread_userinfo["cddcity"].ToString().TrimEnd();
                    txt_idcard.Text = sread_userinfo["cddidnumber"].ToString().TrimEnd();
                    txt_phonenumber.Text = sread_userinfo["cddtelnumber"].ToString().TrimEnd();
                    txt_email.Text = sread_userinfo["cddemail"].ToString().TrimEnd();
                    txt_xueli.Text = sread_userinfo["cdddegree"].ToString().TrimEnd();
                    txt_major.Text = sread_userinfo["cddmajor"].ToString().TrimEnd();
                    txt_experience.Text = sread_userinfo["cddexperience"].ToString().TrimEnd();
                    txt_info.Text = sread_userinfo["cddintorduction"].ToString().TrimEnd();
                    txt_school.Text = sread_userinfo["cddschool"].ToString().TrimEnd();
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.ToString());
                }
            }

            sread_userinfo.Close();

            txt_name.ReadOnly = true;
            txt_birth.ReadOnly = true;
            txt_addr.ReadOnly = true;
            txt_idcard.ReadOnly = true;
            txt_phonenumber.ReadOnly = true;
            txt_email.ReadOnly = true;
            txt_xueli.ReadOnly = true;
            txt_major.ReadOnly = true;
            txt_experience.ReadOnly = true;
            txt_info.ReadOnly = true;
            txt_school.ReadOnly = true;
            com_gender.Visible = false;
            btn_cancel.Visible = false;
            btn_save.Visible = false;


            lv_myjob.FullRowSelect = true;
            sql = "select * from apply a,job j where a.jobnumber = j.jobnumber and a.cddusername='" + name + "';";
            cmd.CommandText = sql;
            SqlDataReader sread_myjob = cmd.ExecuteReader();

            while (sread_myjob.Read())
            {
                ListViewItem it = new ListViewItem();
                it.Text = sread_myjob["jobname"].ToString().TrimEnd();
                it.SubItems.Add(sread_myjob["etpname"].ToString().TrimEnd());
                it.SubItems.Add(sread_myjob["jobwttime"].ToString().TrimEnd());
                it.SubItems.Add(sread_myjob["jobpttime"].ToString().TrimEnd());
                lv_myjob.Items.Add(it);
            }
            sread_myjob.Close();


            lv_result.FullRowSelect = true;
            sql = "select * from job j,result r where r.cddusername='" + name + "' and r.jobnumber = j.jobnumber";
            cmd.CommandText = sql;
            try
            {
                SqlDataReader sread_result = cmd.ExecuteReader();

                while (sread_result.Read())
                {
                    ListViewItem it = new ListViewItem();
                    it.Text = sread_result["jobname"].ToString().TrimEnd();
                    it.SubItems.Add(sread_result["jobnumber"].ToString().TrimEnd());
                    it.SubItems.Add(sread_result["etpname"].ToString().TrimEnd());
                    it.SubItems.Add(sread_result["result"].ToString().TrimEnd());
                    lv_result.Items.Add(it);
                }
                sread_result.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }



            //page2
            lv_zph.FullRowSelect = true;
            cmd.CommandText = "select * from fair ";
            try
            {
                SqlDataReader sread_fair = cmd.ExecuteReader();

                while (sread_fair.Read())
                {
                    ListViewItem it = new ListViewItem();
                    it.Text = sread_fair["fairnumer"].ToString().TrimEnd();
                    it.SubItems.Add(sread_fair["theme"].ToString().TrimEnd());
                    it.SubItems.Add(sread_fair["fairdate"].ToString().TrimEnd());
                    it.SubItems.Add(sread_fair["fairsize"].ToString().TrimEnd());
                    it.SubItems.Add(sread_fair["fairlocation"].ToString().TrimEnd());
                    it.SubItems.Add(sread_fair["fariintroduction"].ToString().TrimEnd());
                    lv_zph.Items.Add(it);
                }
                sread_fair.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }

            //page3
            lv_jz.FullRowSelect = true;
            cmd.CommandText = "select * from parttimejob ";
            try
            {
                SqlDataReader sread_part = cmd.ExecuteReader();

                while (sread_part.Read())
                {
                    ListViewItem it = new ListViewItem();
                    it.Text = sread_part["ptjnumber"].ToString().TrimEnd();
                    it.SubItems.Add(sread_part["ptjintroduction"].ToString().TrimEnd());
                    it.SubItems.Add(sread_part["ptjaddress"].ToString().TrimEnd());
                    it.SubItems.Add(sread_part["ptjsalary"].ToString().TrimEnd());
                    lv_jz.Items.Add(it);
                }
                sread_part.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }

            //page4
            lv_guide.FullRowSelect = true;
            cmd.CommandText = "select * from guide ";
            try
            {
                SqlDataReader sread_guide = cmd.ExecuteReader();

                while (sread_guide.Read())
                {
                    ListViewItem it = new ListViewItem();
                    it.Text = sread_guide["gubnumber"].ToString().TrimEnd();
                    it.SubItems.Add(sread_guide["gudtitle"].ToString().TrimEnd());
                    it.SubItems.Add(sread_guide["gudtext"].ToString().TrimEnd());

                    lv_guide.Items.Add(it);
                }
                sread_guide.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }
        }

        private void lv_result_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = lv_result.SelectedItems.Count;
            if (selectCount > 0)
            {
                int jobnumber = 0;
                jobnumber = Convert.ToInt32(lv_result.SelectedItems[0].SubItems[1].Text);
                Form_isdelete fi = new Form_isdelete(name, jobnumber);
                fi.Show();

            }
        }
    }
}
