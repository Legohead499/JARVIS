namespace JARVIS
{
    partial class sendMailInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(sendMailInput));
            this.sendToInput = new System.Windows.Forms.ListBox();
            this.recipentInput = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.subjectInput = new System.Windows.Forms.TextBox();
            this.messageInput = new System.Windows.Forms.TextBox();
            this.addToList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sendToInput
            // 
            this.sendToInput.FormattingEnabled = true;
            this.sendToInput.Location = new System.Drawing.Point(25, 120);
            this.sendToInput.Name = "sendToInput";
            this.sendToInput.Size = new System.Drawing.Size(120, 95);
            this.sendToInput.TabIndex = 0;
            // 
            // recipentInput
            // 
            this.recipentInput.Location = new System.Drawing.Point(12, 60);
            this.recipentInput.Name = "recipentInput";
            this.recipentInput.Size = new System.Drawing.Size(151, 20);
            this.recipentInput.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(50, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Recipient";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(386, 34);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(50, 20);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "Subject";
            // 
            // subjectInput
            // 
            this.subjectInput.Location = new System.Drawing.Point(386, 62);
            this.subjectInput.Name = "subjectInput";
            this.subjectInput.Size = new System.Drawing.Size(151, 20);
            this.subjectInput.TabIndex = 3;
            // 
            // messageInput
            // 
            this.messageInput.Location = new System.Drawing.Point(257, 120);
            this.messageInput.Multiline = true;
            this.messageInput.Name = "messageInput";
            this.messageInput.Size = new System.Drawing.Size(348, 263);
            this.messageInput.TabIndex = 5;
            this.messageInput.Text = "Message";
            // 
            // addToList
            // 
            this.addToList.Location = new System.Drawing.Point(181, 60);
            this.addToList.Name = "addToList";
            this.addToList.Size = new System.Drawing.Size(75, 23);
            this.addToList.TabIndex = 6;
            this.addToList.Text = "Add";
            this.addToList.UseVisualStyleBackColor = true;
            this.addToList.Click += new System.EventHandler(this.addToList_Click);
            // 
            // sendMailInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(637, 407);
            this.Controls.Add(this.addToList);
            this.Controls.Add(this.messageInput);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.subjectInput);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.recipentInput);
            this.Controls.Add(this.sendToInput);
            this.Name = "sendMailInput";
            this.Text = "sendMailInput";
            this.Load += new System.EventHandler(this.sendMail_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox sendToInput;
        private System.Windows.Forms.TextBox recipentInput;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox subjectInput;
        private System.Windows.Forms.TextBox messageInput;
        private System.Windows.Forms.Button addToList;
    }
}