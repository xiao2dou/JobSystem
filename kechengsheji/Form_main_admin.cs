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
    public partial class Form_main_admin : Form
    {
        form1 loginform = null;
        string consqlserver = "Data Source=.;Initial Catalog=test;Integrated Security=True;";//数据库连接语句
        string sql = null; //sql语句
        SqlConnection con = null;  //sql连接对象
        public Form_main_admin(form1 form)
        {
            InitializeComponent();
            loginform = form;
        }

        private void Form_main_admin_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(consqlserver);
            con.Open();

            //page1
            lv_cand.FullRowSelect = true;
            sql = "select * from candidate";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            try
            {
                SqlDataReader sread_cand = cmd.ExecuteReader();
                while (sread_cand.Read())
                {
                    ListViewItem it = new ListViewItem();
                    it.Text = sread_cand["cddusername"].ToString().TrimEnd();
                    it.SubItems.Add(sread_cand["cddname"].ToString().TrimEnd());
                    it.SubItems.Add(sread_cand["cddsex"].ToString().TrimEnd());
                    it.SubItems.Add(sread_cand["cddbirthday"].ToString().TrimEnd());
                    it.SubItems.Add(sread_cand["cddcity"].ToString().TrimEnd());
                    it.SubItems.Add(sread_cand["cddtelnumber"].ToString().TrimEnd());
                    lv_cand.Items.Add(it);
                }
                sread_cand.Close();
            }
            catch(Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }
            //page2
            lv_enterprise.FullRowSelect = true;
            sql = "select * from enterprise";
            cmd = con.CreateCommand();
            cmd.CommandText = sql;
            try
            {
                SqlDataReader sread_enterprise = cmd.ExecuteReader();
                while (sread_enterprise.Read())
                {
                    ListViewItem it = new ListViewItem();
                    it.Text = sread_enterprise["etpusername"].ToString().TrimEnd();
                    it.SubItems.Add(sread_enterprise["etpname"].ToString().TrimEnd());
                    it.SubItems.Add(sread_enterprise["etpemail"].ToString().TrimEnd());
                    it.SubItems.Add(sread_enterprise["etpaddress"].ToString().TrimEnd());
                    it.SubItems.Add(sread_enterprise["etpindustry"].ToString().TrimEnd());
                    lv_enterprise.Items.Add(it);
                }
                sread_enterprise.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }

            //page3
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

            //page4
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

            //page5
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

        private void Form_main_admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginform.Close();
        }

        private void Form_main_admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            con.Close();
        }

        private void lv_cand_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = lv_cand.SelectedItems.Count;
            if (selectCount > 0)
            {
                string candname = lv_cand.SelectedItems[0].Text;
                Form_admin_delete_cand fadc = new Form_admin_delete_cand(candname);
                fadc.Show();

            }
        }

        private void lv_enterprise_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = lv_enterprise.SelectedItems.Count;
            if (selectCount > 0)
            {
                string etpid = lv_enterprise.SelectedItems[0].Text;
                string etpname = lv_enterprise.SelectedItems[0].SubItems[1].Text;
                Form_admin_delete_enterprise fade = new Form_admin_delete_enterprise(etpid,etpname);
                fade.Show();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_admin_edit_zph faez = new Form_admin_edit_zph();
            faez.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_admin_edit_jz faej = new Form_admin_edit_jz();
            faej.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_admin_edit_guide faeg = new Form_admin_edit_guide();
            faeg.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            lv_cand.Items.Clear();
            lv_enterprise.Items.Clear();
            lv_guide.Items.Clear();
            lv_zph.Items.Clear();
            lv_jz.Items.Clear();
            //page1
            lv_cand.FullRowSelect = true;
            sql = "select * from candidate";
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = sql;
            try
            {
                SqlDataReader sread_cand = cmd.ExecuteReader();
                while (sread_cand.Read())
                {
                    ListViewItem it = new ListViewItem();
                    it.Text = sread_cand["cddusername"].ToString().TrimEnd();
                    it.SubItems.Add(sread_cand["cddname"].ToString().TrimEnd());
                    it.SubItems.Add(sread_cand["cddsex"].ToString().TrimEnd());
                    it.SubItems.Add(sread_cand["cddbirthday"].ToString().TrimEnd());
                    it.SubItems.Add(sread_cand["cddcity"].ToString().TrimEnd());
                    it.SubItems.Add(sread_cand["cddtelnumber"].ToString().TrimEnd());
                    lv_cand.Items.Add(it);
                }
                sread_cand.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }
            //page2
            lv_enterprise.FullRowSelect = true;
            sql = "select * from enterprise";
            cmd = con.CreateCommand();
            cmd.CommandText = sql;
            try
            {
                SqlDataReader sread_enterprise = cmd.ExecuteReader();
                while (sread_enterprise.Read())
                {
                    ListViewItem it = new ListViewItem();
                    it.Text = sread_enterprise["etpusername"].ToString().TrimEnd();
                    it.SubItems.Add(sread_enterprise["etpname"].ToString().TrimEnd());
                    it.SubItems.Add(sread_enterprise["etpemail"].ToString().TrimEnd());
                    it.SubItems.Add(sread_enterprise["etpaddress"].ToString().TrimEnd());
                    it.SubItems.Add(sread_enterprise["etpindustry"].ToString().TrimEnd());
                    lv_enterprise.Items.Add(it);
                }
                sread_enterprise.Close();
            }
            catch (Exception msg)
            {
                MessageBox.Show(msg.ToString());
            }

            //page3
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

            //page4
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

            //page5
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

        private void lv_zph_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = lv_zph.SelectedItems.Count;
            if (selectCount > 0)
            {
                int zphnumber = Convert.ToInt32(lv_zph.SelectedItems[0].Text);
                Form_admin_delete_zph fadz = new Form_admin_delete_zph(zphnumber);
                fadz.Show();

            }
        }

        private void lv_jz_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = lv_jz.SelectedItems.Count;
            if (selectCount > 0)
            {
                int jznumber = Convert.ToInt32(lv_jz.SelectedItems[0].Text);
                Form_admin_delete_jz fadj = new Form_admin_delete_jz(jznumber);
                fadj.Show();

            }
        }

        private void lv_guide_DoubleClick(object sender, EventArgs e)
        {
            int selectCount = lv_guide.SelectedItems.Count;
            if (selectCount > 0)
            {
                int guidenumber = Convert.ToInt32(lv_guide.SelectedItems[0].Text);
                Form_admin_delete_guide fadg = new Form_admin_delete_guide(guidenumber);
                fadg.Show();

            }
        }
    }
}
