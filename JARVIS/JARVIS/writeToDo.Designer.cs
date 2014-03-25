namespace JARVIS
{
    partial class writeToDo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(writeToDo));
            this.input = new System.Windows.Forms.TextBox();
            this.done = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // input
            // 
            this.input.Location = new System.Drawing.Point(39, 108);
            this.input.Multiline = true;
            this.input.Name = "input";
            this.input.Size = new System.Drawing.Size(384, 118);
            this.input.TabIndex = 0;
            // 
            // done
            // 
            this.done.Location = new System.Drawing.Point(474, 150);
            this.done.Name = "done";
            this.done.Size = new System.Drawing.Size(109, 31);
            this.done.TabIndex = 1;
            this.done.Text = "Done";
            this.done.Click += new System.EventHandler(this.done_Click);
            // 
            // writeToDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(634, 406);
            this.Controls.Add(this.done);
            this.Controls.Add(this.input);
            this.Name = "writeToDo";
            this.Text = "writeToDo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.Button done;
    }
}