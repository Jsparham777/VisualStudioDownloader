using System.Collections.Generic;

namespace VisualStudioDownloader.Models
{
    /// <summary>
    /// Download options list interface.
    /// </summary>
    public interface IDownloadOptionsList
    {
        /// <summary>
        /// Gets or sets the options list.
        /// </summary>
        Dictionary<string, bool> Options { get; set; }

        /// <summary>
        /// Clears the options list.
        /// </summary>
        void Clear();
    }
}
