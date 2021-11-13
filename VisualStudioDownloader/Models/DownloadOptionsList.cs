using System.Collections.Generic;

namespace VisualStudioDownloader.Models
{
    /// <summary>
    /// Stores the options for the session.
    /// </summary>
    /// <seealso cref="IDownloadOptionsList" />
    public class DownloadOptionsList : IDownloadOptionsList
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public Dictionary<string, bool> Options { get; set; } = new();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public void Clear()
        {
            Options.Clear();
        }
    }
}
