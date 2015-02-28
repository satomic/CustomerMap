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
        public string html1_1000,
                      html1_450,
                      htmladd,
                      html2,
                      htmllnglat,
                      html3,
                      htmlfull,

                      AppPath = Application.StartupPath,
                      xlsPath,
                      outputPath,
                      outputFileName,
                      badPath,

                      tempLine,

                      key,
                      cvt1,
                      cvt2,
                      cvt3,
                      cvt4,
                      
                      lng,
                      lat,
                      name;

        public int badCounter = 0;
                        

        public Form_DataProcess()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true; 
        }

        private void btn_DataProcess_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(outputPath+"\\"+outputFileName))
            {
                Directory.CreateDirectory(outputPath+"\\"+outputFileName);
            }
            //string filepath = FileUpload1.PostedFile.FileName;
            //string filepath="C:\\Users\\satomic\\Desktop\\test.xls";
            string filepath = xlsPath;
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

            CreateDocs(storedata, "", "");

            //richTextBox1.Text = storedata[0,4];
            
        }

        private void btn_AddCheck_Click(object sender, EventArgs e)
        {
            string add = tb_add.Text;
            string region = tb_region.Text;
            
            //http://api.map.baidu.com/place/v2/search?q=&region=&output=json&ak=aKNGBtV5PkndmcPs8MFF3kza

            getBaiduInfo(true,add, region, ref lng, ref lat, ref name);
            tb_lnglat.Text = lng + "," + lat;
            lb_FeedbackName.Text = name;

            ReadTXT(AppPath + "\\temp\\1-450", ref html1_450);
            ReadTXT(AppPath + "\\temp\\2", ref html2);
            ReadTXT(AppPath + "\\temp\\3", ref html3);

            htmlfull = html1_450 
                    + "{title:\"\",point:\""
                    + lng+ "," + lat
                    + "\",address:\""
                    + tb_region.Text + tb_add.Text
                    +"\",tel:\"无\"}," 
                    + html2
                    + lng + "," + lat 
                    + html3;
            CreateTempHTML(AppPath + "\\temp\\temp", htmlfull);

            webBrowser1.Navigate(AppPath+"\\temp\\temp");
        }

        public Boolean getBaiduInfo(Boolean messageBoxEnable, string add, string region, ref string lng, ref string lat, ref string name)
        {
            string url = "http://api.map.baidu.com/place/v2/search?q="
                     + add
                     + "&region="
                     + region
                     + "&output=xml&ak=aKNGBtV5PkndmcPs8MFF3kza";
            string key = GetHtml(url);

            if (key.Contains("location") == false)
            {
                if (messageBoxEnable)
                {
                    MessageBox.Show("这个地址不精确或者百度尚无收录此地址！请修改地址！");
                }
                return false;
            }
            else
            {
                int intlng1 = key.IndexOf("lng");
                int intlng2 = key.IndexOf("/lng");
                int intlat1 = key.IndexOf("lat");
                int intlat2 = key.IndexOf("/lat");
                int intname1 = key.IndexOf("name");
                int intname2 = key.IndexOf("/name");

                lng = key.Substring(intlng1 + 4, intlng2 - intlng1 - 5);
                lat = key.Substring(intlat1 + 4, intlat2 - intlat1 - 5);
                name = key.Substring(intname1 + 5, intname2 - intname1 - 6);
                return true;
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

        public void CreateTempHTML(string path, string HTMLdoc)
        {
            // 判断文件是否存在，不存在则创建，否则读取值显示到窗体
            //string HTMLurl=Application.StartupPath+"\\"+name+".txt";
            //string HTMLurl=path+"\\"+name;
            if (!File.Exists(path))
            {
                /*
                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs);
                //sw.WriteLine(this.textBox3.Text.Trim() + "+" + this.textBox4.Text);//开始写入值
                sw.Write(HTMLdoc);
                sw.Close();
                fs.Close();
                */

                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);//创建写入文件
                fs.Close();

                StreamWriter sw = new StreamWriter(path, true, Encoding.GetEncoding("UTF-8"));
                sw.Write(HTMLdoc);
                sw.Close();
                

            }
            else
            {
                //FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write);
                StreamWriter sw = new StreamWriter(path, true, Encoding.GetEncoding("UTF-8"));
                //StreamWriter sw = new StreamWriter(fs);
                //sw.WriteLine(this.textBox3.Text.Trim() + "+" + this.textBox4.Text);//开始写入值
                sw.Write(HTMLdoc);
                sw.Close();
                //fs.Close();
            }
        }

        public void ReadTXT(string path, ref string value)
        {
            StreamReader sr = File.OpenText(path);//path是你的txt文件的路径
            value = sr.ReadToEnd();
            sr.Close();
        }

        /*
         * 
         * 
        */
        public void CreateDocs(string[,] data, string outputPath, string folderName)
        {
            badCounter = 0;
            int row = data.GetLength(0);//行数
            int col = data.GetLength(1);//列数
            string path = AppPath + "\\temp\\";

            CheckClearTemp(path,"qixia1");
            CheckClearTemp(path, "xuanwu1");
            CheckClearTemp(path, "nanjingjurong1");
            CheckClearTemp(path, "qita1");

            CheckClearTemp(path, "qixia2");
            CheckClearTemp(path, "xuanwu2");
            CheckClearTemp(path, "nanjingjurong2");
            CheckClearTemp(path, "qita2");

            badPath=this.outputPath + "\\" + outputFileName+"\\";
            CheckClearTemp(badPath, "badInfoLists.txt");

            progressBar1.Maximum = row;
            progressBar1.Minimum = 0;

            btn_DataProcess.Enabled = false;
            for (int i = 0; i < row + 1; i++)
            {
                //字符串预处理，删除\n，防止出现bug
                for (int j = 0; j < col; j++)
                {
                    if (i < row)
                    {
                        data[i, j].Replace("\n", "");
                    }
                }

                progressBar1.Value = i;

                if (i == row)
                {
                    MessageBox.Show("数据处理完成！\n共"+row+"组数据\n有"+badCounter+"组数据无效！\n请在输出目录中查看badInfoLists.txt文件");
                    btn_DataProcess.Enabled = true;
                    break;
                }
                
                string title1 = "";
                string title2 = data[i, 0] + ",顾问：" + data[i, 3] + ",买方：" + data[i, 4] + ",地址：" + data[i, 8];
                if (getBaiduInfo(false,data[i, 8], data[i, 5], ref lng, ref lat, ref name) == false)
                {
                    //错误处理操作
                    badCounter++;
                    string badInfo = "无结果！ 编号：" + data[i, 0] + " 区域：" + data[i, 5] + data[i, 6] + " 地址：" + data[i, 8];
                    AppendBad(badPath+"badInfoLists.txt", badInfo);
                    continue;
                }
                else
                {
                    if (data[i, 5].Equals("南京市"))
                    {
                        if (data[i, 6].Equals("栖霞区"))
                        {
                            //1栖霞区
                            AppendDocs("qixia1", title1, lng + "," + lat, data[i, 8]);
                            AppendDocs("qixia2", title2, lng + "," + lat, data[i, 8]);
                        }
                        else if (data[i, 6].Equals("玄武区"))
                        {
                            if (cvt1.Equals("1"))
                            {
                                //2玄武区
                                AppendDocs("xuanwu1", title1, lng + "," + lat, data[i, 8]);
                                AppendDocs("xuanwu2", title2, lng + "," + lat, data[i, 8]);
                            }
                        }
                        else
                        {
                            if (cvt1.Equals("1"))
                            {
                                //3南京句容
                                AppendDocs("nanjingjurong1", title1, lng + "," + lat, data[i, 8]);
                                AppendDocs("nanjingjurong2", title2, lng + "," + lat, data[i, 8]);
                            }
                        }
                    }
                    else if (data[i, 5].Equals("句容市"))
                    {
                        if (cvt1.Equals("1"))
                        {
                            //3南京句容
                            AppendDocs("nanjingjurong1", title1, lng + "," + lat, data[i, 8]);
                            AppendDocs("nanjingjurong2", title2, lng + "," + lat, data[i, 8]);
                        }
                    }
                    else
                    {
                        if (cvt1.Equals("1"))
                        {
                            //4其他
                            AppendDocs("qita1", title1, lng + "," + lat, data[i, 8]);
                            AppendDocs("qita2", title2, lng + "," + lat, data[i, 8]);
                        }
                    }

                }
    
            }

            ReadTXT(AppPath + "\\temp\\1-1000", ref html1_1000);
            ReadTXT(AppPath + "\\temp\\2", ref html2);
            ReadTXT(AppPath + "\\temp\\3", ref html3);

            CreateLastHtml("nanjingjurong1");
            CreateLastHtml("nanjingjurong2");
            CreateLastHtml("qixia1");
            CreateLastHtml("qixia2");
            CreateLastHtml("xuanwu1");
            CreateLastHtml("xuanwu2");
            CreateLastHtml("qita1");
            CreateLastHtml("qita2");
        }

        public void CreateLastHtml(string name)
        {
            ReadTXT(AppPath + "\\temp\\"+name, ref tempLine);
            htmlfull = html1_1000
                   + tempLine
                   + html2
                   + "118.802962,32.064792"
                   + html3;
            CreateTempHTML(badPath + name, htmlfull);
        }

        public void CheckClearTemp(string path,string fileName)
        {
            
            if (!File.Exists(path))
            {
                FileStream fs = new FileStream(path+fileName, FileMode.Create, FileAccess.Write);//创建写入文件 
                fs.Seek(0, SeekOrigin.Begin);
                fs.SetLength(0);

                //StreamWriter sw = new StreamWriter(fs);
                //sw.Write("");
                //sw.Close();
                fs.Close();
            }
            else
            {
                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write);
                fs.Seek(0, SeekOrigin.Begin);
                fs.SetLength(0);
                //StreamWriter sw = new StreamWriter(fs);
                //sw.Write("");
                //sw.Close();
                fs.Close();
            }
        }

        public void AppendDocs(string fileName, string title, string lnglat, string address)
        {
            string path = AppPath + "\\temp\\" + fileName;
            if (!File.Exists(path))
            {

                FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);//创建写入文件 
                StreamWriter sw = new StreamWriter(fs);
                string line = "{title:\""
                           + title
                           + "\",point:\""
                           + lnglat
                           + "\",address:\""
                           + address
                           + "\",tel:\"无\"},";

                sw.WriteLine(line);
                sw.Close();
                fs.Close();

            }
            else
            {
                //FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write);
                StreamWriter sw = new StreamWriter(path,true,Encoding.GetEncoding("UTF-8"));
                string line = "{title:\""
                           + title
                           + "\",point:\""
                           + lnglat
                           + "\",address:\""
                           + address
                           + "\",tel:\"无\"},";
                sw.WriteLine(line);
                sw.Close();
                //fs.Close();
            }
        }

        public void AppendBad(string path, string badInfo)
        {
            StreamWriter sw = new StreamWriter(path, true, Encoding.GetEncoding("UTF-8"));
            sw.WriteLine(badInfo);
            sw.Close();
        }

        private void btn_LoadXls_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog { Filter = "Excel文件(*.xls)|*.xls" };
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //OK表示按下了“打开”
            {
                string safeFileName = openFileDialog1.SafeFileName;
                FileInfo fileInfo = new FileInfo(safeFileName);
                xlsPath = System.IO.Path.GetDirectoryName(openFileDialog1.FileNames[0])+"\\"+safeFileName;
                tb_xlsPath.Text = xlsPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                outputPath = folderBrowserDialog.SelectedPath;
                tb_outputPath.Text = outputPath;
            }
        }

        private void tb_folderName_TextChanged(object sender, EventArgs e)
        {
            outputFileName = tb_folderName.Text;
        }

        private void Form_DataProcess_Load(object sender, EventArgs e)
        {
            key = GetHtml("http://satomic.in/map/key.php");
            cvt1 = key.Substring(key.IndexOf("cvt1") + 5, 1);
            cvt2 = key.Substring(key.IndexOf("cvt2") + 5, 1);
            cvt3 = key.Substring(key.IndexOf("cvt3") + 5, 1);
            cvt4 = key.Substring(key.IndexOf("cvt4") + 5, 1);

            if (cvt1.Equals("0"))
            {
                MessageBox.Show("此为试用版\n仅仅支持栖霞区数据处理\n如需完整版，请。。。");
            }
        }  
    }
}
