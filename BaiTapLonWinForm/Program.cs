using BaiTapLon_WinFormApp.Views.Admin.HomePage;
using BaiTapLonWinForm.Data;
using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.implements;
using BaiTapLonWinForm.Repositories.interfaces;
using BaiTapLonWinForm.Repository.implements;
using BaiTapLonWinForm.Repository.interfaces;
using BaiTapLonWinForm.Service.implements;
using BaiTapLonWinForm.Service.interfaces;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Services.implements;
using BaiTapLonWinForm.Services.interfaces;
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
            ExcelPackage.License.SetNonCommercialPersonal(Environment.UserName);

            // 1. Đọc file appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // 2. Tạo ServiceCollection để đăng ký các service (DI)
            var services = new ServiceCollection();

            // 3. Đăng ký DbContext EF Core
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("EnglishCenterDb")));

            //Đăng ký các repository cho Repository ở đây
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            ////Đăng ký các service cho Service ở đây
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IUserService, UserService>();


            //Dăng ký ServiceHub
            services.AddScoped<ServiceHub>();

            // 4. Đăng ký Form cần dùng DI

            services.AddTransient<HomePage>();
            services.AddTransient<StudentManagement>();
            services.AddTransient<StudentFormDialog>();
            services.AddTransient<DashBoard>();


            Application.EnableVisualStyles();
            // 5. Build provider
            var provider = services.BuildServiceProvider();

            // 6. Chạy WinForms
            ApplicationConfiguration.Initialize();
            Application.Run(provider.GetRequiredService<HomePage>());
        }
    }
}