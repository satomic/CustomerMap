using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.IO;
using System.Web;
using System.Net;

namespace CustomerMap
{
    public partial class Form_Main : Form
    {
        public string mapPath,
                      key,
                      vers,
                      version="2.0";

        public Form_Main()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true; 
        }

        private void lb_DataProcess_Click(object sender, EventArgs e)
        {
            Form_DataProcess form_DataProcess = new Form_DataProcess();
            form_DataProcess.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                mapPath = folderBrowserDialog.SelectedPath;
                tb_mapPath.Text = mapPath;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (tb_mapPath.Text.Equals(""))
            {
                MessageBox.Show("请选择地图路径！");
            }
            else
            {
                webBrowser1.Navigate(mapPath + "\\qixia1");
                label1.BackColor = Color.Yellow;
                label2.BackColor = Color.White;
                label3.BackColor = Color.White;
                label4.BackColor = Color.White;
                label5.BackColor = Color.White;
                label6.BackColor = Color.White;
                label7.BackColor = Color.White;
                label8.BackColor = Color.White;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (tb_mapPath.Text.Equals(""))
            {
                MessageBox.Show("请选择地图路径！");
            }
            else
            {
                webBrowser1.Navigate(mapPath + "\\qixia2");
                label1.BackColor = Color.Yellow;
                label2.BackColor = Color.Yellow;
                label3.BackColor = Color.White;
                label4.BackColor = Color.White;
                label5.BackColor = Color.White;
                label6.BackColor = Color.White;
                label7.BackColor = Color.White;
                label8.BackColor = Color.White;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            if (tb_mapPath.Text.Equals(""))
            {
                MessageBox.Show("请选择地图路径！");
            }
            else
            {
                webBrowser1.Navigate(mapPath + "\\xuanwu1");
                label1.BackColor = Color.White;
                label2.BackColor = Color.White;
                label3.BackColor = Color.Yellow;
                label4.BackColor = Color.White;
                label5.BackColor = Color.White;
                label6.BackColor = Color.White;
                label7.BackColor = Color.White;
                label8.BackColor = Color.White;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            if (tb_mapPath.Text.Equals(""))
            {
                MessageBox.Show("请选择地图路径！");
            }
            else
            {
                webBrowser1.Navigate(mapPath + "\\xuanwu2");
                label1.BackColor = Color.White;
                label2.BackColor = Color.White;
                label3.BackColor = Color.Yellow;
                label4.BackColor = Color.Yellow;
                label5.BackColor = Color.White;
                label6.BackColor = Color.White;
                label7.BackColor = Color.White;
                label8.BackColor = Color.White;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (tb_mapPath.Text.Equals(""))
            {
                MessageBox.Show("请选择地图路径！");
            }
            else
            {
                webBrowser1.Navigate(mapPath + "\\nanjingjurong1");
                label1.BackColor = Color.White;
                label2.BackColor = Color.White;
                label3.BackColor = Color.White;
                label4.BackColor = Color.White;
                label5.BackColor = Color.Yellow;
                label6.BackColor = Color.White;
                label7.BackColor = Color.White;
                label8.BackColor = Color.White;
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            if (tb_mapPath.Text.Equals(""))
            {
                MessageBox.Show("请选择地图路径！");
            }
            else
            {
                webBrowser1.Navigate(mapPath + "\\nanjingjurong2");
                label1.BackColor = Color.White;
                label2.BackColor = Color.White;
                label3.BackColor = Color.White;
                label4.BackColor = Color.White;
                label5.BackColor = Color.Yellow;
                label6.BackColor = Color.Yellow;
                label7.BackColor = Color.White;
                label8.BackColor = Color.White;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (tb_mapPath.Text.Equals(""))
            {
                MessageBox.Show("请选择地图路径！");
            }
            else
            {
                webBrowser1.Navigate(mapPath + "\\qita1");
                label1.BackColor = Color.White;
                label2.BackColor = Color.White;
                label3.BackColor = Color.White;
                label4.BackColor = Color.White;
                label5.BackColor = Color.White;
                label6.BackColor = Color.White;
                label7.BackColor = Color.Yellow;
                label8.BackColor = Color.White;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            if (tb_mapPath.Text.Equals(""))
            {
                MessageBox.Show("请选择地图路径！");
            }
            else
            {
                webBrowser1.Navigate(mapPath + "\\qita2");
                label1.BackColor = Color.White;
                label2.BackColor = Color.White;
                label3.BackColor = Color.White;
                label4.BackColor = Color.White;
                label5.BackColor = Color.White;
                label6.BackColor = Color.White;
                label7.BackColor = Color.Yellow;
                label8.BackColor = Color.Yellow;
            }
        }

        private void tb_mapPath_TextChanged(object sender, EventArgs e)
        {
            mapPath = tb_mapPath.Text;
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            key = GetHtml("http://satomic.in/map/key.php");
            vers = key.Substring(key.IndexOf("vers") + 5, 3);
            if (vers.Equals(version) == false)
            {
                MessageBox.Show("当前最新版本是" + vers + "请您更新！多谢！");
            }
        }

        public string GetHtml(string url)
        {
            string str = string.Empty;
            try
            {
                WebRequest request = WebRequest.Create(url);
                request.Timeout = 30000;
                request.Headers.Set("Pragma", "no-cache");
                WebResponse response = request.GetResponse();
                Stream streamReceive = response.GetResponseStream();
                Encoding encoding = Encoding.GetEncoding("utf-8");
                StreamReader streamReader = new StreamReader(streamReceive, encoding);
                str = streamReader.ReadToEnd();
                streamReader.Close();
            }
            catch (Exception ex)
            { }
            return str;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("=====如有问题请联系我====\n\n        QQ:1093185216\n       手机:15026630181\n       来自: Satomic SJTU\n\n====================");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (version.Equals(vers))
            {
                MessageBox.Show("当前已经是最新" + version + "版！");
            }
            else
            {
                webBrowser1.Navigate("http://satomic.in/map/download.php");
                label1.BackColor = Color.White;
                label2.BackColor = Color.White;
                label3.BackColor = Color.White;
                label4.BackColor = Color.White;
                label5.BackColor = Color.White;
                label6.BackColor = Color.White;
                label7.BackColor = Color.White;
                label8.BackColor = Color.White;
            }
        }
    }
}
