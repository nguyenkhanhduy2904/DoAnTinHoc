namespace WindowsFormsApp1
{
    partial class frmTaiKhoanKhach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTaiKhoanKhach));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAccountExit = new System.Windows.Forms.Button();
            this.btnAccountSave = new System.Windows.Forms.Button();
            this.btnAccountEdit = new System.Windows.Forms.Button();
            this.btnAccountDelete = new System.Windows.Forms.Button();
            this.btnAccountAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpkNgaySinhTK = new System.Windows.Forms.DateTimePicker();
            this.msksdtKH = new System.Windows.Forms.MaskedTextBox();
            this.ckbGioiTinh = new System.Windows.Forms.CheckBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.txtDiaChiKH = new System.Windows.Forms.TextBox();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgvAccount = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAccount)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnAccountExit);
            this.panel1.Controls.Add(this.btnAccountSave);
            this.panel1.Controls.Add(this.btnAccountEdit);
            this.panel1.Controls.Add(this.btnAccountDelete);
            this.panel1.Controls.Add(this.btnAccountAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 438);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(874, 88);
            this.panel1.TabIndex = 0;
            // 
            // btnAccountExit
            // 
            this.btnAccountExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccountExit.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnAccountExit.Image = global::WindowsFormsApp1.Properties.Resources.Ảnh_chụp_màn_hình_2024_11_23_153942;
            this.btnAccountExit.Location = new System.Drawing.Point(763, 30);
            this.btnAccountExit.Name = "btnAccountExit";
            this.btnAccountExit.Size = new System.Drawing.Size(86, 43);
            this.btnAccountExit.TabIndex = 0;
            this.btnAccountExit.Text = "Thoát";
            this.btnAccountExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccountExit.UseVisualStyleBackColor = true;
            this.btnAccountExit.Click += new System.EventHandler(this.btnAccountExit_Click);
            // 
            // btnAccountSave
            // 
            this.btnAccountSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccountSave.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnAccountSave.Image = global::WindowsFormsApp1.Properties.Resources.Ảnh_chụp_màn_hình_2024_11_23_153838;
            this.btnAccountSave.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAccountSave.Location = new System.Drawing.Point(585, 26);
            this.btnAccountSave.Name = "btnAccountSave";
            this.btnAccountSave.Size = new System.Drawing.Size(86, 50);
            this.btnAccountSave.TabIndex = 0;
            this.btnAccountSave.Text = "Lưu";
            this.btnAccountSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccountSave.UseVisualStyleBackColor = true;
            this.btnAccountSave.Click += new System.EventHandler(this.btnAccountSave_Click);
            // 
            // btnAccountEdit
            // 
            this.btnAccountEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccountEdit.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnAccountEdit.Image = global::WindowsFormsApp1.Properties.Resources.Ảnh_chụp_màn_hình_2024_11_23_153754;
            this.btnAccountEdit.Location = new System.Drawing.Point(401, 26);
            this.btnAccountEdit.Name = "btnAccountEdit";
            this.btnAccountEdit.Size = new System.Drawing.Size(86, 50);
            this.btnAccountEdit.TabIndex = 0;
            this.btnAccountEdit.Text = "Sửa";
            this.btnAccountEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccountEdit.UseVisualStyleBackColor = true;
            this.btnAccountEdit.Click += new System.EventHandler(this.btnAccountEdit_Click);
            // 
            // btnAccountDelete
            // 
            this.btnAccountDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccountDelete.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnAccountDelete.Image = global::WindowsFormsApp1.Properties.Resources.Ảnh_chụp_màn_hình_2024_11_23_153707;
            this.btnAccountDelete.Location = new System.Drawing.Point(217, 26);
            this.btnAccountDelete.Name = "btnAccountDelete";
            this.btnAccountDelete.Size = new System.Drawing.Size(86, 50);
            this.btnAccountDelete.TabIndex = 0;
            this.btnAccountDelete.Text = "Xóa";
            this.btnAccountDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccountDelete.UseVisualStyleBackColor = true;
            this.btnAccountDelete.Click += new System.EventHandler(this.btnAccountDelete_Click);
            // 
            // btnAccountAdd
            // 
            this.btnAccountAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccountAdd.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnAccountAdd.Image = global::WindowsFormsApp1.Properties.Resources.Ảnh_chụp_màn_hình_2024_11_23_153454;
            this.btnAccountAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccountAdd.Location = new System.Drawing.Point(39, 26);
            this.btnAccountAdd.Name = "btnAccountAdd";
            this.btnAccountAdd.Size = new System.Drawing.Size(86, 50);
            this.btnAccountAdd.TabIndex = 0;
            this.btnAccountAdd.Text = "Thêm";
            this.btnAccountAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccountAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccountAdd.UseVisualStyleBackColor = true;
            this.btnAccountAdd.Click += new System.EventHandler(this.btnAccountAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpkNgaySinhTK);
            this.panel2.Controls.Add(this.msksdtKH);
            this.panel2.Controls.Add(this.ckbGioiTinh);
            this.panel2.Controls.Add(this.txtTenKH);
            this.panel2.Controls.Add(this.txtDiaChiKH);
            this.panel2.Controls.Add(this.txtMaKH);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(874, 168);
            this.panel2.TabIndex = 1;
            // 
            // dtpkNgaySinhTK
            // 
            this.dtpkNgaySinhTK.Location = new System.Drawing.Point(691, 134);
            this.dtpkNgaySinhTK.Name = "dtpkNgaySinhTK";
            this.dtpkNgaySinhTK.Size = new System.Drawing.Size(158, 20);
            this.dtpkNgaySinhTK.TabIndex = 5;
            // 
            // msksdtKH
            // 
            this.msksdtKH.Location = new System.Drawing.Point(691, 86);
            this.msksdtKH.Mask = "(999) 000-0000";
            this.msksdtKH.Name = "msksdtKH";
            this.msksdtKH.Size = new System.Drawing.Size(158, 20);
            this.msksdtKH.TabIndex = 3;
            // 
            // ckbGioiTinh
            // 
            this.ckbGioiTinh.AutoSize = true;
            this.ckbGioiTinh.Checked = true;
            this.ckbGioiTinh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbGioiTinh.Location = new System.Drawing.Point(158, 139);
            this.ckbGioiTinh.Name = "ckbGioiTinh";
            this.ckbGioiTinh.Size = new System.Drawing.Size(48, 17);
            this.ckbGioiTinh.TabIndex = 4;
            this.ckbGioiTinh.Text = "Nam";
            this.ckbGioiTinh.UseVisualStyleBackColor = true;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(158, 86);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(158, 20);
            this.txtTenKH.TabIndex = 2;
            // 
            // txtDiaChiKH
            // 
            this.txtDiaChiKH.Location = new System.Drawing.Point(691, 41);
            this.txtDiaChiKH.Name = "txtDiaChiKH";
            this.txtDiaChiKH.Size = new System.Drawing.Size(158, 20);
            this.txtDiaChiKH.TabIndex = 1;
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(158, 41);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(158, 20);
            this.txtMaKH.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Chocolate;
            this.label7.Location = new System.Drawing.Point(605, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ngày Sinh :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Chocolate;
            this.label6.Location = new System.Drawing.Point(68, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Giới Tính :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Chocolate;
            this.label5.Location = new System.Drawing.Point(582, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Số Điện Thoại :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Chocolate;
            this.label4.Location = new System.Drawing.Point(622, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Địa Chỉ :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Chocolate;
            this.label3.Location = new System.Drawing.Point(30, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên Khách Hàng :";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Chocolate;
            this.label2.Location = new System.Drawing.Point(36, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Khách Hàng :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(329, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(263, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "TÀI KHOẢN KHÁCH HÀNG";
            // 
            // dtgvAccount
            // 
            this.dtgvAccount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvAccount.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dtgvAccount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvAccount.Location = new System.Drawing.Point(0, 168);
            this.dtgvAccount.Name = "dtgvAccount";
            this.dtgvAccount.Size = new System.Drawing.Size(874, 270);
            this.dtgvAccount.TabIndex = 2;
            this.dtgvAccount.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgvAccount_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MaTK";
            this.Column1.HeaderText = "Mã Khách Hàng";
            this.Column1.Name = "Column1";
            this.Column1.Width = 130;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "TenTK";
            this.Column2.HeaderText = "Tên Khách Hàng";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "GioiTinhTK";
            this.Column3.HeaderText = "Giới Tính";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "DiaChiTK";
            this.Column4.HeaderText = "Địa Chỉ";
            this.Column4.Name = "Column4";
            this.Column4.Width = 160;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "SDTTK";
            this.Column5.HeaderText = "Số Điện Thoại";
            this.Column5.Name = "Column5";
            this.Column5.Width = 130;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "NgaySinhTK";
            this.Column6.HeaderText = "Ngày Sinh";
            this.Column6.Name = "Column6";
            this.Column6.Width = 160;
            // 
            // frmTaiKhoanKhach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(874, 526);
            this.Controls.Add(this.dtgvAccount);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmTaiKhoanKhach";
            this.Text = "Tài Khoản Khách Hàng";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvAccount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAccountExit;
        private System.Windows.Forms.Button btnAccountSave;
        private System.Windows.Forms.Button btnAccountEdit;
        private System.Windows.Forms.Button btnAccountDelete;
        private System.Windows.Forms.Button btnAccountAdd;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dtgvAccount;
        private System.Windows.Forms.DateTimePicker dtpkNgaySinhTK;
        private System.Windows.Forms.MaskedTextBox msksdtKH;
        private System.Windows.Forms.CheckBox ckbGioiTinh;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.TextBox txtDiaChiKH;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}