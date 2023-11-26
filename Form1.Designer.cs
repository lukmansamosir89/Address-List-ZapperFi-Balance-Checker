namespace ZapperFiBalanceCheck
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.chromiumWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.chromiumWebBrowser2 = new CefSharp.WinForms.ChromiumWebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.chromiumWebBrowser3 = new CefSharp.WinForms.ChromiumWebBrowser();
            this.chromiumWebBrowser4 = new CefSharp.WinForms.ChromiumWebBrowser();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chromiumWebBrowser1
            // 
            this.chromiumWebBrowser1.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser1.Location = new System.Drawing.Point(12, 62);
            this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
            this.chromiumWebBrowser1.Size = new System.Drawing.Size(1126, 198);
            this.chromiumWebBrowser1.TabIndex = 0;
            this.chromiumWebBrowser1.LoadingStateChanged += new System.EventHandler<CefSharp.LoadingStateChangedEventArgs>(this.chromiumWebBrowser1_LoadingStateChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(453, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "https://zapper.xyz";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(572, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 23);
            this.button3.TabIndex = 9;
            this.button3.Text = "3- Start Tor Proxy and Check Cloudflare";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // chromiumWebBrowser2
            // 
            this.chromiumWebBrowser2.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser2.Location = new System.Drawing.Point(12, 266);
            this.chromiumWebBrowser2.Name = "chromiumWebBrowser2";
            this.chromiumWebBrowser2.Size = new System.Drawing.Size(1126, 189);
            this.chromiumWebBrowser2.TabIndex = 11;
            this.chromiumWebBrowser2.LoadingStateChanged += new System.EventHandler<CefSharp.LoadingStateChangedEventArgs>(this.chromiumWebBrowser2_LoadingStateChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(471, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "1- Start Tor Proxy and Check Cloudflare";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(453, 20);
            this.textBox2.TabIndex = 13;
            this.textBox2.Text = "https://zapper.xyz";
            // 
            // chromiumWebBrowser3
            // 
            this.chromiumWebBrowser3.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser3.Location = new System.Drawing.Point(12, 461);
            this.chromiumWebBrowser3.Name = "chromiumWebBrowser3";
            this.chromiumWebBrowser3.Size = new System.Drawing.Size(1126, 189);
            this.chromiumWebBrowser3.TabIndex = 14;
            this.chromiumWebBrowser3.LoadingStateChanged += new System.EventHandler<CefSharp.LoadingStateChangedEventArgs>(this.chromiumWebBrowser3_LoadingStateChanged);
            // 
            // chromiumWebBrowser4
            // 
            this.chromiumWebBrowser4.ActivateBrowserOnCreation = false;
            this.chromiumWebBrowser4.Location = new System.Drawing.Point(12, 656);
            this.chromiumWebBrowser4.Name = "chromiumWebBrowser4";
            this.chromiumWebBrowser4.Size = new System.Drawing.Size(1126, 189);
            this.chromiumWebBrowser4.TabIndex = 15;
            this.chromiumWebBrowser4.LoadingStateChanged += new System.EventHandler<CefSharp.LoadingStateChangedEventArgs>(this.chromiumWebBrowser4_LoadingStateChanged);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(683, 38);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(455, 20);
            this.textBox3.TabIndex = 20;
            this.textBox3.Text = "https://zapper.xyz";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(471, 36);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "2- Start Tor Proxy and Check Cloudflare";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(683, 14);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(455, 20);
            this.textBox4.TabIndex = 18;
            this.textBox4.Text = "https://zapper.xyz";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(572, 36);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(105, 23);
            this.button4.TabIndex = 17;
            this.button4.Text = "4- Start Tor Proxy and Check Cloudflare";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 865);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.chromiumWebBrowser4);
            this.Controls.Add(this.chromiumWebBrowser3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chromiumWebBrowser2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.chromiumWebBrowser1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Zapper.XYZ Balance Checker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser3;
        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button4;
    }
}

