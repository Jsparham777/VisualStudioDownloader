namespace VisualStudioDownloader
{
    /// <summary>
    /// Application settings.
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Path to the the Visual Studio bootstrapper exe.
        /// </summary>
        public string BootstrapperPath { get; set; }

        /// <summary>
        /// Production or Development environment.
        /// </summary>
        public string Environment { get; set; }
    }
}
