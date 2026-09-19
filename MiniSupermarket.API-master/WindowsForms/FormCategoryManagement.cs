using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniSupermarket.WinForms
{
    public partial class FormCategoryManagement : Form
    {

        // Sử dụng địa chỉ http://localhost:5080/api/ đúng theo file .http của bạn
        private static readonly HttpClient _client = new HttpClient(new HttpClientHandler
        {
            // Bỏ qua kiểm tra chứng chỉ SSL nếu chạy HTTPS local
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
        })
        {
            BaseAddress = new Uri("http://localhost:5159/api/")
        };

        public FormCategoryManagement()
        {
            InitializeComponent();
            AutoLayoutControls(); // Tự động căn chỉnh lại toàn bộ vị trí & kích thước giao diện
        }

        // --- HÀM CĂN CHỈNH GIAO DIỆN BẰNG CODE ---
        private void AutoLayoutControls()
        {
            // 1. Cấu hình Form chính
            this.Text = "Quản lý Danh mục Nhóm hàng - FormCategoryManagement";
            this.ClientSize = new Size(820, 480);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Xóa tất cả control cũ đang bị lệch trên Form để dựng lại
            this.Controls.Clear();

            // 2. GroupBox Tìm kiếm (Góc trên trái)
            GroupBox gbSearch = new GroupBox
            {
                Text = "Tìm kiếm",
                Location = new Point(12, 12),
                Size = new Size(480, 65)
            };

            txtKeyword.Location = new Point(15, 25);
            txtKeyword.Size = new Size(270, 23);


            btnSearch.Text = "Tìm kiếm";
            btnSearch.Location = new Point(295, 23);
            btnSearch.Size = new Size(80, 27);

            btnLoad.Text = "Tải lại";
            btnLoad.Location = new Point(385, 23);
            btnLoad.Size = new Size(80, 27);

            gbSearch.Controls.AddRange(new Control[] { txtKeyword, btnSearch, btnLoad });

            // 3. GroupBox Danh sách (Góc dưới trái)
            GroupBox gbList = new GroupBox
            {
                Text = "Danh sách Nhóm hàng",
                Location = new Point(12, 85),
                Size = new Size(480, 375)
            };

            dgvCategories.Location = new Point(10, 22);
            dgvCategories.Size = new Size(460, 340);
            dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategories.ReadOnly = true;
            dgvCategories.AllowUserToAddRows = false;

            gbList.Controls.Add(dgvCategories);
            // 4. GroupBox Thông tin Nhóm hàng (Bên phải)
            GroupBox gbInfo = new GroupBox
            {
                Text = "Thông tin Nhóm hàng",
                Location = new Point(500, 12),
                Size = new Size(305, 448)
            };

            Label lblId = new Label { Text = "Mã ID", Location = new Point(15, 30), AutoSize = true };
            txtId.Location = new Point(15, 50);
            txtId.Size = new Size(275, 23);
            txtId.ReadOnly = true;

            Label lblName = new Label { Text = "Tên Nhóm hàng", Location = new Point(15, 95), AutoSize = true };
            txtCategoryName.Location = new Point(15, 115);
            txtCategoryName.Size = new Size(275, 23);

            Label lblDesc = new Label { Text = "Mô Tả", Location = new Point(15, 160), AutoSize = true };
            txtDescription.Location = new Point(15, 180);
            txtDescription.Size = new Size(275, 180);
            txtDescription.Multiline = true;
            txtDescription.ScrollBars = ScrollBars.Vertical;

            btnAdd.Text = "Thêm mới";
            btnAdd.Location = new Point(15, 380);
            btnAdd.Size = new Size(85, 30);

            btnUpdate.Text = "Cập nhật";
            btnUpdate.Location = new Point(110, 380);
            btnUpdate.Size = new Size(85, 30);

            btnDelete.Text = "Xóa";
            btnDelete.Location = new Point(205, 380);
            btnDelete.Size = new Size(85, 30);

            gbInfo.Controls.AddRange(new Control[] {
                lblId, txtId,
                lblName, txtCategoryName,
                lblDesc, txtDescription,
                btnAdd, btnUpdate, btnDelete
            });

            // 5. Thêm các GroupBox vào Form
            this.Controls.AddRange(new Control[] { gbSearch, gbList, gbInfo });

            // 6. Gán lại sự kiện Event Handlers
            this.Load -= FormCategoryManagement_Load;
            this.Load += FormCategoryManagement_Load;

            btnLoad.Click -= btnLoad_Click;
            btnLoad.Click += btnLoad_Click;

            btnSearch.Click -= btnSearch_Click;
            btnSearch.Click += btnSearch_Click;

            btnAdd.Click -= btnAdd_Click;
            btnAdd.Click += btnAdd_Click;

            btnUpdate.Click -= btnUpdate_Click;
            btnUpdate.Click += btnUpdate_Click;

            btnDelete.Click -= btnDelete_Click;
            btnDelete.Click += btnDelete_Click;

            dgvCategories.CellClick -= dgvCategories_CellClick;
            dgvCategories.CellClick += dgvCategories_CellClick;
        }

        // --- XỬ LÝ LOGIC GỌI API & SỰ KIỆN ---

        private async void FormCategoryManagement_Load(object sender, EventArgs e)
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            try
            {
                var categories = await _client.GetFromJsonAsync<List<CategoryDto>>("categories");
                dgvCategories.DataSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối Server: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            txtKeyword.Clear();
            await LoadDataAsync();
        }

        private void dgvCategories_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvCategories.Rows.Count)
            {
                DataGridViewRow row = dgvCategories.Rows[e.RowIndex];
                txtId.Text = row.Cells["CategoryId"].Value?.ToString() ?? string.Empty;
                txtCategoryName.Text = row.Cells["CategoryName"].Value?.ToString() ?? string.Empty;
                txtDescription.Text = row.Cells["Description"].Value?.ToString() ?? string.Empty;
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Tên nhóm hàng không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var newCat = new
            {
                CategoryName = txtCategoryName.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };

            try
            {
                var response = await _client.PostAsJsonAsync("categories", newCat);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Thêm mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show($"Thêm mới thất bại! Mã lỗi: {response.StatusCode}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn nhóm hàng cần sửa từ danh sách!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Tên nhóm hàng không được để trống!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var updateCat = new
            {
                CategoryId = id,
                CategoryName = txtCategoryName.Text.Trim(),
                Description = txtDescription.Text.Trim()
            };

            try
            {
                var response = await _client.PutAsJsonAsync($"categories/{id}", updateCat);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cập nhật thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadDataAsync();
                    ClearInputs();
                }
                else
                {
                    MessageBox.Show($"Cập nhật thất bại! Mã lỗi: {response.StatusCode}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtId.Text, out int id))
            {
                MessageBox.Show("Vui lòng chọn nhóm hàng cần xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa nhóm hàng ID = {id}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    var response = await _client.DeleteAsync($"categories/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadDataAsync();
                        ClearInputs();
                    }
                    else
                    {
                        MessageBox.Show($"Xóa thất bại! Mã lỗi: {response.StatusCode}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                await LoadDataAsync();
                return;
            }

            try
            {
                string encodedKeyword = Uri.EscapeDataString(keyword);
                var result = await _client.GetFromJsonAsync<List<CategoryDto>>($"categories/search?keyword={encodedKeyword}");
                dgvCategories.DataSource = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputs()
        {
            txtId.Clear();
            txtCategoryName.Clear();
            txtDescription.Clear();
        }
    }

    public class CategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; }
    }
}
