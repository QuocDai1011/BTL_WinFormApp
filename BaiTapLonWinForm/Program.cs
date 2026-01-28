using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Mongo; // hoặc namespace MongoDbContext
using BaiTapLonWinForm.Repositories.Implementations;
using BaiTapLonWinForm.Repositories.Interfaces;
using BaiTapLonWinForm.Services;
using BaiTapLonWinForm.Services.Implementations;
using BaiTapLonWinForm.Services.Interfaces;
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
            // 1️⃣ Load appsettings.json (GIỮ NGUYÊN)
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // 2️⃣ ServiceCollection (GIỮ NGUYÊN)
            var services = new ServiceCollection();

            // ===================== SQL SERVER (GIỮ NGUYÊN) =====================
            services.AddDbContext<EnglishCenterDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("EnglishCenterDb")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ISchoolDayRepository, SchoolDayRepository>();
            services.AddScoped<IAssignmentRepository, AssignmentRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ISchoolDayService, SchoolDayService>();
            services.AddScoped<IAssignmentService, AssignmentService>();

            services.AddScoped<INewsfeedRepository, NewsfeedRepository>();
            services.AddScoped<INewsfeedService, NewsfeedService>();
            services.AddScoped<ISubmissionRepository, SubmissionRepository>();
            services.AddScoped<ISubmissionService, SubmissionService>();
            services.AddScoped<ServiceHub>();

            // ===================== ⬇⬇⬇ MONGODB (THÊM MỚI) ⬇⬇⬇ =====================
            var mongoSettings = new MongoDbSettings();
            config.GetSection("MongoDbSettings").Bind(mongoSettings);

            services.AddSingleton(mongoSettings);
            services.AddSingleton<MongoDbContext>();
            // =====================================================================

            // 3️⃣ Forms (GIỮ NGUYÊN)
            services.AddTransient<Form1>();
            services.AddTransient<LoginForm>();
            services.AddTransient<TeacherPage>();

            // 4️⃣ Build & Run
            var provider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();
            Application.Run(provider.GetRequiredService<LoginForm>());
            //Application.Run(provider.GetRequiredService<Form1>());
        }
    }
}
