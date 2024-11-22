using bepresent_wpf.BLL;
using bepresent_wpf.DAL;
using System.Windows;
using System.Windows.Controls;

namespace bepresent_wpf.Presentation
{
    public partial class RegistrationWindow : Window
    {
        private readonly IUserService _userService;

        public RegistrationWindow()
        {
            InitializeComponent();
            _userService = new UserService(new UserRepository(new DataContext()));
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            _userService.Register(UsernameTextBox.Text, PasswordBox.Password);
            MessageBox.Show("Registration successful! You can now log in.");
            Close();
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UsernamePlaceholder.Opacity = UsernameTextBox.Text.Length > 0 ? 0.0 : 1.0;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordPlaceholder.Opacity = PasswordBox.Password.Length > 0 ? 0.0 : 1.0;
        }
    }
}
