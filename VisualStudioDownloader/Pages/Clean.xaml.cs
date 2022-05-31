using VisualStudioDownloader.Dialogs;
using VisualStudioDownloader.Helpers;
using VisualStudioDownloader.ViewModels;
using System.Windows;

namespace VisualStudioDownloader.Pages
{
    /// <summary>
    /// Interaction logic for <see cref="Clean"/>.xaml
    /// </summary>
    public partial class Clean : BasePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Clean"/> class.
        /// </summary>
        public Clean()
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
            DialogBox dialogBox = new("CONFIRMATION", "Are you sure you want to remove the archived packages?", IconType.Warning);

            if (dialogBox.ShowDialog() == true)
            {
                var vm = DataContext as CleanViewModel;
                vm.Clean();
                               
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
    }
}
