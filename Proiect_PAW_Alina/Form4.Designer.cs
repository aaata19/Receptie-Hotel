namespace Proiect_PAW
{
    partial class Form4
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
            this.tbID = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.tbLei = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.tbEUR = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EUR = new System.Windows.Forms.Label();
            this.tbUSD = new System.Windows.Forms.TextBox();
            this.lbUSD = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID Client";
            // 
            // tbID
            // 
            this.tbID.Location = new System.Drawing.Point(142, 71);
            this.tbID.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(112, 26);
            this.tbID.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.Location = new System.Drawing.Point(357, 59);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 47);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cauta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbLei
            // 
            this.tbLei.Location = new System.Drawing.Point(142, 151);
            this.tbLei.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbLei.Name = "tbLei";
            this.tbLei.Size = new System.Drawing.Size(112, 26);
            this.tbLei.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.Location = new System.Drawing.Point(610, 480);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(122, 69);
            this.button2.TabIndex = 4;
            this.button2.Text = "Inapoi";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbEUR
            // 
            this.tbEUR.Location = new System.Drawing.Point(142, 231);
            this.tbEUR.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbEUR.Name = "tbEUR";
            this.tbEUR.Size = new System.Drawing.Size(112, 26);
            this.tbEUR.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(302, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "lei";
            // 
            // EUR
            // 
            this.EUR.AutoSize = true;
            this.EUR.Location = new System.Drawing.Point(302, 231);
            this.EUR.Name = "EUR";
            this.EUR.Size = new System.Drawing.Size(44, 20);
            this.EUR.TabIndex = 7;
            this.EUR.Text = "EUR";
            // 
            // tbUSD
            // 
            this.tbUSD.Location = new System.Drawing.Point(142, 300);
            this.tbUSD.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbUSD.Name = "tbUSD";
            this.tbUSD.Size = new System.Drawing.Size(112, 26);
            this.tbUSD.TabIndex = 8;
            // 
            // lbUSD
            // 
            this.lbUSD.AutoSize = true;
            this.lbUSD.Location = new System.Drawing.Point(302, 300);
            this.lbUSD.Name = "lbUSD";
            this.lbUSD.Size = new System.Drawing.Size(44, 20);
            this.lbUSD.TabIndex = 9;
            this.lbUSD.Text = "USD";
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(789, 562);
            this.Controls.Add(this.lbUSD);
            this.Controls.Add(this.tbUSD);
            this.Controls.Add(this.EUR);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbEUR);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbLei);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbID);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form4";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tbLei;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbEUR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label EUR;
        private System.Windows.Forms.TextBox tbUSD;
        private System.Windows.Forms.Label lbUSD;
    }
}