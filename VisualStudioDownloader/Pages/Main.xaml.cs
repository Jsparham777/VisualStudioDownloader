using VisualStudioDownloader.Helpers;
using System.Windows;

namespace VisualStudioDownloader.Pages
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : BasePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Main"/> class.
        /// </summary>
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Loads the <see cref="Download"/> page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonDownload_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Navigate(new Download());
        }

        /// <summary>
        /// Loads the <see cref="Update"/> page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Navigate(new Update());
        }

        /// <summary>
        /// Loads the <see cref="Install"/> page.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonInstall_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Navigate(new Install());
        }
    }
}
