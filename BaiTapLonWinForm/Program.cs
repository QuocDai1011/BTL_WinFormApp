using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Repositories.Implementations;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Services.Implementations;
using BaiTapLonWinForm.Services.Interfaces;
using BaiTapLonWinForm.Views.Student;
using BaiTapLonWinForm.Views.SystemAcess.Login;
using BaiTapLonWinForm.Views.Teacher;
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
            services.AddScoped<IReceiptRepository, ReceiptRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISchoolDayRepository, SchoolDayRepository>();


            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IReceiptService, ReceiptService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISchoolDayService, SchoolDayService>();

            services.AddScoped<ServiceHub>();


            // Register Form
            services.AddTransient<StudentForm>();
            services.AddTransient<TeacherPage>();
            services.AddTransient<Form1>();
            services.AddTransient<LoginForm>();
            services.AddTransient<TeacherPage>();

            // Build DI container
            var provider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            // Lấy form từ DI
            var mainForm = provider.GetRequiredService<StudentForm>();
            //var teacherForm = provider.GetRequiredService<TeacherPage>();
            var loginForm = provider.GetRequiredService<LoginForm>();

            Application.Run(mainForm);
        }
    }
}
