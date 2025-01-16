namespace Schoool
{
    partial class FrmChat
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
            this.rtxtMyMessage = new System.Windows.Forms.RichTextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.txtText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtxtOtherMessage = new System.Windows.Forms.RichTextBox();
            this.txtFromId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rtxtMyMessage
            // 
            this.rtxtMyMessage.Location = new System.Drawing.Point(341, 75);
            this.rtxtMyMessage.Name = "rtxtMyMessage";
            this.rtxtMyMessage.Size = new System.Drawing.Size(184, 354);
            this.rtxtMyMessage.TabIndex = 0;
            this.rtxtMyMessage.Text = "";
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(112, 340);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(121, 20);
            this.txtFrom.TabIndex = 1;
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Location = new System.Drawing.Point(73, 314);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(15, 13);
            this.id.TabIndex = 2;
            this.id.Text = "id";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(132, 121);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 81);
            this.button1.TabIndex = 3;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(450, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "refresh";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(75, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "to";
            // 
            // cmbTo
            // 
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Items.AddRange(new object[] {
            "سجاد",
            "علی",
            "حسن",
            "حسین"});
            this.cmbTo.Location = new System.Drawing.Point(132, 94);
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(121, 21);
            this.cmbTo.TabIndex = 5;
            // 
            // txtText
            // 
            this.txtText.Location = new System.Drawing.Point(132, 68);
            this.txtText.Name = "txtText";
            this.txtText.Size = new System.Drawing.Size(121, 20);
            this.txtText.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "text";
            // 
            // rtxtOtherMessage
            // 
            this.rtxtOtherMessage.Location = new System.Drawing.Point(531, 75);
            this.rtxtOtherMessage.Name = "rtxtOtherMessage";
            this.rtxtOtherMessage.Size = new System.Drawing.Size(184, 354);
            this.rtxtOtherMessage.TabIndex = 0;
            this.rtxtOtherMessage.Text = "";
            // 
            // txtFromId
            // 
            this.txtFromId.Location = new System.Drawing.Point(112, 311);
            this.txtFromId.Name = "txtFromId";
            this.txtFromId.Size = new System.Drawing.Size(121, 20);
            this.txtFromId.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 340);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "name";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 23);
            this.label1.TabIndex = 6;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.id);
            this.Controls.Add(this.txtText);
            this.Controls.Add(this.txtFromId);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.rtxtOtherMessage);
            this.Controls.Add(this.rtxtMyMessage);
            this.Name = "FrmChat";
            this.Text = "FrmChat";
            this.Load += new System.EventHandler(this.FrmChat_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxtMyMessage;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.Label id;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.TextBox txtText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtxtOtherMessage;
        private System.Windows.Forms.TextBox txtFromId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
    }
}