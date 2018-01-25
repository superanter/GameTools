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
            this.btnBack = new System.Windows.Forms.Button();
            this.grpStarCraftSN = new System.Windows.Forms.GroupBox();
            this.txtSCSN_Out = new System.Windows.Forms.TextBox();
            this.txtSCSN_In = new System.Windows.Forms.TextBox();
            this.grpStarCraftSN.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(241, 78);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // grpStarCraftSN
            // 
            this.grpStarCraftSN.Controls.Add(this.txtSCSN_Out);
            this.grpStarCraftSN.Controls.Add(this.txtSCSN_In);
            this.grpStarCraftSN.Location = new System.Drawing.Point(13, 13);
            this.grpStarCraftSN.Name = "grpStarCraftSN";
            this.grpStarCraftSN.Size = new System.Drawing.Size(303, 58);
            this.grpStarCraftSN.TabIndex = 1;
            this.grpStarCraftSN.TabStop = false;
            this.grpStarCraftSN.Text = "StarCraft SN";
            // 
            // txtSCSN_Out
            // 
            this.txtSCSN_Out.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSCSN_Out.Location = new System.Drawing.Point(146, 20);
            this.txtSCSN_Out.Name = "txtSCSN_Out";
            this.txtSCSN_Out.ReadOnly = true;
            this.txtSCSN_Out.Size = new System.Drawing.Size(142, 21);
            this.txtSCSN_Out.TabIndex = 1;
            this.txtSCSN_Out.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtSCSN_In
            // 
            this.txtSCSN_In.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSCSN_In.Location = new System.Drawing.Point(18, 20);
            this.txtSCSN_In.Name = "txtSCSN_In";
            this.txtSCSN_In.Size = new System.Drawing.Size(111, 21);
            this.txtSCSN_In.TabIndex = 0;
            this.txtSCSN_In.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSCSN_In.TextChanged += new System.EventHandler(this.txtSCSN_In_TextChanged);
            // 
            // frmOtherTools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 113);
            this.Controls.Add(this.grpStarCraftSN);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmOtherTools";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOtherTools";
            this.grpStarCraftSN.ResumeLayout(false);
            this.grpStarCraftSN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.GroupBox grpStarCraftSN;
        private System.Windows.Forms.TextBox txtSCSN_Out;
        private System.Windows.Forms.TextBox txtSCSN_In;
    }
}