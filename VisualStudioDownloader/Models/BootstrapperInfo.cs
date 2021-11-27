﻿namespace VisualStudioDownloader.Models
{
    /// <summary>
    /// Holds information regarding the bootstrapper executable.
    /// </summary>
    public class BootstrapperInfo
    {
        /// <summary>
        /// The product name.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// The filename.
        /// </summary>
        public string Filename { get; set; }

        /// <summary>
        /// The version.
        /// </summary>
        public string Version { get; set; }
    }
}