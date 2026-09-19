using System;
using System.Drawing;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    partial class FormCategoryManagement
    {
        private System.ComponentModel.IContainer components = null;

        private GroupBox gbTimKiem;
        private TextBox txtKeyword;
        private Button btnSearch;
        private Button btnLoad;

        private GroupBox gbDanhSach;
        private DataGridView dgvCategories;

        private GroupBox gbThongTin;
        private Label lblId;
        private TextBox txtId;
        private Label lblCategoryName;
        private TextBox txtCategoryName;
        private Label lblDescription;
        private TextBox txtDescription;

        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            gbTimKiem = new GroupBox();
            txtKeyword = new TextBox();
            btnSearch = new Button();
            btnLoad = new Button();

            gbDanhSach = new GroupBox();
            dgvCategories = new DataGridView();

            gbThongTin = new GroupBox();
            lblId = new Label();
            txtId = new TextBox();
            lblCategoryName = new Label();
            txtCategoryName = new TextBox();
            lblDescription = new Label();
            txtDescription = new TextBox();

            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();

            statusStrip1 = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();

            ((System.ComponentModel.ISupportInitialize)dgvCategories).BeginInit();

            gbTimKiem.SuspendLayout();
            gbDanhSach.SuspendLayout();
            gbThongTin.SuspendLayout();
            statusStrip1.SuspendLayout();

            SuspendLayout();

            // =====================================================
            // FORM
            // =====================================================

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;

            ClientSize = new Size(800, 500);

            Name = "FormCategoryManagement";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý danh mục";

            Load += FormCategoryManagement_Load;

            // =====================================================
            // GROUPBOX TÌM KIẾM
            // =====================================================

            gbTimKiem.Controls.Add(txtKeyword);
            gbTimKiem.Controls.Add(btnSearch);
            gbTimKiem.Controls.Add(btnLoad);

            gbTimKiem.Location = new Point(10, 10);
            gbTimKiem.Name = "gbTimKiem";
            gbTimKiem.Size = new Size(770, 65);
            gbTimKiem.TabIndex = 0;
            gbTimKiem.TabStop = false;
            gbTimKiem.Text = "Tìm kiếm";

            // =====================================================
            // TEXTBOX TÌM KIẾM
            // =====================================================

            txtKeyword.Location = new Point(10, 25);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.Size = new Size(235, 23);
            txtKeyword.TabIndex = 0;

            // =====================================================
            // BUTTON TÌM KIẾM
            // =====================================================

            btnSearch.Location = new Point(250, 24);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 25);
            btnSearch.TabIndex = 1;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;

            // =====================================================
            // BUTTON TẢI LẠI
            // =====================================================

            btnLoad.Location = new Point(335, 24);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(75, 25);
            btnLoad.TabIndex = 2;
            btnLoad.Text = "Tải lại";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;

            // =====================================================
            // GROUPBOX DANH SÁCH
            // =====================================================

            gbDanhSach.Controls.Add(dgvCategories);

            gbDanhSach.Location = new Point(10, 85);
            gbDanhSach.Name = "gbDanhSach";
            gbDanhSach.Size = new Size(470, 350);
            gbDanhSach.TabIndex = 3;
            gbDanhSach.TabStop = false;
            gbDanhSach.Text = "Danh sách Nhóm hàng";

            // =====================================================
            // DATAGRIDVIEW
            // =====================================================

            dgvCategories.AllowUserToAddRows = false;
            dgvCategories.AllowUserToDeleteRows = false;
            dgvCategories.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvCategories.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            dgvCategories.Location = new Point(10, 25);
            dgvCategories.MultiSelect = false;
            dgvCategories.Name = "dgvCategories";
            dgvCategories.ReadOnly = true;
            dgvCategories.RowHeadersWidth = 30;
            dgvCategories.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvCategories.Size = new Size(450, 315);
            dgvCategories.TabIndex = 4;

            dgvCategories.CellClick += dgvCategories_CellClick;

            // =====================================================
            // CỘT ID
            // =====================================================

            DataGridViewTextBoxColumn colId =
                new DataGridViewTextBoxColumn();

            colId.Name = "CategoryId";
            colId.HeaderText = "Mã ID";
            colId.DataPropertyName = "CategoryId";
            colId.FillWeight = 25;

            dgvCategories.Columns.Add(colId);

            // =====================================================
            // CỘT TÊN NHÓM HÀNG
            // =====================================================

            DataGridViewTextBoxColumn colName =
                new DataGridViewTextBoxColumn();

            colName.Name = "CategoryName";
            colName.HeaderText = "Tên Nhóm hàng";
            colName.DataPropertyName = "CategoryName";
            colName.FillWeight = 40;

            dgvCategories.Columns.Add(colName);

            // =====================================================
            // CỘT MÔ TẢ
            // =====================================================

            DataGridViewTextBoxColumn colDescription =
                new DataGridViewTextBoxColumn();

            colDescription.Name = "Description";
            colDescription.HeaderText = "Mô tả";
            colDescription.DataPropertyName = "Description";
            colDescription.FillWeight = 50;

            dgvCategories.Columns.Add(colDescription);

            // =====================================================
            // GROUPBOX THÔNG TIN
            // =====================================================

            gbThongTin.Controls.Add(lblId);
            gbThongTin.Controls.Add(txtId);
            gbThongTin.Controls.Add(lblCategoryName);
            gbThongTin.Controls.Add(txtCategoryName);
            gbThongTin.Controls.Add(lblDescription);
            gbThongTin.Controls.Add(txtDescription);
            gbThongTin.Controls.Add(btnAdd);
            gbThongTin.Controls.Add(btnUpdate);
            gbThongTin.Controls.Add(btnDelete);

            gbThongTin.Location = new Point(490, 85);
            gbThongTin.Name = "gbThongTin";
            gbThongTin.Size = new Size(290, 350);
            gbThongTin.TabIndex = 5;
            gbThongTin.TabStop = false;
            gbThongTin.Text = "Thông tin Nhóm hàng";

            // =====================================================
            // LABEL MÃ ID
            // =====================================================

            lblId.AutoSize = true;
            lblId.Location = new Point(10, 30);
            lblId.Name = "lblId";
            lblId.Size = new Size(35, 15);
            lblId.Text = "Mã ID";

            // =====================================================
            // TEXTBOX ID
            // =====================================================

            txtId.Location = new Point(10, 50);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(260, 23);
            txtId.TabIndex = 6;

            // =====================================================
            // LABEL TÊN NHÓM HÀNG
            // =====================================================

            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(10, 85);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(85, 15);
            lblCategoryName.Text = "Tên Nhóm hàng";

            // =====================================================
            // TEXTBOX TÊN NHÓM HÀNG
            // =====================================================

            txtCategoryName.Location = new Point(10, 105);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(260, 23);
            txtCategoryName.TabIndex = 7;

            // =====================================================
            // LABEL MÔ TẢ
            // =====================================================

            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(10, 140);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(40, 15);
            lblDescription.Text = "Mô tả";

            // =====================================================
            // TEXTBOX MÔ TẢ
            // =====================================================

            txtDescription.Location = new Point(10, 160);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(260, 65);
            txtDescription.TabIndex = 8;

            // =====================================================
            // BUTTON THÊM
            // =====================================================

            btnAdd.Location = new Point(10, 250);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(70, 30);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Thêm mới";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;

            // =====================================================
            // BUTTON CẬP NHẬT
            // =====================================================

            btnUpdate.Location = new Point(85, 250);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 30);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Cập nhật";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;

            // =====================================================
            // BUTTON XÓA
            // =====================================================

            btnDelete.Location = new Point(165, 250);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(60, 30);
            btnDelete.TabIndex = 11;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;

            // =====================================================
            // STATUS STRIP
            // =====================================================

            statusStrip1.Items.AddRange(
                new ToolStripItem[]
                {
                    lblStatus
                });

            statusStrip1.Location = new Point(0, 478);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 12;

            // =====================================================
            // STATUS TEXT
            // =====================================================

            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(40, 17);
            lblStatus.Text = "Ready";

            // =====================================================
            // ADD CONTROLS TO FORM
            // =====================================================

            Controls.Add(gbTimKiem);
            Controls.Add(gbDanhSach);
            Controls.Add(gbThongTin);
            Controls.Add(statusStrip1);

            ((System.ComponentModel.ISupportInitialize)dgvCategories).EndInit();

            gbTimKiem.ResumeLayout(false);
            gbTimKiem.PerformLayout();

            gbDanhSach.ResumeLayout(false);

            gbThongTin.ResumeLayout(false);
            gbThongTin.PerformLayout();

            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}