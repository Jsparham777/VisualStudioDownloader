using Microsoft.Extensions.Options;

namespace VisualStudioDownloader.ViewModels
{
    /// <summary>
    /// Main window view model.
    /// </summary>
    /// <seealso cref="BaseViewModel" />
    public class MainWindowViewModel : BaseViewModel
    {
        /// <summary>
        /// The window title.
        /// </summary>
        public string WindowTitle { get; set; } = "Visual Studio Downloader";

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public MainWindowViewModel(IOptions<AppSettings> settings)
        {
            switch (settings.Value.Environment.ToLower())
            {                
                case "development":
                    WindowTitle += " [DEVELOPMENT]";
                    break;
                default:
                    break;
            }
        }
    }
}