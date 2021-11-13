namespace VisualStudioDownloader.Services
{
    /// <summary>
    /// Reads and writes content to a file.
    /// </summary>
    public interface IFileHandler
    {
        /// <summary>
        /// Writes string content to a file.
        /// </summary>
        /// <param name="content">The content to write to file.</param>
        void Write(string content);

        /// <summary>
        /// Reads string content from a file.
        /// </summary>
        /// <returns>The contents of the file.</returns>
        string Read();
    }
}