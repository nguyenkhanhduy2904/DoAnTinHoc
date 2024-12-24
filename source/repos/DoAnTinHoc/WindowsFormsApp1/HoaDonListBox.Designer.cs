namespace WindowsFormsApp1
{
    partial class HoaDonListBox
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
            this.listBox_HoaDon = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // listBox_HoaDon
            // 
            this.listBox_HoaDon.FormattingEnabled = true;
            this.listBox_HoaDon.Location = new System.Drawing.Point(12, 20);
            this.listBox_HoaDon.Name = "listBox_HoaDon";
            this.listBox_HoaDon.Size = new System.Drawing.Size(269, 199);
            this.listBox_HoaDon.TabIndex = 0;
            // 
            // HoaDonListBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 232);
            this.Controls.Add(this.listBox_HoaDon);
            this.Name = "HoaDonListBox";
            this.Text = "HoaDonListBox";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_HoaDon;
    }
}