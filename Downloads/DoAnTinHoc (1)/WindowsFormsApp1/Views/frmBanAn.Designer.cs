namespace WindowsFormsApp1
{
    partial class frmBanAn
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
            this.btn_editTableLayout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_editTableLayout
            // 
            this.btn_editTableLayout.Location = new System.Drawing.Point(46, 12);
            this.btn_editTableLayout.Name = "btn_editTableLayout";
            this.btn_editTableLayout.Size = new System.Drawing.Size(75, 37);
            this.btn_editTableLayout.TabIndex = 0;
            this.btn_editTableLayout.Text = "Edit Table Layout";
            this.btn_editTableLayout.UseVisualStyleBackColor = true;
            this.btn_editTableLayout.Click += new System.EventHandler(this.btn_editTableLayout_Click);
            // 
            // frmBanAn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_editTableLayout);
            this.Name = "frmBanAn";
            this.Text = "Bàn Ăn";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_editTableLayout;
    }
}