using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Implementations;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Services.Implementations;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Views.SystemAcess.Login;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;
namespace BaiTapLonWinForm
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            // 1. Đọc file appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // 2. Tạo ServiceCollection để đăng ký các service (DI)
            var services = new ServiceCollection();



            // 3. Đăng ký DbContext EF Core
            services.AddDbContext<EnglishCenterDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("EnglishCenterDb")));

            //services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            //Đăng ký các service cho Service ở đây
            //services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<ServiceHub>();


            // 4. Đăng ký Form cần dùng DI
            services.AddTransient<Form1>();
            services.AddTransient<LoginForm>();
            // 5. Build provider
            var provider = services.BuildServiceProvider();
            // 6. Chạy WinForms
            ApplicationConfiguration.Initialize();
            Application.Run(provider.GetRequiredService<LoginForm>());
        }
    }
}