namespace AnterStudio.GameTools.OtherToolsClass
{
    partial class frmOtherTools
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOtherTools));
            this.btnBack = new System.Windows.Forms.Button();
            this.grpStarCraftSN = new System.Windows.Forms.GroupBox();
            this.txtSCSN_Out = new System.Windows.Forms.TextBox();
            this.txtSCSN_In = new System.Windows.Forms.TextBox();
            this.grpMAME = new System.Windows.Forms.GroupBox();
            this.btnXml = new System.Windows.Forms.Button();
            this.btnPrn = new System.Windows.Forms.Button();
            this.grpStarCraftSN.SuspendLayout();
            this.grpMAME.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            resources.ApplyResources(this.btnBack, "btnBack");
            this.btnBack.Name = "btnBack";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // grpStarCraftSN
            // 
            this.grpStarCraftSN.Controls.Add(this.txtSCSN_Out);
            this.grpStarCraftSN.Controls.Add(this.txtSCSN_In);
            resources.ApplyResources(this.grpStarCraftSN, "grpStarCraftSN");
            this.grpStarCraftSN.Name = "grpStarCraftSN";
            this.grpStarCraftSN.TabStop = false;
            // 
            // txtSCSN_Out
            // 
            this.txtSCSN_Out.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtSCSN_Out, "txtSCSN_Out");
            this.txtSCSN_Out.Name = "txtSCSN_Out";
            this.txtSCSN_Out.ReadOnly = true;
            // 
            // txtSCSN_In
            // 
            this.txtSCSN_In.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtSCSN_In, "txtSCSN_In");
            this.txtSCSN_In.Name = "txtSCSN_In";
            this.txtSCSN_In.TextChanged += new System.EventHandler(this.txtSCSN_In_TextChanged);
            // 
            // grpMAME
            // 
            this.grpMAME.Controls.Add(this.btnPrn);
            this.grpMAME.Controls.Add(this.btnXml);
            resources.ApplyResources(this.grpMAME, "grpMAME");
            this.grpMAME.Name = "grpMAME";
            this.grpMAME.TabStop = false;
            // 
            // btnXml
            // 
            resources.ApplyResources(this.btnXml, "btnXml");
            this.btnXml.Name = "btnXml";
            this.btnXml.UseVisualStyleBackColor = true;
            this.btnXml.Click += new System.EventHandler(this.btnXml_Click);
            // 
            // btnPrn
            // 
            resources.ApplyResources(this.btnPrn, "btnPrn");
            this.btnPrn.Name = "btnPrn";
            this.btnPrn.UseVisualStyleBackColor = true;
            this.btnPrn.Click += new System.EventHandler(this.btnPrn_Click);
            // 
            // frmOtherTools
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMAME);
            this.Controls.Add(this.grpStarCraftSN);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmOtherTools";
            this.grpStarCraftSN.ResumeLayout(false);
            this.grpStarCraftSN.PerformLayout();
            this.grpMAME.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox grpStarCraftSN;
        private System.Windows.Forms.TextBox txtSCSN_Out;
        private System.Windows.Forms.TextBox txtSCSN_In;
        private System.Windows.Forms.GroupBox grpMAME;
        private System.Windows.Forms.Button btnXml;
        private System.Windows.Forms.Button btnPrn;
    }
}