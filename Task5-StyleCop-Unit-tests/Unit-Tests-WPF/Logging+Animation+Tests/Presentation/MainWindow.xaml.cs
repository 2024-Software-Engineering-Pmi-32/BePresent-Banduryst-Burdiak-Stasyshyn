

namespace bepresent_wpf.Presentation
{
    using System.Windows;
    public partial class MainWindow : Window
    {
        private RegistrationWindow RegistrationWindow;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            MainContent.Visibility = Visibility.Collapsed;
            ContentFrame.Visibility = Visibility.Visible;
            var loginPage = new LoginPage();
            ContentFrame.Navigate(loginPage);
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (RegistrationWindow == null || !RegistrationWindow.IsVisible)
            {
                RegistrationWindow = new RegistrationWindow();
                RegistrationWindow.Show();
                Close();
            }
            else
            {
                RegistrationWindow.Activate();
            }
        }
    }
}
