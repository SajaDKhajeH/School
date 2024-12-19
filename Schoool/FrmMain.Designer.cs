namespace Schoool
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnLessons = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnSendSMS = new System.Windows.Forms.Button();
            this.lbldesc = new System.Windows.Forms.Label();
            this.lblSucc = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(713, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Students";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(632, 12);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 0;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnLessons
            // 
            this.btnLessons.Location = new System.Drawing.Point(551, 12);
            this.btnLessons.Name = "btnLessons";
            this.btnLessons.Size = new System.Drawing.Size(75, 23);
            this.btnLessons.TabIndex = 2;
            this.btnLessons.Text = "Lessons";
            this.btnLessons.UseVisualStyleBackColor = true;
            this.btnLessons.Click += new System.EventHandler(this.btnLessons_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(409, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(13, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "0";
            // 
            // btnSendSMS
            // 
            this.btnSendSMS.Location = new System.Drawing.Point(470, 12);
            this.btnSendSMS.Name = "btnSendSMS";
            this.btnSendSMS.Size = new System.Drawing.Size(75, 23);
            this.btnSendSMS.TabIndex = 4;
            this.btnSendSMS.Text = "SMS";
            this.btnSendSMS.UseVisualStyleBackColor = true;
            this.btnSendSMS.Click += new System.EventHandler(this.btnSendSMS_Click);
            // 
            // lbldesc
            // 
            this.lbldesc.AutoSize = true;
            this.lbldesc.Location = new System.Drawing.Point(133, 156);
            this.lbldesc.Name = "lbldesc";
            this.lbldesc.Size = new System.Drawing.Size(0, 13);
            this.lbldesc.TabIndex = 5;
            // 
            // lblSucc
            // 
            this.lblSucc.AutoSize = true;
            this.lblSucc.Location = new System.Drawing.Point(634, 85);
            this.lblSucc.Name = "lblSucc";
            this.lblSucc.Size = new System.Drawing.Size(35, 13);
            this.lblSucc.TabIndex = 6;
            this.lblSucc.Text = "label2";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Location = new System.Drawing.Point(634, 108);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(35, 13);
            this.lblError.TabIndex = 6;
            this.lblError.Text = "label2";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 178);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.lblSucc);
            this.Controls.Add(this.lbldesc);
            this.Controls.Add(this.btnSendSMS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLessons);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.button1);
            this.Name = "FrmMain";
            this.Text = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnLessons;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSendSMS;
        private System.Windows.Forms.Label lbldesc;
        private System.Windows.Forms.Label lblSucc;
        private System.Windows.Forms.Label lblError;
    }
}