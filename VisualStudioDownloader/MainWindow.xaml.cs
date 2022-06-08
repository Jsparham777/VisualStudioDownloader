using System;
using System.Reflection;
using System.Windows;
using VisualStudioDownloader.Dialogs;
using VisualStudioDownloader.Pages;
using VisualStudioDownloader.Services;

namespace VisualStudioDownloader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IBootstrapperService _bootstrapperService;

        /// <summary>
        /// Initialises a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="bootstrapperService"></param>
        public MainWindow(IBootstrapperService bootstrapperService)
        {
            InitializeComponent();

            RefreshMaximiseRestoreButton();

            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;

            mainFrame.Content = new Main();
            
            _bootstrapperService = bootstrapperService;
        }
        
        /// <summary>
        /// Called when [minimise button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnMinimiseButtonClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// Called when [maximise restore button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnMaximiseRestoreButtonClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        /// <summary>
        /// Called when [close button click].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnCloseButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Refreshes the maximise restore button.
        /// </summary>
        private void RefreshMaximiseRestoreButton()
        {
            if (WindowState == WindowState.Maximized)
            {
                MaximiseButton.Visibility = Visibility.Collapsed;
                RestoreButton.Visibility = Visibility.Visible;
            }
            else
            {
                MaximiseButton.Visibility = Visibility.Visible;
                RestoreButton.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Handles the StateChanged event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Window_StateChanged(object sender, System.EventArgs e)
        {
            RefreshMaximiseRestoreButton();
        }

        /// <summary>
        /// Displays the help window control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpButtonClick(object sender, RoutedEventArgs e)
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            string bootstrapperCaption = "";
            string versionCaption =
                $"Application Information\n" +
                $"Version: {version} \n" +
                $"Author: J. Sparham\n\n";
            
            try
            {                
                var bootstrapperInfo = _bootstrapperService.IdentifyBootstrapper();

                bootstrapperCaption =
                    $"Bootstrapper Information\n" +
                    $"Product Name: {bootstrapperInfo.ProductName}\n" +
                    $"Product Version: {bootstrapperInfo.ProductVersion}\n" +
                    $"Version: {bootstrapperInfo.Version}\n" +
                    $"Path: {bootstrapperInfo.FilePath}";
            }
            catch (Exception)
            {
                bootstrapperCaption = "Bootstrapper not found.\nYou can change this directory in the appsettings.json file";
            }
            finally
            {
                DialogBox dialog = new("INFORMATION", versionCaption + bootstrapperCaption, IconType.Information, true)
                {
                    SizeToContent = SizeToContent.Height
                };

                _ = dialog.ShowDialog();
            }
        }
    }
}
