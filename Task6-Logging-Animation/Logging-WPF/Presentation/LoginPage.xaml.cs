namespace bepresent_wpf.Presentation
{
    using bepresent_wpf.BLL;
    using bepresent_wpf.DAL;
    using Serilog; 
    using System;
    using System.Windows;
    using System.Windows.Controls;

    public partial class LoginPage : Page
    {
        private readonly IUserService UserService;

        public LoginPage()
        {
            InitializeComponent();
            UserService = new UserService(new UserRepository(new DataContext()));
            Log.Information("LoginPage initialized.");
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Log.Debug("UsernameTextBox text changed: {Text}", UsernameTextBox.Text);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Log.Debug("PasswordBox content changed.");
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var username = UsernameTextBox.Text;
            var password = PasswordBox.Password;

            try
            {
                Log.Information("Login attempt with username: {Username}", username);

                var user = UserService.GetUser(username);
                if (user != null)
                {
                    Log.Information("User {Username} successfully logged in with user ID: {UserId}", username, user.user_id);

                    MessageBox.Show("Welcome back!");
                    NavigationService?.Navigate(new BoardsPage(user.user_id));
                }
                else
                {
                    Log.Warning("Invalid login attempt for username: {Username}", username);

                    MessageBox.Show("Invalid username or password.");
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred during login for username: {Username}", username);
                MessageBox.Show("An unexpected error occurred. Please try again later.");
            }
        }
    }
}
