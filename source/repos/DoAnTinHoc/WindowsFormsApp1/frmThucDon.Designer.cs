namespace WindowsFormsApp1
{
    partial class frmThucDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmThucDon));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFoodOut = new System.Windows.Forms.Button();
            this.btnFoodSave = new System.Windows.Forms.Button();
            this.btnFoodEdit = new System.Windows.Forms.Button();
            this.btnFoodDelete = new System.Windows.Forms.Button();
            this.btnFoodAdd = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_del_category = new System.Windows.Forms.Button();
            this.btn_add_category = new System.Windows.Forms.Button();
            this.cbo_category = new System.Windows.Forms.ComboBox();
            this.txtFoodTen = new System.Windows.Forms.TextBox();
            this.txtFoodGiaBan = new System.Windows.Forms.TextBox();
            this.txtFoodMa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtgvFood = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFood)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFoodOut);
            this.panel1.Controls.Add(this.btnFoodSave);
            this.panel1.Controls.Add(this.btnFoodEdit);
            this.panel1.Controls.Add(this.btnFoodDelete);
            this.panel1.Controls.Add(this.btnFoodAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 501);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1014, 100);
            this.panel1.TabIndex = 2;
            // 
            // btnFoodOut
            // 
            this.btnFoodOut.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFoodOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoodOut.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnFoodOut.Image = global::WindowsFormsApp1.Properties.Resources.Ảnh_chụp_màn_hình_2024_11_23_153942;
            this.btnFoodOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFoodOut.Location = new System.Drawing.Point(840, 30);
            this.btnFoodOut.Name = "btnFoodOut";
            this.btnFoodOut.Size = new System.Drawing.Size(88, 42);
            this.btnFoodOut.TabIndex = 5;
            this.btnFoodOut.Text = "Thoát";
            this.btnFoodOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFoodOut.UseVisualStyleBackColor = false;
            this.btnFoodOut.Click += new System.EventHandler(this.btnFoodOut_Click);
            // 
            // btnFoodSave
            // 
            this.btnFoodSave.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFoodSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoodSave.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnFoodSave.Image = global::WindowsFormsApp1.Properties.Resources.Ảnh_chụp_màn_hình_2024_11_23_153838;
            this.btnFoodSave.Location = new System.Drawing.Point(658, 30);
            this.btnFoodSave.Name = "btnFoodSave";
            this.btnFoodSave.Size = new System.Drawing.Size(80, 42);
            this.btnFoodSave.TabIndex = 3;
            this.btnFoodSave.Text = "Lưu";
            this.btnFoodSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFoodSave.UseVisualStyleBackColor = false;
            this.btnFoodSave.Click += new System.EventHandler(this.btnFoodSave_Click);
            // 
            // btnFoodEdit
            // 
            this.btnFoodEdit.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFoodEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoodEdit.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnFoodEdit.Image = global::WindowsFormsApp1.Properties.Resources.Ảnh_chụp_màn_hình_2024_11_23_153754;
            this.btnFoodEdit.Location = new System.Drawing.Point(480, 30);
            this.btnFoodEdit.Name = "btnFoodEdit";
            this.btnFoodEdit.Size = new System.Drawing.Size(80, 42);
            this.btnFoodEdit.TabIndex = 2;
            this.btnFoodEdit.Text = "Sửa";
            this.btnFoodEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFoodEdit.UseVisualStyleBackColor = false;
            this.btnFoodEdit.Click += new System.EventHandler(this.btnFoodEdit_Click);
            // 
            // btnFoodDelete
            // 
            this.btnFoodDelete.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFoodDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoodDelete.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnFoodDelete.Image = global::WindowsFormsApp1.Properties.Resources.Ảnh_chụp_màn_hình_2024_11_23_153707;
            this.btnFoodDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFoodDelete.Location = new System.Drawing.Point(302, 30);
            this.btnFoodDelete.Name = "btnFoodDelete";
            this.btnFoodDelete.Size = new System.Drawing.Size(80, 42);
            this.btnFoodDelete.TabIndex = 1;
            this.btnFoodDelete.Text = "Xóa";
            this.btnFoodDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFoodDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFoodDelete.UseVisualStyleBackColor = false;
            this.btnFoodDelete.Click += new System.EventHandler(this.btnFoodDelete_Click);
            // 
            // btnFoodAdd
            // 
            this.btnFoodAdd.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFoodAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoodAdd.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnFoodAdd.Image = global::WindowsFormsApp1.Properties.Resources.Ảnh_chụp_màn_hình_2024_11_23_153454;
            this.btnFoodAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFoodAdd.Location = new System.Drawing.Point(104, 30);
            this.btnFoodAdd.Name = "btnFoodAdd";
            this.btnFoodAdd.Size = new System.Drawing.Size(89, 42);
            this.btnFoodAdd.TabIndex = 0;
            this.btnFoodAdd.Text = "Thêm";
            this.btnFoodAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFoodAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFoodAdd.UseVisualStyleBackColor = false;
            this.btnFoodAdd.Click += new System.EventHandler(this.btnFoodAdd_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_del_category);
            this.panel2.Controls.Add(this.btn_add_category);
            this.panel2.Controls.Add(this.cbo_category);
            this.panel2.Controls.Add(this.txtFoodTen);
            this.panel2.Controls.Add(this.txtFoodGiaBan);
            this.panel2.Controls.Add(this.txtFoodMa);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.ForeColor = System.Drawing.Color.Olive;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1014, 147);
            this.panel2.TabIndex = 0;
            // 
            // btn_del_category
            // 
            this.btn_del_category.Location = new System.Drawing.Point(851, 114);
            this.btn_del_category.Name = "btn_del_category";
            this.btn_del_category.Size = new System.Drawing.Size(51, 23);
            this.btn_del_category.TabIndex = 5;
            this.btn_del_category.Text = "Xoá";
            this.btn_del_category.UseVisualStyleBackColor = true;
            this.btn_del_category.Click += new System.EventHandler(this.btn_del_category_Click);
            // 
            // btn_add_category
            // 
            this.btn_add_category.Location = new System.Drawing.Point(851, 85);
            this.btn_add_category.Name = "btn_add_category";
            this.btn_add_category.Size = new System.Drawing.Size(51, 23);
            this.btn_add_category.TabIndex = 4;
            this.btn_add_category.Text = "Thêm";
            this.btn_add_category.UseVisualStyleBackColor = true;
            this.btn_add_category.Click += new System.EventHandler(this.btn_add_category_Click);
            // 
            // cbo_category
            // 
            this.cbo_category.FormattingEnabled = true;
            this.cbo_category.Location = new System.Drawing.Point(724, 87);
            this.cbo_category.Name = "cbo_category";
            this.cbo_category.Size = new System.Drawing.Size(121, 21);
            this.cbo_category.TabIndex = 3;
            this.cbo_category.SelectedIndexChanged += new System.EventHandler(this.cbo_category_SelectedIndexChanged);
            // 
            // txtFoodTen
            // 
            this.txtFoodTen.Location = new System.Drawing.Point(104, 87);
            this.txtFoodTen.Name = "txtFoodTen";
            this.txtFoodTen.Size = new System.Drawing.Size(266, 20);
            this.txtFoodTen.TabIndex = 2;
            // 
            // txtFoodGiaBan
            // 
            this.txtFoodGiaBan.Location = new System.Drawing.Point(724, 41);
            this.txtFoodGiaBan.Name = "txtFoodGiaBan";
            this.txtFoodGiaBan.Size = new System.Drawing.Size(266, 20);
            this.txtFoodGiaBan.TabIndex = 1;
            this.txtFoodGiaBan.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
            // 
            // txtFoodMa
            // 
            this.txtFoodMa.Location = new System.Drawing.Point(104, 42);
            this.txtFoodMa.Name = "txtFoodMa";
            this.txtFoodMa.Size = new System.Drawing.Size(266, 20);
            this.txtFoodMa.TabIndex = 0;
            this.txtFoodMa.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Olive;
            this.label3.Location = new System.Drawing.Point(3, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên Món Ăn :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Olive;
            this.label4.Location = new System.Drawing.Point(626, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Loại  :";
            this.label4.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Olive;
            this.label5.Location = new System.Drawing.Point(626, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 1;
            this.label5.Text = "Giá Bán :";
            this.label5.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Olive;
            this.label2.Location = new System.Drawing.Point(9, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã Món Ăn :";
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(372, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "THỰC ĐƠN NHÀ HÀNG ";
            // 
            // dtgvFood
            // 
            this.dtgvFood.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvFood.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvFood.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvFood.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dtgvFood.Location = new System.Drawing.Point(0, 147);
            this.dtgvFood.Name = "dtgvFood";
            this.dtgvFood.ReadOnly = true;
            this.dtgvFood.Size = new System.Drawing.Size(1014, 354);
            this.dtgvFood.TabIndex = 4;
            this.dtgvFood.AutoSizeColumnsModeChanged += new System.Windows.Forms.DataGridViewAutoSizeColumnsModeEventHandler(this.dtgvFood_AutoSizeColumnsModeChanged);
            // 
            // frmThucDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 601);
            this.Controls.Add(this.dtgvFood);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmThucDon";
            this.Text = "Thực Đơn ";
            this.Load += new System.EventHandler(this.frmThucDon_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFood)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dtgvFood;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFoodTen;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFoodOut;
        private System.Windows.Forms.Button btnFoodSave;
        private System.Windows.Forms.Button btnFoodEdit;
        private System.Windows.Forms.Button btnFoodDelete;
        private System.Windows.Forms.Button btnFoodAdd;
        private System.Windows.Forms.TextBox txtFoodMa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFoodGiaBan;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbo_category;
        private System.Windows.Forms.Button btn_add_category;
        private System.Windows.Forms.Button btn_del_category;
    }
}