namespace WindowsFormsApp1
{
    partial class frmTableDetails
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
            this.listBox_bill = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox_bill
            // 
            this.listBox_bill.FormattingEnabled = true;
            this.listBox_bill.Location = new System.Drawing.Point(526, 35);
            this.listBox_bill.Name = "listBox_bill";
            this.listBox_bill.Size = new System.Drawing.Size(221, 329);
            this.listBox_bill.TabIndex = 0;
            // 
            // frmTableDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.listBox_bill);
            this.Name = "frmTableDetails";
            this.Text = "frmTableDetails";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_bill;
    }
}