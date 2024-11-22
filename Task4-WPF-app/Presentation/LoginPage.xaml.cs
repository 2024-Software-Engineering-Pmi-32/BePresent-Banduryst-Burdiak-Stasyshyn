using bepresent_wpf.BLL;
using bepresent_wpf.DAL;
using System;
using System.Windows;
using System.Windows.Controls;

namespace bepresent_wpf.Presentation
{
    public partial class LoginPage : Page
    {
        private readonly IUserService _userService;

        public LoginPage()
        {
            InitializeComponent();
            _userService = new UserService(new UserRepository(new DataContext()));
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ///UsernamePlaceholder.Opacity = string.IsNullOrWhiteSpace(UsernameTextBox.Text) ? 1.0 : 0.0;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {

            //PasswordPlaceholder.Opacity = string.IsNullOrWhiteSpace(PasswordBox.Password) ? 1.0 : 0.0;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordBox.Password;

            var user = _userService.GetUser(username); 

            if (user != null)
            {
                MessageBox.Show("Welcome back!");
                NavigationService?.Navigate(new BoardsPage(user.user_id));
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }
    }
}
