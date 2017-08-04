namespace TestClient
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.IPBox = new System.Windows.Forms.TextBox();
            this.IpName = new System.Windows.Forms.Label();
            this.PortName = new System.Windows.Forms.Label();
            this.PortBox = new System.Windows.Forms.TextBox();
            this.ConnectBtn = new System.Windows.Forms.Button();
            this.MsgBox = new System.Windows.Forms.TextBox();
            this.SendBox = new System.Windows.Forms.TextBox();
            this.SendBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IPBox
            // 
            this.IPBox.Location = new System.Drawing.Point(47, 37);
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(173, 21);
            this.IPBox.TabIndex = 0;
            this.IPBox.Text = "127.0.0.1";
            // 
            // IpName
            // 
            this.IpName.AutoSize = true;
            this.IpName.Location = new System.Drawing.Point(12, 40);
            this.IpName.Name = "IpName";
            this.IpName.Size = new System.Drawing.Size(29, 12);
            this.IpName.TabIndex = 1;
            this.IpName.Text = "IP：";
            // 
            // PortName
            // 
            this.PortName.AutoSize = true;
            this.PortName.Location = new System.Drawing.Point(255, 40);
            this.PortName.Name = "PortName";
            this.PortName.Size = new System.Drawing.Size(41, 12);
            this.PortName.TabIndex = 3;
            this.PortName.Text = "Port：";
            // 
            // PortBox
            // 
            this.PortBox.Location = new System.Drawing.Point(302, 37);
            this.PortBox.Name = "PortBox";
            this.PortBox.Size = new System.Drawing.Size(173, 21);
            this.PortBox.TabIndex = 2;
            this.PortBox.Text = "2222";
            // 
            // ConnectBtn
            // 
            this.ConnectBtn.Location = new System.Drawing.Point(203, 78);
            this.ConnectBtn.Name = "ConnectBtn";
            this.ConnectBtn.Size = new System.Drawing.Size(75, 23);
            this.ConnectBtn.TabIndex = 4;
            this.ConnectBtn.Text = "连接";
            this.ConnectBtn.UseVisualStyleBackColor = true;
            this.ConnectBtn.Click += new System.EventHandler(this.ConnectBtn_Click);
            // 
            // MsgBox
            // 
            this.MsgBox.Location = new System.Drawing.Point(14, 143);
            this.MsgBox.Multiline = true;
            this.MsgBox.Name = "MsgBox";
            this.MsgBox.ReadOnly = true;
            this.MsgBox.Size = new System.Drawing.Size(488, 208);
            this.MsgBox.TabIndex = 5;
            // 
            // SendBox
            // 
            this.SendBox.Location = new System.Drawing.Point(59, 113);
            this.SendBox.Name = "SendBox";
            this.SendBox.Size = new System.Drawing.Size(173, 21);
            this.SendBox.TabIndex = 6;
            // 
            // SendBtn
            // 
            this.SendBtn.Location = new System.Drawing.Point(238, 111);
            this.SendBtn.Name = "SendBtn";
            this.SendBtn.Size = new System.Drawing.Size(75, 23);
            this.SendBtn.TabIndex = 7;
            this.SendBtn.Text = "发送";
            this.SendBtn.UseVisualStyleBackColor = true;
            this.SendBtn.Click += new System.EventHandler(this.SendBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "内容：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 363);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SendBtn);
            this.Controls.Add(this.SendBox);
            this.Controls.Add(this.MsgBox);
            this.Controls.Add(this.ConnectBtn);
            this.Controls.Add(this.PortName);
            this.Controls.Add(this.PortBox);
            this.Controls.Add(this.IpName);
            this.Controls.Add(this.IPBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.Label IpName;
        private System.Windows.Forms.Label PortName;
        private System.Windows.Forms.TextBox PortBox;
        private System.Windows.Forms.Button ConnectBtn;
        private System.Windows.Forms.TextBox MsgBox;
        private System.Windows.Forms.TextBox SendBox;
        private System.Windows.Forms.Button SendBtn;
        private System.Windows.Forms.Label label1;
    }
}

