using BaiTapLon_WinFormApp.Views.Admin.HomePage;
using BaiTapLonWinForm.Data;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Implementations;
using BaiTapLonWinForm.Repositories.interfaces;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Services.Implementations;
using BaiTapLonWinForm.Services.interfaces;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Test;
using BaiTapLonWinForm.View.Admin.Students;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OfficeOpenXml;

namespace BaiTapLonWinForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // đăng ký excel của EPPlus
            ExcelPackage.License.SetNonCommercialPersonal(Environment.UserName);
            // 1. Đọc file appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // 2. Tạo ServiceCollection để đăng ký các service (DI)
            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(config);

            // 3. Đăng ký DbContext EF Core
            services.AddDbContext<EnglishCenterDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("EnglishCenterDb")));

            //Đăng ký các repository cho Repository ở đây
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClassSessionRepository, ClassSessionRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IStudentFaceImageRepository, StudentFaceImageRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ITeacherAttendanceRepository, TeacherAttendanceRepository>();
            services.AddScoped<ITeacherFaceImageRepository, TeacherFaceImageRepository>();
            services.AddScoped<ISchoolDayRepository, SchoolDayRepository>();


            ////Đăng ký các service cho Service ở đây
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClassSessionService, ClassSessionService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<ICompreFaceApiService, CompreFaceApiService>();
            services.AddScoped<IStudentFaceService, StudentFaceService>();
            services.AddScoped<ITeacherAttendanceService, TeacherAttendanceService>();
            services.AddScoped<ITeacherFaceService, TeacherFaceService>();
            services.AddScoped<ISchoolDayService, SchoolDayService>();


            //Dăng ký ServiceHub
            services.AddScoped<ServiceHub>();

            // 4. Đăng ký Form cần dùng DI

            services.AddTransient<HomePage>();
            services.AddTransient<StudentManagement>();
            services.AddTransient<AddStudentControl>();
            services.AddTransient<DashBoard>();

            //services.AddTransient<TestDataSeeder>();

            Application.EnableVisualStyles();
            // 5. Build provider
            var provider = services.BuildServiceProvider();

            // 6. Chạy WinForms
            ApplicationConfiguration.Initialize();

            // Tạo một Scope riêng để lấy Seeder ra, chạy xong thì hủy Scope để giải phóng RAM
            //using (var scope = provider.CreateScope())
            //{
            //    try
            //    {
            //        var seeder = scope.ServiceProvider.GetRequiredService<TestDataSeeder>();

            //        seeder.SeedAsync().GetAwaiter().GetResult();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show($"Lỗi khởi tạo dữ liệu Test: {ex.Message}");
            //    }
            //}

            

            Application.Run(provider.GetRequiredService<HomePage>());
        }
    }
}