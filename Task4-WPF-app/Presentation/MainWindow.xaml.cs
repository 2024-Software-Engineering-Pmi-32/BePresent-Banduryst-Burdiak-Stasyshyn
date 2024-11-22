using System.Windows;

namespace bepresent_wpf.Presentation
{
    public partial class MainWindow : Window
    {

        private LoginPage _loginWindow;
        private RegistrationWindow _registrationWindow;
        private BoardsPage _boardsWindow;

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
            if (_registrationWindow == null || !_registrationWindow.IsVisible)
            {
                _registrationWindow = new RegistrationWindow();
                _registrationWindow.Show();
                Close(); 
            }
            else
            {
                _registrationWindow.Activate(); 
            }
        }
    }
}
