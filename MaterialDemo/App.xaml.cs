using MaterialDemo.Domain;
using MaterialDemo.Models;
using MaterialDemo.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;

namespace MaterialDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IConfiguration Configuration { get; private set; }
        public static IServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 加载配置
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();

            // 配置服务
            var services = new ServiceCollection();
            ConfigureServices(services);

            // 构建服务提供程序
            ServiceProvider = services.BuildServiceProvider();

            // 注册登录窗口
            services.AddTransient<LoginWindow>();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            //// 注册 UserService
            //services.AddTransient<UserService>();

            //// 注册 ViewModel
            //services.AddTransient<LoginViewModel>();

            //// 注册 ViewModel
            //services.AddTransient<LoginViewModel>();

        }
    }

}
