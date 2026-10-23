🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)Môn học: Lập trình Ứng dụng .NET Core (Mã môn: 229162)Buổi thực hành: Buổi 2 - Bảo mật & Phân quyền JWT cho Web API và Kết nối WinForms Client🏗️ 1. Mô hình Kiến trúc Hệ thống (Client - Server)Dự án mở rộng mô hình phân tầng với cơ chế bảo mật và phân quyền tài nguyên:MiniSupermarket.API (Backend): Triển khai cơ chế xác thực không trạng thái (Stateless Authentication) bằng JWT (JSON Web Token). Cấp phát Token tại AuthController và bảo vệ các Endpoints nghiệp vụ bằng các thuộc tính [Authorize] và [Authorize(Roles = "...")].   MiniSupermarket.WinForms (Frontend Client): Quản lý phiên làm việc thông qua lớp tĩnh SessionManager. Mọi yêu cầu truy vấn HTTP từ Client tới API đều được tự động đính kèm chuỗi Bearer Token vào Header để xác định danh tính và quyền hạn của người dùng.   🛠️ 2. Công nghệ Sử dụngNgôn ngữ: C# (.NET 8.0)   Backend: ASP.NET Core Web API, JWT Bearer Authentication (Microsoft.AspNetCore.Authentication.JwtBearer), Claims Identity, Data Annotations & ModelState   Frontend: Windows Forms (.NET 8.0), System.Net.Http.Json, System.Text.Json   Công cụ kiểm thử: Swagger UI (Cấu hình Bearer Auth)   📂 3. Cấu trúc SolutionPlaintextMiniSupermarketSystem/
│
├── MiniSupermarket.API/                   # Dự án Web API (Backend)
│   ├── Controllers/                       # Chứa CategoriesController ([Authorize]), AuthController
│   ├── Models/                            # Chứa Category.cs, LoginRequestDto
│   ├── appsettings.json                   # Cấu hình chuỗi bí mật JwtSettings:Secret
│   └── Program.cs                         # Cấu hình Middleware AddJwtBearer, UseAuthentication, UseAuthorization
│
└── MiniSupermarket.WinForms/              # Dự án Windows Forms (Frontend Client)
    ├── FormLogin.cs                       # Giao diện đăng nhập hệ thống (User/Password)
    ├── FormCategoryManagement.cs         # Giao diện quản lý danh mục (đính kèm Bearer Token)
    ├── SessionManager.cs                  # Lớp tĩnh lưu trữ JwtToken và CurrentRole
    └── Program.cs                         # Thay đổi Form khởi chạy mặc định là FormLogin
🚀 4. Hướng dẫn Chạy và Kiểm thử Dự ánBước 1: Chạy phía Backend (Web API) & Kiểm thử SwaggerMở Solution bằng Visual Studio 2022.Nhấp chuột phải vào project MiniSupermarket.API chọn Set as Startup Project.Nhấn F5 để chạy. Trình duyệt mở giao diện Swagger UI.Thử nghiệm gọi GET /api/categories khi chưa đăng nhập $\rightarrow$ Hệ thống trả về lỗi 401 Unauthorized.   Mở POST /api/auth/login, bấm Try it out, nhập tài khoản (admin / 123456 hoặc cashier / 123456), bấm Execute.   Sao chép chuỗi token nhận được, bấm nút Authorize (hình ổ khóa) góc trên bên phải Swagger, gõ Bearer <token_vừa_copy> và bấm Authorize.   Gọi lại GET /api/categories $\rightarrow$ Trả về mã 200 OK thành công.   Bước 2: Chạy phía Frontend (WinForms Client)Đảm bảo cổng (Port) trong HttpClient của WinForms khớp với cổng https://localhost:XXXXX của Web API đang chạy.   Nhấp chuột phải vào project MiniSupermarket.WinForms chọn Debug -> Start new instance.Màn hình FormLogin hiển thị đầu tiên. Nhập tài khoản và mật khẩu để đăng nhập.   Sau khi đăng nhập thành công, hệ thống lưu Token vào SessionManager và điều hướng sang FormCategoryManagement để thực hiện các thao tác CRUD an toàn.   
👨‍💻 5. Tác giả
Họ tên sinh viên: Nguyễn Quốc Bảo
Mã sinh viên: 2124110087
Lớp học phần: CCQ2411C
