namespace Cpanel_Creator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.hostTxt = new System.Windows.Forms.TextBox();
            this.userTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.passTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.domainsTxt = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.packageTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // hostTxt
            // 
            this.hostTxt.Location = new System.Drawing.Point(73, 18);
            this.hostTxt.Name = "hostTxt";
            this.hostTxt.Size = new System.Drawing.Size(191, 20);
            this.hostTxt.TabIndex = 1;
            // 
            // userTxt
            // 
            this.userTxt.Location = new System.Drawing.Point(73, 46);
            this.userTxt.Name = "userTxt";
            this.userTxt.Size = new System.Drawing.Size(191, 20);
            this.userTxt.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "User :";
            // 
            // passTxt
            // 
            this.passTxt.Location = new System.Drawing.Point(73, 72);
            this.passTxt.Name = "passTxt";
            this.passTxt.Size = new System.Drawing.Size(191, 20);
            this.passTxt.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "pass :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Domains :";
            // 
            // domainsTxt
            // 
            this.domainsTxt.Location = new System.Drawing.Point(73, 124);
            this.domainsTxt.Name = "domainsTxt";
            this.domainsTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.domainsTxt.Size = new System.Drawing.Size(191, 96);
            this.domainsTxt.TabIndex = 7;
            this.domainsTxt.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(197, 226);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Package :";
            // 
            // packageTxt
            // 
            this.packageTxt.Location = new System.Drawing.Point(73, 98);
            this.packageTxt.Name = "packageTxt";
            this.packageTxt.Size = new System.Drawing.Size(191, 20);
            this.packageTxt.TabIndex = 10;
            this.packageTxt.Text = "default";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Whm Host :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.packageTxt);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.domainsTxt);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.passTxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.userTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hostTxt);
            this.Controls.Add(this.label6);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Cpanel Creator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox hostTxt;
        private System.Windows.Forms.TextBox userTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox passTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox domainsTxt;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox packageTxt;
        private System.Windows.Forms.Label label6;
    }
}

