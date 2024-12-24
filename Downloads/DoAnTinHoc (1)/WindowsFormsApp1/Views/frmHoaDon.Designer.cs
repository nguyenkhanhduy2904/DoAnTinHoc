namespace WindowsFormsApp1
{
    partial class frmHoaDon
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
            this.dgv_hoaDon = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_filter = new System.Windows.Forms.Button();
            this.chBox_daThanhToan_true = new System.Windows.Forms.CheckBox();
            this.chBox_daThanhToan_false = new System.Windows.Forms.CheckBox();
            this.btn_pay = new System.Windows.Forms.Button();
            this.btn_show_DSmon = new System.Windows.Forms.Button();
            this.cbo_customer = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hoaDon)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_hoaDon
            // 
            this.dgv_hoaDon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_hoaDon.Location = new System.Drawing.Point(12, 87);
            this.dgv_hoaDon.Name = "dgv_hoaDon";
            this.dgv_hoaDon.ReadOnly = true;
            this.dgv_hoaDon.Size = new System.Drawing.Size(776, 190);
            this.dgv_hoaDon.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(690, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chBox_daThanhToan_false);
            this.groupBox1.Controls.Add(this.chBox_daThanhToan_true);
            this.groupBox1.Controls.Add(this.btn_filter);
            this.groupBox1.Location = new System.Drawing.Point(26, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(273, 68);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // btn_filter
            // 
            this.btn_filter.Location = new System.Drawing.Point(188, 23);
            this.btn_filter.Name = "btn_filter";
            this.btn_filter.Size = new System.Drawing.Size(75, 23);
            this.btn_filter.TabIndex = 5;
            this.btn_filter.Text = "Lọc";
            this.btn_filter.UseVisualStyleBackColor = true;
            this.btn_filter.Click += new System.EventHandler(this.btn_filter_Click);
            // 
            // chBox_daThanhToan_true
            // 
            this.chBox_daThanhToan_true.AutoSize = true;
            this.chBox_daThanhToan_true.Checked = true;
            this.chBox_daThanhToan_true.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBox_daThanhToan_true.Location = new System.Drawing.Point(6, 26);
            this.chBox_daThanhToan_true.Name = "chBox_daThanhToan_true";
            this.chBox_daThanhToan_true.Size = new System.Drawing.Size(62, 17);
            this.chBox_daThanhToan_true.TabIndex = 6;
            this.chBox_daThanhToan_true.Text = "Đã tính";
            this.chBox_daThanhToan_true.UseVisualStyleBackColor = true;
            // 
            // chBox_daThanhToan_false
            // 
            this.chBox_daThanhToan_false.AutoSize = true;
            this.chBox_daThanhToan_false.Checked = true;
            this.chBox_daThanhToan_false.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chBox_daThanhToan_false.Location = new System.Drawing.Point(96, 26);
            this.chBox_daThanhToan_false.Name = "chBox_daThanhToan_false";
            this.chBox_daThanhToan_false.Size = new System.Drawing.Size(73, 17);
            this.chBox_daThanhToan_false.TabIndex = 7;
            this.chBox_daThanhToan_false.Text = "Chưa tính";
            this.chBox_daThanhToan_false.UseVisualStyleBackColor = true;
            // 
            // btn_pay
            // 
            this.btn_pay.Location = new System.Drawing.Point(57, 310);
            this.btn_pay.Name = "btn_pay";
            this.btn_pay.Size = new System.Drawing.Size(75, 23);
            this.btn_pay.TabIndex = 3;
            this.btn_pay.Text = "Thanh Toán";
            this.btn_pay.UseVisualStyleBackColor = true;
            this.btn_pay.Click += new System.EventHandler(this.btn_pay_Click);
            // 
            // btn_show_DSmon
            // 
            this.btn_show_DSmon.Location = new System.Drawing.Point(166, 310);
            this.btn_show_DSmon.Name = "btn_show_DSmon";
            this.btn_show_DSmon.Size = new System.Drawing.Size(88, 23);
            this.btn_show_DSmon.TabIndex = 4;
            this.btn_show_DSmon.Text = "Xem DS món";
            this.btn_show_DSmon.UseVisualStyleBackColor = true;
            // 
            // cbo_customer
            // 
            this.cbo_customer.FormattingEnabled = true;
            this.cbo_customer.Location = new System.Drawing.Point(390, 32);
            this.cbo_customer.Name = "cbo_customer";
            this.cbo_customer.Size = new System.Drawing.Size(121, 21);
            this.cbo_customer.TabIndex = 5;
            // 
            // frmHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbo_customer);
            this.Controls.Add(this.btn_show_DSmon);
            this.Controls.Add(this.btn_pay);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv_hoaDon);
            this.Name = "frmHoaDon";
            this.Text = "Hóa Đơn Bán Hàng";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_hoaDon)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_hoaDon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_filter;
        private System.Windows.Forms.CheckBox chBox_daThanhToan_false;
        private System.Windows.Forms.CheckBox chBox_daThanhToan_true;
        private System.Windows.Forms.Button btn_pay;
        private System.Windows.Forms.Button btn_show_DSmon;
        private System.Windows.Forms.ComboBox cbo_customer;
    }
}