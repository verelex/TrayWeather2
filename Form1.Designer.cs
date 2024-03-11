namespace TrayWeather2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(671, 298);
            button1.Name = "button1";
            button1.Size = new Size(137, 58);
            button1.TabIndex = 0;
            button1.Text = "Hide";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(63, 37);
            label1.Name = "label1";
            label1.Size = new Size(44, 25);
            label1.TabIndex = 1;
            label1.Text = "Key:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(63, 114);
            label2.Name = "label2";
            label2.Size = new Size(67, 25);
            label2.TabIndex = 2;
            label2.Text = "Город:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(63, 199);
            label3.Name = "label3";
            label3.Size = new Size(241, 25);
            label3.TabIndex = 3;
            label3.Text = "Количество запросов в час:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(63, 274);
            label4.Name = "label4";
            label4.Size = new Size(59, 25);
            label4.TabIndex = 4;
            label4.Text = "label4";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(63, 65);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(446, 31);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(63, 142);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(446, 31);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(63, 227);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(446, 31);
            textBox3.TabIndex = 7;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(541, 37);
            webView21.Name = "webView21";
            webView21.Size = new Size(267, 221);
            webView21.TabIndex = 8;
            webView21.ZoomFactor = 1D;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(820, 368);
            Controls.Add(webView21);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "TrayWeather2";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
    }
}
