using Ionic.Zip;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;

namespace VisualStudioDownloader.Services
{
    /// <summary>
    /// Provides zipping functionality.
    /// </summary>
    public class ZippingService : IZippingService
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="sourceDirectoryPath"><inheritdoc/></param>
        /// <param name="outputPath"><inheritdoc/></param>
        /// <param name="splitSize"><inheritdoc/></param>
        public void ZipDirectory(string sourceDirectoryPath, string outputPath, int splitSize = 0)
        {
            using ZipFile zip = new();
            zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
            zip.AddDirectory(sourceDirectoryPath, directoryPathInArchive: string.Empty);

            if (splitSize != 0)
            {
                long segmentSize = 1024 * 1024 * (long)splitSize;
                zip.MaxOutputSegmentSize64 = segmentSize;
            }

            // Open the output directory in File Explorer
            Process.Start("explorer.exe", Path.GetDirectoryName(outputPath));

            zip.Save(outputPath);
        }
    }
}
