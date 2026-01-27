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

            //Bind appsettings.json
            var mongoSettings = new MongoDbSettings();
            config.GetSection("MongoDbSettings").Bind(mongoSettings);

            // Register DI
            var services = new ServiceCollection();
            services.AddSingleton(mongoSettings);
            services.AddSingleton<MongoDbContext>();

            services.AddSingleton<IConfiguration>(config);

            services.AddDbContext<EnglistCenterContext>(options =>
            {
                var connectionString = config.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IReceiptRepository, ReceiptRepository>();


            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IReceiptService, ReceiptService>();
            services.AddScoped<ICourseService, CourseSesrvice>();
            services.AddScoped<INewsfeedService, NewsfeedService>();

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
