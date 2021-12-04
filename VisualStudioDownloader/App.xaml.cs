using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using VisualStudioDownloader.Dialogs;
using VisualStudioDownloader.Models;
using VisualStudioDownloader.Services;
using VisualStudioDownloader.ViewModels;

namespace VisualStudioDownloader
{
    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;

        /// <summary>
        /// Gets the service provider.
        /// </summary>
        public static IServiceProvider ServiceProvider { get; private set; }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public IConfiguration Configuration { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public App()
        {
            _host = Host.CreateDefaultBuilder()
               .ConfigureServices((context, services) =>
               {
                   ConfigureServices(context.Configuration, services);
               })
               .Build();

            ServiceProvider = _host.Services;
        }

        /// <summary>
        /// Adds services to the IoC container.
        /// </summary>
        /// <param name="services">Service collection.</param>
        private void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
            //Add the settings read from the appsettings.json
            services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));

            //Register services
            services.AddSingleton<IDownloadOptionsList, DownloadOptionsList>();
            services.AddSingleton<IBootstrapperService, BootstrapperService>();
            services.AddSingleton<IFileHandler, FileHandler>();
            services.AddSingleton<ICertificateService, CertificateService>();

            //Register viewmodels                       
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<DownloadViewModel>();
            services.AddTransient<UpdateViewModel>();
            services.AddTransient<InstallViewModel>();

            //Register the Main window
            services.AddTransient(typeof(MainWindow));
        }

        /// <summary>
        /// Triggered on application startup .
        /// </summary>
        /// <param name="e">Startup event arguments.</param>
        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();

            MainWindow window = ServiceProvider.GetRequiredService<MainWindow>();
            window.Show();

            // Catch exceptions from all threads in the AppDomain.
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => ShowUnhandledException(args.ExceptionObject as Exception);

            // Catch exceptions from each AppDomain that uses a task scheduler for async operations.
            TaskScheduler.UnobservedTaskException += (sender, args) => ShowUnhandledException(args.Exception);

            // Catch exceptions from a single specific UI dispatcher thread.            
            Dispatcher.UnhandledException += (sender, args) =>
            {
                args.Handled = true;
                ShowUnhandledException(args.Exception);
            };                 

            base.OnStartup(e);

            CheckBootstrapper();
        }

        /// <summary>
        /// Checks the path to the boostrapper, provided in the appsettings.json file, exists.
        /// </summary>
        /// <exception cref="FileNotFoundException">Thrown when the bootstrapper is not found.</exception>
        private void CheckBootstrapper()
        {
            var options = ServiceProvider.GetRequiredService<IOptions<AppSettings>>();

            var bootstrapperPath = Path.GetFullPath(options.Value.BootstrapperPath);

            // Determine if the path is valid
            if (!File.Exists(bootstrapperPath))
                throw new FileNotFoundException($"Boostrapper [{bootstrapperPath}] not found. Check the directory or the appsettings.json file.");
        }


        /// <summary>
        /// Handles exceptions to uncovered non-UI threads.
        /// </summary>
        /// <param name="e">The exception.</param>
        private void ShowUnhandledException(Exception e)
        {
            DialogBox dialogBox = new("ERROR", e.Message, IconType.Error, true);
            dialogBox.ShowDialog();
        }

        /// <summary>
        /// Triggered on application exit.
        /// </summary>
        /// <param name="e">Exit event arguments.</param>
        protected override async void OnExit(ExitEventArgs e)
        {
            using (_host)
            {
                await _host.StopAsync(TimeSpan.FromSeconds(5));
            }
            base.OnExit(e);
        }
    }
}
