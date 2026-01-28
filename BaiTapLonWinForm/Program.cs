using BaiTapLonWinForm.Models;
using BaiTapLonWinForm.Mongo;
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
using BaiTapLon_WinFormApp.Views.Admin.HomePage;
using BaiTapLonWinForm.CoreSystem;
using BaiTapLonWinForm.Data;
using BaiTapLonWinForm.Test;
using BaiTapLonWinForm.View.Admin.Students;
using OfficeOpenXml;

namespace BaiTapLonWinForm
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // Đăng ký excel của EPPlus
            ExcelPackage.License.SetNonCommercialPersonal(Environment.UserName);

            // 1️⃣ Load appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // 2️⃣ ServiceCollection
            var services = new ServiceCollection();

            services.AddSingleton<IConfiguration>(config);

            services.AddDbContext<EnglishCenterDbContext>(options =>
            {
                var connectionString = config.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            // Repositories
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IReceiptRepository, ReceiptRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISchoolDayRepository, SchoolDayRepository>();
            services.AddScoped<IClassSessionRepository, ClassSessionRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IStudentFaceImageRepository, StudentFaceImageRepository>();
            services.AddScoped<ITeacherAttendanceRepository, TeacherAttendanceRepository>();
            services.AddScoped<ITeacherFaceImageRepository, TeacherFaceImageRepository>();
            services.AddScoped<IAssignmentRepository, AssignmentRepository>();
            services.AddScoped<INewsfeedRepository, NewsfeedRepository>();
            services.AddScoped<ISubmissionRepository, SubmissionRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IReceiptService, ReceiptService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ISchoolDayService, SchoolDayService>();
            services.AddScoped<IClassSessionService, ClassSessionService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IStudentFaceService, StudentFaceService>();
            services.AddScoped<ITeacherAttendanceService, TeacherAttendanceService>();
            services.AddScoped<ITeacherFaceService, TeacherFaceService>();
            services.AddScoped<ICompreFaceApiService, CompreFaceApiService>();
            services.AddScoped<IAssignmentService, AssignmentService>();
            services.AddScoped<INewsfeedService, NewsfeedService>();
            services.AddScoped<ISubmissionService, SubmissionService>();

            services.AddScoped<ServiceHub>();

            var mongoSettings = new MongoDbSettings();
            config.GetSection("MongoDbSettings").Bind(mongoSettings);

            services.AddSingleton(mongoSettings);
            services.AddSingleton<MongoDbContext>();

            services.AddTransient<StudentForm>();
            services.AddTransient<TeacherPage>();
            services.AddTransient<Form1>();
            services.AddTransient<LoginForm>();
            services.AddTransient<TestDataSeeder>();
            services.AddTransient<HomePage>();
            services.AddTransient<StudentManagement>();
            services.AddTransient<AddStudentControl>();
            services.AddTransient<DashBoard>();

            // 3️⃣ Build DI container
            var provider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            // Seed test data
            using (var scope = provider.CreateScope())
            {
                try
                {
                    var seeder = scope.ServiceProvider.GetRequiredService<TestDataSeeder>();
                    seeder.SeedAsync().GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khởi tạo dữ liệu Test: {ex.Message}");
                }
            }

            SettingsManager.LoadSettings();

            var loginForm = provider.GetRequiredService<LoginForm>();
            Application.Run(loginForm);
        }
    }
}