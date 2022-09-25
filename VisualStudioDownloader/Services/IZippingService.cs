namespace VisualStudioDownloader.Services
{
    /// <summary>
    /// Provides zipping functionality.
    /// </summary>
    public interface IZippingService
    {
        /// <summary>
        /// Zips the contents of a given directory.
        /// </summary>
        /// <param name="sourceDirectoryPath">The directory path to zip.</param>
        /// <param name="outputPath">The output .zip path.</param>
        /// <param name="splitSize">Split size in MBs.</param>
        void ZipDirectory(string sourceDirectoryPath, string outputPath, int splitSize = 0);
    }
}