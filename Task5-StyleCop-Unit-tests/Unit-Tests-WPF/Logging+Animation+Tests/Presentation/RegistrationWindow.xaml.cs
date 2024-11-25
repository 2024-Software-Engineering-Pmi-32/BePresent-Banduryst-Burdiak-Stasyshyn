namespace bepresent_wpf.Presentation
{
    using bepresent_wpf.BLL;
    using bepresent_wpf.DAL;
    using Serilog;
    using System;
    using System.Windows;
    using System.Windows.Controls;


    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException() { }

        public UserAlreadyExistsException(string message)
            : base(message) { }

        public UserAlreadyExistsException(string message, Exception inner)
            : base(message, inner) { }
    }

    public partial class RegistrationWindow : Window
    {
        private readonly IUserService UserService;

        public RegistrationWindow()
        {
            InitializeComponent();
            UserService = new UserService(new UserRepository(new DataContext()));
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameTextBox.Text) || string.IsNullOrWhiteSpace(PasswordBox.Password))
            {
                MessageBox.Show("Username and password cannot be empty.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (PasswordBox.Password.Length < 6)
            {
                MessageBox.Show("Password must be at least 6 characters long.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                Log.Information("Attempting to register user: {Username}", UsernameTextBox.Text);

                UserService.Register(UsernameTextBox.Text, PasswordBox.Password);

                MessageBox.Show("Registration successful! You can now log in.");
                Log.Information("User {Username} registered successfully.", UsernameTextBox.Text);

                Close();
            }
            catch (UserAlreadyExistsException)
            {
                Log.Warning("Registration failed for {Username}: Username already exists.", UsernameTextBox.Text);
                MessageBox.Show("The username is already taken. Please choose another one.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An error occurred during registration for {Username}", UsernameTextBox.Text);
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void UsernameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdatePlaceholderOpacity(UsernameTextBox, UsernamePlaceholder);
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            UpdatePlaceholderOpacity(PasswordBox, PasswordPlaceholder);
        }

        private void UpdatePlaceholderOpacity(TextBox textBox, FrameworkElement placeholder)
        {
            placeholder.Opacity = string.IsNullOrEmpty(textBox.Text) ? 1.0 : 0.0;
        }

        private void UpdatePlaceholderOpacity(PasswordBox passwordBox, FrameworkElement placeholder)
        {
            placeholder.Opacity = string.IsNullOrEmpty(passwordBox.Password) ? 1.0 : 0.0;
        }
    }
}
