using VisualStudioDownloader.Dialogs;
using VisualStudioDownloader.Helpers;
using VisualStudioDownloader.ViewModels;
using System.Windows;
using Ookii.Dialogs.Wpf;

namespace VisualStudioDownloader.Pages
{
    /// <summary>
    /// Interaction logic for <see cref="Zip"/>.xaml
    /// </summary>
    public partial class Zip : BasePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Zip"/> class.
        /// </summary>
        public Zip()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the ButtonNext control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            DialogBox dialogBox = new("CONFIRMATION", "Are you sure you want to zip the layout?", IconType.Warning);

            if (dialogBox.ShowDialog() == true)
            {
                var vm = DataContext as ZipViewModel;
                vm.Zip();
                               
                Navigator.Navigate(new Main());
            }
        }

        /// <summary>
        /// Handles the Click event of the ButtonBack control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            Navigator.Navigate(new Main() { PageLoadAnimation  = Animations.PageAnimation.SlideAndFadeInFromLeft});
        }

        /// <summary>
        /// Handles the Click event of the BrowseButton control and opens a folder browser dialog.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ButtonBrowse_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new VistaFolderBrowserDialog
            {
                Description = "Target directory for the .zip file.",
                UseDescriptionForTitle = true,
                ShowNewFolderButton = true
            };

            if (dialog.ShowDialog() == true)
            {
                TextBoxOutputPath.Text = dialog.SelectedPath;
            }
        }
    }
}
