🛒 HỆ THỐNG QUẢN LÝ SIÊU THỊ MINI (MINISUPERMARKET SYSTEM)Môn học: Lập trình Ứng dụng .NET Core (Mã môn: 229162)Buổi thực hành: Buổi 3 - Tích hợp Cơ sở dữ liệu SQL Server và Entity Framework Core Code-First🏗️ 1. Mô hình Kiến trúc Hệ thống (Client - Server)Dự án chuyển đổi cơ chế lưu trữ sang cơ sở dữ liệu quan hệ chuyên nghiệp:MiniSupermarket.API (Backend): Tích hợp Entity Framework Core (EF Core) theo phương pháp tiếp cận Code-First. Định nghĩa các thực thể Model C# kết hợp Data Annotations, cấu hình SupermarketDbContext kết nối trực tiếp đến Microsoft SQL Server và thực thi dữ liệu mồi (Data Seeding). Tái cấu trúc các Controllers sử dụng LINQ async/await.   MiniSupermarket.WinForms (Frontend Client): Giữ nguyên kiến trúc kết nối qua HttpClient, tương tác dữ liệu vĩnh viễn với Backend API mà không lo bị mất dữ liệu khi tắt máy hoặc restart server.   🛠️ 2. Công nghệ Sử dụngNgôn ngữ: C# (.NET 8.0)   Backend: ASP.NET Core Web API, Entity Framework Core 8.0 (SqlServer, Tools, Design), LINQ Async (ToListAsync, FindAsync, SaveChangesAsync), SQL Server   Frontend: Windows Forms (.NET 8.0), System.Net.Http.Json   Công cụ CSDL & Kiểm thử: SQL Server Management Studio (SSMS), Package Manager Console (Migrations), Swagger UI   📂 3. Cấu trúc SolutionPlaintextMiniSupermarketSystem/
│
├── MiniSupermarket.API/                   # Dự án Web API (Backend)
│   ├── Data/                              # Chứa SupermarketDbContext.cs (DbContext & Data Seeding)
│   ├── Migrations/                        # Chứa các tệp mã nguồn quản lý phiên bản CSDL sinh bởi EF Core
│   ├── Controllers/                       # CategoriesController (Tái cấu trúc truy vấn EF Core & Async)
│   ├── Models/                            # Chứa Category.cs, Product.cs (Data Annotations & FK Relationships)
│   └── appsettings.json                   # Cấu hình ConnectionStrings: DefaultConnection
│
└── MiniSupermarket.WinForms/              # Dự án Windows Forms (Frontend Client)
    └── FormCategoryManagement.cs         # Giao diện quản lý danh mục (Giao tiếp API lưu dữ liệu xuống SQL Server)
🚀 4. Hướng dẫn Chạy và Kiểm thử Dự ánBước 1: Khởi tạo Cơ sở dữ liệu bằng EF Core MigrationsMở file appsettings.json trong project MiniSupermarket.API và điều chỉnh chuỗi kết nối DefaultConnection cho phù hợp với máy tính tính/máy chủ SQL Server.   Mở cửa sổ Package Manager Console (Tools -> NuGet Package Manager -> Package Manager Console).   Đảm bảo ô Default project chọn MiniSupermarket.API và gõ lần lượt 2 câu lệnh:   Add-Migration InitialCreateDatabase   Update-Database   Mở SQL Server Management Studio (SSMS) để kiểm tra CSDL MiniSupermarketDb đã được tự động tạo kèm các bảng Categories, Products và 5 dòng dữ liệu mẫu.   Bước 2: Chạy và Kiểm thử Hệ thốngĐặt MiniSupermarket.API làm Startup Project và nhấn F5 để chạy API.   Kiểm thử các Endpoint trên Swagger UI (GET, POST, PUT, DELETE /api/categories).   Khởi chạy project MiniSupermarket.WinForms, thực hiện các thao tác Thêm, Sửa, Xóa.   Tắt toàn bộ ứng dụng và khởi chạy lại để kiểm chứng dữ liệu vẫn được lưu trữ vĩnh viễn trên SQL Server.   
👨‍💻 5. Tác giả
Họ tên sinh viên: Nguyễn Quốc Bảo
Mã sinh viên: 2124110087
Lớp học phần: CCQ2411C
