using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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

    public partial class Form_DataProcess : Form
    {
        GridView gdBom = new GridView();

        public Form_DataProcess()
        {
            InitializeComponent();
        }

        private void btn_DataProcess_Click(object sender, EventArgs e)
        {
            //string filepath = FileUpload1.PostedFile.FileName;
            string filepath="E:\\项目\\csharp\\info.xls";
            ReadExcel(filepath, gdBom);
        }


        public void ReadExcel(string sExcelFile, GridView dgBom)
        {
            DataTable ExcelTable;
            DataSet ds = new DataSet();
            //Excel的连接
            OleDbConnection objConn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + sExcelFile + ";" + "Extended Properties=Excel 8.0;");
            objConn.Open();
            DataTable schemaTable = objConn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);
            string tableName = schemaTable.Rows[0][2].ToString().Trim();//获取 Excel 的表名，默认值是sheet1
            string strSql = "select * from [" + tableName + "]";
            OleDbCommand objCmd = new OleDbCommand(strSql, objConn);
            OleDbDataAdapter myData = new OleDbDataAdapter(strSql, objConn);
            myData.Fill(ds, tableName);//填充数据

            dgBom.DataSource = ds;
            dgBom.DataBind();
            objConn.Close();

            ExcelTable = ds.Tables[tableName];
            int iColums = ExcelTable.Columns.Count;//列数
            int iRows = ExcelTable.Rows.Count;//行数

            //定义二维数组存储 Excel 表中读取的数据
            string[,] storedata = new string[iRows, iColums];

            for (int i = 0; i < ExcelTable.Rows.Count; i++)
            {
                for (int j = 0; j < ExcelTable.Columns.Count; j++)
                {
                    //将Excel表中的数据存储到数组
                    //excel表格中，第一行数据不读入，从第二行读入
                    storedata[i, j] = ExcelTable.Rows[i][j].ToString();

                }
            }

            //richTextBox1.Text = storedata[0,4];

            /*
            int excelBom = 0;//记录表中有用信息的行数，有用信息是指除去表的标题和表的栏目，本例中表的用用信息是从第三行开始
            //确定有用的行数
            for (int k = 2; k < ExcelTable.Rows.Count; k++)
                if (storedata[k, 1] != "")
                    excelBom++;
            if (excelBom == 0)
            {
                Response.Write("<script language=javascript>alert('您导入的表格不合格式！')</script>");
            }
            else
            {
                //LoadDataToDataBase(storedata，excelBom)//该函数主要负责将 storedata 中有用的数据写入到数据库中，在此不是问题的关键省略 
            }
            */
        }

        private void btn_AddCheck_Click(object sender, EventArgs e)
        {
            string add = tb_add.Text;
            string region = tb_region.Text;
            string url="http://api.map.baidu.com/place/v2/search?q="
                      +add
                      +"&region="
                      +region
                      +"&output=json&ak=aKNGBtV5PkndmcPs8MFF3kza";
            string key = GetHtml(url);
           // richTextBox1.Text = key.Length.ToString();

            if (key.Length < 100)
            {
                MessageBox.Show("这个地址不精确或者百度尚无收录此地址！请修改地址！");
            }
            else
            {
                int intlng = key.IndexOf("lng");
                int intlat = key.IndexOf("lat");
                int intadd = key.IndexOf("address");
                string lng = key.Substring(key.IndexOf("lng")+5, key.IndexOf("address") - key.IndexOf("lng")-34);
                string lat = key.Substring(key.IndexOf("lat")+5, key.IndexOf("lng") - key.IndexOf("lat")-24);
                tb_lnglat.Text = lng+ "," + lat;
                //tb_lnglat.Text = lng;
                //tb_lnglat.Text = lat;
            }

            //webBrowser1.Navigate(Application.StartupPath+"\\AddCheck.html");
            //webBrowser1.Document.Write("");
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
    }
}
