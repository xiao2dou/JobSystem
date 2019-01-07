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
    public partial class Form_main_enterprise : Form
    {
        string name = null;
        form1 loginform = null;

        DataSet ds = new DataSet();  //数据缓存
        string consqlserver = "Data Source=.;Initial Catalog=test;Integrated Security=True;";//数据库连接语句
        string sql = null; //sql语句
        SqlConnection con = null;  //sql连接对象
        public Form_main_enterprise(form1 myform,string n)
        {
            InitializeComponent();
            loginform = myform;
            name = n;
        }

        private void txt_size_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form_main_enterprise_Load(object sender, EventArgs e)
        {
            //page1
            label_name.Text = name;
            con = new SqlConnection(consqlserver);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from enterprise where etpusername='" + name + "';";
            SqlDataReader sread_enterprise = cmd.ExecuteReader();
            while(sread_enterprise.Read())
            {
                txt_name.Text = sread_enterprise["etpname"].ToString().TrimEnd();
                txt_prop.Text = sread_enterprise["etpnature"].ToString().TrimEnd();
                txt_indu.Text = sread_enterprise["etpindustry"].ToString().TrimEnd();
                txt_size.Text = sread_enterprise["etpsize"].ToString().TrimEnd();
                txt_email.Text = sread_enterprise["etpemail"].ToString().TrimEnd();
                txt_web.Text = sread_enterprise["etpweb"].ToString().TrimEnd();
                txt_addr.Text = sread_enterprise["etpaddress"].ToString().TrimEnd();
                txt_post.Text = sread_enterprise["etppostcode"].ToString().TrimEnd();
                txt_info.Text = sread_enterprise["etpintroduction"].ToString().TrimEnd();
            }
            sread_enterprise.Close();


            txt_name.ReadOnly = true;
            txt_prop.ReadOnly = true;
            txt_indu.ReadOnly = true;
            txt_size.ReadOnly = true;
            txt_email.ReadOnly = true;
            txt_web.ReadOnly = true;
            txt_addr.ReadOnly = true;
            txt_post.ReadOnly = true;
            txt_info.ReadOnly = true;

            btn_edit.Visible = true;
            btn_save.Visible = false;
            btn_cancel.Visible = false;

            //page2
            lv_cand.FullRowSelect = true;
            cmd.CommandText = "select * from candidate";
            SqlDataReader sread_cand = cmd.ExecuteReader();

            while(sread_cand.Read())
            {
                ListViewItem it = new ListViewItem();
                it.Text = sread_cand["cddusername"].ToString().TrimEnd();
                it.SubItems.Add(sread_cand["cddname"].ToString().TrimEnd());
                it.SubItems.Add(sread_cand["cddcity"].ToString().TrimEnd());
                it.SubItems.Add(sread_cand["cddtelnumber"].ToString().TrimEnd());
                it.SubItems.Add(sread_cand["cdddegree"].ToString().TrimEnd());
                it.SubItems.Add(sread_cand["cddschool"].ToString().TrimEnd());
                it.SubItems.Add(sread_cand["cddmajor"].ToString().TrimEnd());
                lv_cand.Items.Add(it);
            }
            sread_cand.Close();



            //page3
            
            lv_mycand.FullRowSelect = true;
            cmd.CommandText = "select a.cddusername,a.jobnumber,cddname,jobname,cddcity,cddtelnumber,cdddegree,cddschool,cddmajor from apply a,candidate c,job j,enterprise e where j.etpname = e.etpname and j.jobnumber = a.jobnumber and a.cddusername=c.cddusername and e.etpusername='" + name+"';";
            try
            {
                SqlDataReader sread_mycand = cmd.ExecuteReader();
                while (sread_mycand.Read())
                {
                    ListViewItem it = new ListViewItem();
                    
                    it.Text = sread_mycand["cddusername"].ToString().TrimEnd();
                    //MessageBox.Show("2");
                    it.SubItems.Add(sread_mycand["cddname"].ToString().TrimEnd());
                    it.SubItems.Add(sread_mycand["jobname"].ToString().TrimEnd());
                    it.SubItems.Add(sread_mycand["cddcity"].ToString().TrimEnd());
                    it.SubItems.Add(sread_mycand["cddtelnumber"].ToString().TrimEnd());
                    it.SubItems.Add(sread_mycand["cdddegree"].ToString().TrimEnd());
                    it.SubItems.Add(sread_mycand["cddschool"].ToString().TrimEnd());
                    it.SubItems.Add(sread_mycand["cddmajor"].ToString().TrimEnd());
                    it.SubItems.Add(sread_mycand["jobnumber"].ToString().TrimEnd());
                    lv_mycand.Items.Add(it);
                }
                sread_mycand.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }
       
            


            //page5
            string etpname = txt_name.Text;
            lv_myjobs.FullRowSelect = true;
            cmd.CommandText = "select * from job where etpname='"+etpname+"';";
            SqlDataReader sread_myjobs = cmd.ExecuteReader();

            while (sread_myjobs.Read())
            {
                ListViewItem it = new ListViewItem();
                it.Text = sread_myjobs["jobnumber"].ToString().TrimEnd();
                it.SubItems.Add(sread_myjobs["jobname"].ToString().TrimEnd());
                it.SubItems.Add(sread_myjobs["deadline"].ToString().TrimEnd());
                lv_myjobs.Items.Add(it);
            }
            sread_myjobs.Close();

            //page6

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
            catch(Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }

            //page7
            lv_record.FullRowSelect = true;
            cmd.CommandText = "select * from record r,candidate c,job j,enterprise e where e.etpusername='" + name + "' and r.cddusername = c.cddusername and r.jobnumber=j.jobnumber and e.etpname = r.etpname";

            try
            {
                SqlDataReader sread_record = cmd.ExecuteReader();

                while (sread_record.Read())
                {
                    //MessageBox.Show("1");
                    ListViewItem it = new ListViewItem();
                    it.Text = sread_record["cddusername"].ToString().TrimEnd();
                    it.SubItems.Add(sread_record["cddname"].ToString().TrimEnd());
                    it.SubItems.Add(sread_record["jobname"].ToString().TrimEnd());
                    it.SubItems.Add(sread_record["result"].ToString().TrimEnd());
                    it.SubItems.Add(sread_record["jobnumber"].ToString().TrimEnd());
                    lv_record.Items.Add(it);
                }
                sread_record.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }


        }

        private void Form_main_enterprise_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginform.Close();
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            txt_name.ReadOnly = false;
            txt_prop.ReadOnly = false;
            txt_indu.ReadOnly = false;
            txt_size.ReadOnly = false;
            txt_email.ReadOnly = false;
            txt_web.ReadOnly = false;
            txt_addr.ReadOnly = false;
            txt_post.ReadOnly = false;
            txt_info.ReadOnly = false;

            btn_cancel.Visible = true;
            btn_save.Visible = true;
            btn_edit.Visible = false;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            sql = "update enterprise set etpname='" + txt_name.Text + "',etpnature='" + txt_prop.Text + "',etpindustry='"
                + txt_indu.Text + "',etpsize='" + txt_size.Text + "',etpemail='" + txt_email.Text + "',etpweb='"
                + txt_web.Text + "',etpaddress='" + txt_addr.Text + "',etppostcode='" + txt_post.Text + "',etpintroduction='"
                + txt_info.Text + "' where etpusername='" + name + "';";

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            MessageBox.Show("修改成功");

            cmd.CommandText = "select * from enterprise where etpusername='" + name + "';";
            SqlDataReader sread_enterprise = cmd.ExecuteReader();
            while (sread_enterprise.Read())
            {
                txt_name.Text = sread_enterprise["etpname"].ToString().TrimEnd();
                txt_prop.Text = sread_enterprise["etpnature"].ToString().TrimEnd();
                txt_indu.Text = sread_enterprise["etpindustry"].ToString().TrimEnd();
                txt_size.Text = sread_enterprise["etpsize"].ToString().TrimEnd();
                txt_email.Text = sread_enterprise["etpemail"].ToString().TrimEnd();
                txt_web.Text = sread_enterprise["etpweb"].ToString().TrimEnd();
                txt_addr.Text = sread_enterprise["etpaddress"].ToString().TrimEnd();
                txt_post.Text = sread_enterprise["etppostcode"].ToString().TrimEnd();
                txt_info.Text = sread_enterprise["etpintroduction"].ToString().TrimEnd();
            }
            sread_enterprise.Close();

            txt_name.ReadOnly = true;
            txt_prop.ReadOnly = true;
            txt_indu.ReadOnly = true;
            txt_size.ReadOnly = true;
            txt_email.ReadOnly = true;
            txt_web.ReadOnly = true;
            txt_addr.ReadOnly = true;
            txt_post.ReadOnly = true;
            txt_info.ReadOnly = true;

            btn_edit.Visible = true;
            btn_save.Visible = false;
            btn_cancel.Visible = false;







        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandText = "select * from enterprise where etpusername='" + name + "';";
            SqlDataReader sread_enterprise = cmd.ExecuteReader();
            while (sread_enterprise.Read())
            {
                txt_name.Text = sread_enterprise["etpname"].ToString().TrimEnd();
                txt_prop.Text = sread_enterprise["etpnature"].ToString().TrimEnd();
                txt_indu.Text = sread_enterprise["etpindustry"].ToString().TrimEnd();
                txt_size.Text = sread_enterprise["etpsize"].ToString().TrimEnd();
                txt_email.Text = sread_enterprise["etpemail"].ToString().TrimEnd();
                txt_web.Text = sread_enterprise["etpweb"].ToString().TrimEnd();
                txt_addr.Text = sread_enterprise["etpaddress"].ToString().TrimEnd();
                txt_post.Text = sread_enterprise["etppostcode"].ToString().TrimEnd();
                txt_info.Text = sread_enterprise["etpintroduction"].ToString().TrimEnd();
            }
            sread_enterprise.Close();

            txt_name.ReadOnly = true;
            txt_prop.ReadOnly = true;
            txt_indu.ReadOnly = true;
            txt_size.ReadOnly = true;
            txt_email.ReadOnly = true;
            txt_web.ReadOnly = true;
            txt_addr.ReadOnly = true;
            txt_post.ReadOnly = true;
            txt_info.ReadOnly = true;

            btn_edit.Visible = true;
            btn_save.Visible = false;
            btn_cancel.Visible = false;

        }

        private void Form_main_enterprise_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void lv_cand_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = lv_cand.SelectedItems.Count;
            if (selectCount > 0)
            {
                string candname = lv_cand.SelectedItems[0].Text;
                Form_cand_info fci = new Form_cand_info(candname);
                fci.Show();

            }
            
        }

        private void btn_post_Click(object sender, EventArgs e)
        {
            try
            {
                int number = Convert.ToInt32(txtnumber.Text);
                string name = txtname.Text;
                string indu = txtindu.Text;
                string fadate = txtfadate.Text;
                string dead = txtdead.Text;
                string addr = txtaddr.Text;
                int zhaonumber = Convert.ToInt32(txtzhaonumber.Text);
                string experience = txtexperience.Text;
                string salary = txtsalary.Text;


                string degree = txtdegree.Text;
                string type = txttype.Text;
                string ename = txt_name.Text;
                string info = txtinfo.Text;
                string wtime = txtwtime.Text;
                string waddr = txtwaddr.Text;
                string mtime = txtmtime.Text;
                string maddr = txtmaddr.Text;
                sql = "insert into job values(" + number + ",'" + name + "','"
                    + indu + "','" + fadate + "','" + dead + "','"
                    + addr + "'," + zhaonumber + ",'" + experience + "','"
                    + salary + "','" + degree + "','" + type + "','" + info + "','"
                    + wtime + "','" + waddr + "','" + mtime + "','" + maddr + "','"
                    + ename + "');";
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                MessageBox.Show("发布成功");
            }
            catch (Exception msg)
            {
                MessageBox.Show("发布失败 请确保发布信息符合要求");
            }
            
            clear();
        }

        private void clear()
        {
            txtaddr.Text = "";
            txtdead.Text = "";
            txtdegree.Text = "";
            txtexperience.Text = "";
            txtinfo.Text = "";
            txtname.Text = "";
            txttype.Text = "";
            txtnumber.Text = "";
            txtmaddr.Text = "";
            txtmtime.Text = "";
            txtsalary.Text = "";
            txtzhaonumber.Text = "";
            txtwaddr.Text = "";
            txtwtime.Text = "";
            txtindu.Text = "";
            txtfadate.Text = "";

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void lv_myjobs_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = lv_myjobs.SelectedItems.Count;
            if (selectCount > 0)
            {
                int jobnumber  = Convert.ToInt32(lv_myjobs.SelectedItems[0].Text);
                Form_myjob_info fmi = new Form_myjob_info(jobnumber);
                fmi.Show();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lv_cand.Items.Clear();
            lv_mycand.Items.Clear();
            lv_myjobs.Items.Clear();
            lv_zph.Items.Clear();
            lv_record.Items.Clear();
            

            //page1
            label_name.Text = name;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select * from enterprise where etpusername='" + name + "';";
            SqlDataReader sread_enterprise = cmd.ExecuteReader();
            while (sread_enterprise.Read())
            {
                txt_name.Text = sread_enterprise["etpname"].ToString().TrimEnd();
                txt_prop.Text = sread_enterprise["etpnature"].ToString().TrimEnd();
                txt_indu.Text = sread_enterprise["etpindustry"].ToString().TrimEnd();
                txt_size.Text = sread_enterprise["etpsize"].ToString().TrimEnd();
                txt_email.Text = sread_enterprise["etpemail"].ToString().TrimEnd();
                txt_web.Text = sread_enterprise["etpweb"].ToString().TrimEnd();
                txt_addr.Text = sread_enterprise["etpaddress"].ToString().TrimEnd();
                txt_post.Text = sread_enterprise["etppostcode"].ToString().TrimEnd();
                txt_info.Text = sread_enterprise["etpintroduction"].ToString().TrimEnd();
            }
            sread_enterprise.Close();


            txt_name.ReadOnly = true;
            txt_prop.ReadOnly = true;
            txt_indu.ReadOnly = true;
            txt_size.ReadOnly = true;
            txt_email.ReadOnly = true;
            txt_web.ReadOnly = true;
            txt_addr.ReadOnly = true;
            txt_post.ReadOnly = true;
            txt_info.ReadOnly = true;

            btn_edit.Visible = true;
            btn_save.Visible = false;
            btn_cancel.Visible = false;

            //page2
            lv_cand.FullRowSelect = true;
            cmd.CommandText = "select * from candidate";
            SqlDataReader sread_cand = cmd.ExecuteReader();

            while (sread_cand.Read())
            {
                ListViewItem it = new ListViewItem();
                it.Text = sread_cand["cddusername"].ToString().TrimEnd();
                it.SubItems.Add(sread_cand["cddname"].ToString().TrimEnd());
                it.SubItems.Add(sread_cand["cddcity"].ToString().TrimEnd());
                it.SubItems.Add(sread_cand["cddtelnumber"].ToString().TrimEnd());
                it.SubItems.Add(sread_cand["cdddegree"].ToString().TrimEnd());
                it.SubItems.Add(sread_cand["cddschool"].ToString().TrimEnd());
                it.SubItems.Add(sread_cand["cddmajor"].ToString().TrimEnd());
                lv_cand.Items.Add(it);
            }
            sread_cand.Close();



            //page3
            lv_mycand.FullRowSelect = true;
            cmd.CommandText = "select a.cddusername,cddname,jobname,cddcity,cddtelnumber,cdddegree,cddschool,cddmajor from apply a,candidate c,job j,enterprise e where j.etpname = e.etpname and j.jobnumber = a.jobnumber and a.cddusername=c.cddusername and e.etpusername='" + name + "';";
            try
            {
                SqlDataReader sread_mycand = cmd.ExecuteReader();
                while (sread_mycand.Read())
                {
                    ListViewItem it = new ListViewItem();

                    it.Text = sread_mycand["cddusername"].ToString().TrimEnd();
                    //MessageBox.Show("2");
                    it.SubItems.Add(sread_mycand["cddname"].ToString().TrimEnd());
                    it.SubItems.Add(sread_mycand["jobname"].ToString().TrimEnd());
                    it.SubItems.Add(sread_mycand["cddcity"].ToString().TrimEnd());
                    it.SubItems.Add(sread_mycand["cddtelnumber"].ToString().TrimEnd());
                    it.SubItems.Add(sread_mycand["cdddegree"].ToString().TrimEnd());
                    it.SubItems.Add(sread_mycand["cddschool"].ToString().TrimEnd());
                    it.SubItems.Add(sread_mycand["cddmajor"].ToString().TrimEnd());
                    lv_mycand.Items.Add(it);
                }
                sread_mycand.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }




            //page5
            string etpname = txt_name.Text;
            lv_myjobs.FullRowSelect = true;
            cmd.CommandText = "select * from job where etpname='" + etpname + "';";
            SqlDataReader sread_myjobs = cmd.ExecuteReader();

            while (sread_myjobs.Read())
            {
                ListViewItem it = new ListViewItem();
                it.Text = sread_myjobs["jobnumber"].ToString().TrimEnd();
                it.SubItems.Add(sread_myjobs["jobname"].ToString().TrimEnd());
                it.SubItems.Add(sread_myjobs["deadline"].ToString().TrimEnd());
                lv_myjobs.Items.Add(it);
            }
            sread_myjobs.Close();

            //page6

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

            //page7
            lv_record.FullRowSelect = true;
            cmd.CommandText = "select * from record r,candidate c,job j,enterprise e where e.etpusername='" + name + "' and r.cddusername = c.cddusername and r.jobnumber=j.jobnumber and e.etpname = r.etpname";

            try
            {
                SqlDataReader sread_record = cmd.ExecuteReader();

                while (sread_record.Read())
                {
                    //MessageBox.Show("1");
                    ListViewItem it = new ListViewItem();
                    it.Text = sread_record["cddusername"].ToString().TrimEnd();
                    it.SubItems.Add(sread_record["cddname"].ToString().TrimEnd());
                    it.SubItems.Add(sread_record["jobname"].ToString().TrimEnd());
                    it.SubItems.Add(sread_record["result"].ToString().TrimEnd());
                    it.SubItems.Add(sread_record["jobnumber"].ToString().TrimEnd());
                    lv_record.Items.Add(it);
                }
                sread_record.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }


        }

        private void lv_mycand_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = lv_mycand.SelectedItems.Count;
            if (selectCount > 0)
            {
                string candname = lv_mycand.SelectedItems[0].Text;
                string jobname = lv_mycand.SelectedItems[0].SubItems[2].Text;
                int jobnumber = Convert.ToInt32(lv_mycand.SelectedItems[0].SubItems[8].Text);
                string etpname = txt_name.Text;
                Form_enterprise_mycand fem = new Form_enterprise_mycand(candname,jobname,jobnumber,etpname);
                fem.Show();

            }
        }

        private void lv_record_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = lv_record.SelectedItems.Count;
            if (selectCount > 0)
            {
                string candname = lv_record.SelectedItems[0].Text;
                int jobnumber = Convert.ToInt32(lv_record.SelectedItems[0].SubItems[4].Text);
                Form_isdelete_record fir = new Form_isdelete_record(candname, jobnumber);
                fir.Show();

            }
        }
    }
}
