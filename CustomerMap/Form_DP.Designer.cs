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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btn_LoadXls = new System.Windows.Forms.Button();
            this.btn_DataProcess = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tb_add = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_region = new System.Windows.Forms.TextBox();
            this.btn_AddCheck = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_lnglat = new System.Windows.Forms.TextBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择xls文件";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(89, 13);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(390, 21);
            this.textBox1.TabIndex = 1;
            // 
            // btn_LoadXls
            // 
            this.btn_LoadXls.Location = new System.Drawing.Point(485, 11);
            this.btn_LoadXls.Name = "btn_LoadXls";
            this.btn_LoadXls.Size = new System.Drawing.Size(36, 22);
            this.btn_LoadXls.TabIndex = 2;
            this.btn_LoadXls.Text = "...";
            this.btn_LoadXls.UseVisualStyleBackColor = true;
            // 
            // btn_DataProcess
            // 
            this.btn_DataProcess.Location = new System.Drawing.Point(527, 11);
            this.btn_DataProcess.Name = "btn_DataProcess";
            this.btn_DataProcess.Size = new System.Drawing.Size(71, 22);
            this.btn_DataProcess.TabIndex = 3;
            this.btn_DataProcess.Text = "数据处理";
            this.btn_DataProcess.UseVisualStyleBackColor = true;
            this.btn_DataProcess.Click += new System.EventHandler(this.btn_DataProcess_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(402, 47);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(146, 50);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
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
            this.label4.Location = new System.Drawing.Point(63, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 11;
            this.label4.Text = "经度纬度";
            // 
            // tb_lnglat
            // 
            this.tb_lnglat.Location = new System.Drawing.Point(116, 60);
            this.tb_lnglat.Name = "tb_lnglat";
            this.tb_lnglat.Size = new System.Drawing.Size(277, 21);
            this.tb_lnglat.TabIndex = 10;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(-1, 146);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(610, 398);
            this.webBrowser1.TabIndex = 12;
            // 
            // Form_DataProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 543);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_lnglat);
            this.Controls.Add(this.btn_AddCheck);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_region);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_add);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btn_DataProcess);
            this.Controls.Add(this.btn_LoadXls);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form_DataProcess";
            this.Text = "数据处理";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_LoadXls;
        private System.Windows.Forms.Button btn_DataProcess;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox tb_add;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_region;
        private System.Windows.Forms.Button btn_AddCheck;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_lnglat;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}