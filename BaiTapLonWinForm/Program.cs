using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Implementations;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services.Implementations;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Views.Student;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaiTapLonWinForm
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Load appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Register DI
            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(config);

            services.AddDbContext<EnglishCenterDbContext>(options =>
            {
                var connectionString = config.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IStudentService, StudentService>();

            services.AddScoped<IReceiptRepository, ReceiptRepository>();
            services.AddScoped<IReceiptService, ReceiptService>();

            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseService, CourseSesrvice>();

            // Register Form
            services.AddTransient<StudentForm>();

            // Build DI container
            var provider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            // Lấy form từ DI
            var mainForm = provider.GetRequiredService<StudentForm>();

            Application.Run(mainForm);
        }
    }
}
