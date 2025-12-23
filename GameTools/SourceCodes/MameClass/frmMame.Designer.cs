namespace AnterStudio.GameTools.MameClass
{
    partial class frmMame
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
            this.btnXml = new System.Windows.Forms.Button();
            this.btnPrn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnXml
            // 
            this.btnXml.Location = new System.Drawing.Point(52, 38);
            this.btnXml.Name = "btnXml";
            this.btnXml.Size = new System.Drawing.Size(125, 38);
            this.btnXml.TabIndex = 0;
            this.btnXml.Text = "MAME xml";
            this.btnXml.UseVisualStyleBackColor = true;
            this.btnXml.Click += new System.EventHandler(this.btnXml_Click);
            // 
            // btnPrn
            // 
            this.btnPrn.Location = new System.Drawing.Point(235, 38);
            this.btnPrn.Name = "btnPrn";
            this.btnPrn.Size = new System.Drawing.Size(125, 38);
            this.btnPrn.TabIndex = 1;
            this.btnPrn.Text = "Print prn";
            this.btnPrn.UseVisualStyleBackColor = true;
            this.btnPrn.Click += new System.EventHandler(this.btnPrn_Click);
            // 
            // frmMame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 110);
            this.Controls.Add(this.btnPrn);
            this.Controls.Add(this.btnXml);
            this.Name = "frmMame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MameForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnXml;
        private System.Windows.Forms.Button btnPrn;
    }
}