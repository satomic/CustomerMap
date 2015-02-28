namespace CustomerMap
{
    partial class Form_DataProcess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_DataProcess));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tb_add = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_region = new System.Windows.Forms.TextBox();
            this.btn_AddCheck = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_lnglat = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.lb_FeedbackName = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_xlsPath = new System.Windows.Forms.TextBox();
            this.btn_LoadXls = new System.Windows.Forms.Button();
            this.btn_DataProcess = new System.Windows.Forms.Button();
            this.tb_outputPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_folderName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(410, 441);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(146, 50);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // tb_add
            // 
            this.tb_add.Location = new System.Drawing.Point(65, 105);
            this.tb_add.Name = "tb_add";
            this.tb_add.Size = new System.Drawing.Size(277, 21);
            this.tb_add.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "检索地址";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "检索区域";
            // 
            // tb_region
            // 
            this.tb_region.Location = new System.Drawing.Point(402, 105);
            this.tb_region.Name = "tb_region";
            this.tb_region.Size = new System.Drawing.Size(119, 21);
            this.tb_region.TabIndex = 7;
            // 
            // btn_AddCheck
            // 
            this.btn_AddCheck.Location = new System.Drawing.Point(527, 103);
            this.btn_AddCheck.Name = "btn_AddCheck";
            this.btn_AddCheck.Size = new System.Drawing.Size(71, 22);
            this.btn_AddCheck.TabIndex = 9;
            this.btn_AddCheck.Text = "地址验证";
            this.btn_AddCheck.UseVisualStyleBackColor = true;
            this.btn_AddCheck.Click += new System.EventHandler(this.btn_AddCheck_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(71, 457);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "经度纬度";
            this.label4.Visible = false;
            // 
            // tb_lnglat
            // 
            this.tb_lnglat.Location = new System.Drawing.Point(124, 454);
            this.tb_lnglat.Name = "tb_lnglat";
            this.tb_lnglat.Size = new System.Drawing.Size(277, 21);
            this.tb_lnglat.TabIndex = 10;
            this.tb_lnglat.Visible = false;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(-1, 131);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(610, 413);
            this.webBrowser1.TabIndex = 12;
            // 
            // lb_FeedbackName
            // 
            this.lb_FeedbackName.AutoSize = true;
            this.lb_FeedbackName.Font = new System.Drawing.Font("宋体", 20F);
            this.lb_FeedbackName.Location = new System.Drawing.Point(84, 150);
            this.lb_FeedbackName.Name = "lb_FeedbackName";
            this.lb_FeedbackName.Size = new System.Drawing.Size(0, 27);
            this.lb_FeedbackName.TabIndex = 13;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(65, 67);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(456, 21);
            this.progressBar1.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择文件";
            // 
            // tb_xlsPath
            // 
            this.tb_xlsPath.Location = new System.Drawing.Point(65, 13);
            this.tb_xlsPath.Name = "tb_xlsPath";
            this.tb_xlsPath.Size = new System.Drawing.Size(414, 21);
            this.tb_xlsPath.TabIndex = 1;
            // 
            // btn_LoadXls
            // 
            this.btn_LoadXls.Location = new System.Drawing.Point(485, 11);
            this.btn_LoadXls.Name = "btn_LoadXls";
            this.btn_LoadXls.Size = new System.Drawing.Size(36, 22);
            this.btn_LoadXls.TabIndex = 2;
            this.btn_LoadXls.Text = "...";
            this.btn_LoadXls.UseVisualStyleBackColor = true;
            this.btn_LoadXls.Click += new System.EventHandler(this.btn_LoadXls_Click);
            // 
            // btn_DataProcess
            // 
            this.btn_DataProcess.Font = new System.Drawing.Font("宋体", 15F);
            this.btn_DataProcess.Location = new System.Drawing.Point(527, 11);
            this.btn_DataProcess.Name = "btn_DataProcess";
            this.btn_DataProcess.Size = new System.Drawing.Size(71, 77);
            this.btn_DataProcess.TabIndex = 3;
            this.btn_DataProcess.Text = "数据处理";
            this.btn_DataProcess.UseVisualStyleBackColor = true;
            this.btn_DataProcess.Click += new System.EventHandler(this.btn_DataProcess_Click);
            // 
            // tb_outputPath
            // 
            this.tb_outputPath.Location = new System.Drawing.Point(213, 40);
            this.tb_outputPath.Name = "tb_outputPath";
            this.tb_outputPath.Size = new System.Drawing.Size(266, 21);
            this.tb_outputPath.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(157, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 15;
            this.label6.Text = "输出路径";
            // 
            // tb_folderName
            // 
            this.tb_folderName.Location = new System.Drawing.Point(65, 40);
            this.tb_folderName.Name = "tb_folderName";
            this.tb_folderName.Size = new System.Drawing.Size(83, 21);
            this.tb_folderName.TabIndex = 16;
            this.tb_folderName.TextChanged += new System.EventHandler(this.tb_folderName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "档案名称";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "当前进度";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(485, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 22);
            this.button1.TabIndex = 20;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_DataProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 543);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_folderName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tb_outputPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_lnglat);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.lb_FeedbackName);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.btn_AddCheck);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_region);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_add);
            this.Controls.Add(this.btn_DataProcess);
            this.Controls.Add(this.btn_LoadXls);
            this.Controls.Add(this.tb_xlsPath);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_DataProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据处理";
            this.Load += new System.EventHandler(this.Form_DataProcess_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox tb_add;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_region;
        private System.Windows.Forms.Button btn_AddCheck;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_lnglat;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label lb_FeedbackName;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_xlsPath;
        private System.Windows.Forms.Button btn_LoadXls;
        private System.Windows.Forms.Button btn_DataProcess;
        private System.Windows.Forms.TextBox tb_outputPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_folderName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
    }
}