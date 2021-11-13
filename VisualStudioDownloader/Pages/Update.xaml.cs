using VisualStudioDownloader.Dialogs;
using VisualStudioDownloader.Helpers;
using VisualStudioDownloader.ViewModels;
using System.Windows;

namespace VisualStudioDownloader.Pages
{
    /// <summary>
    /// Interaction logic for <see cref="Update"/>.xaml
    /// </summary>
    public partial class Update : BasePage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Update"/> class.
        /// </summary>
        public Update()
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
            DialogBox dialogBox = new("CONFIRMATION", "Are you sure you want to update the offline installation?", IconType.Warning);

            if (dialogBox.ShowDialog() == true)
            {
                var vm = DataContext as UpdateViewModel;
                vm.Update();
                               
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
