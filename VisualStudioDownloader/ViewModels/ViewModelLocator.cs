using Microsoft.Extensions.DependencyInjection;

namespace VisualStudioDownloader.ViewModels
{
    /// <summary>
    /// Locates the applicable viewmodel, from the IoC container, for a given view.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Gets the <see cref="MainViewModel"/> from the IoC container.
        /// </summary>
        public MainViewModel MainViewModel => App.ServiceProvider.GetRequiredService<MainViewModel>();

        /// <summary>
        /// Gets the <see cref="MainWindowViewModel"/> from the IoC container.
        /// </summary>
        public MainWindowViewModel MainWindowViewModel => App.ServiceProvider.GetRequiredService<MainWindowViewModel>();

        /// <summary>
        /// Gets the <see cref="DownloadViewModel"/> from the IoC container.
        /// </summary>
        public DownloadViewModel DownloadViewModel => App.ServiceProvider.GetRequiredService<DownloadViewModel>();

        /// <summary>
        /// Gets the <see cref="UpdateViewModel"/> from the IoC container.
        /// </summary>
        public UpdateViewModel UpdateViewModel => App.ServiceProvider.GetRequiredService<UpdateViewModel>();

        /// <summary>
        /// Gets the <see cref="InstallViewModel"/> from the IoC container.
        /// </summary>
        public InstallViewModel InstallViewModel => App.ServiceProvider.GetRequiredService<InstallViewModel>();
    }
}
