namespace bepresent_wpf.Presentation
{
    using bepresent_wpf.BLL;
    using bepresent_wpf.DAL;
    using Serilog; 
    using System.Globalization;
    using System;
    using System.Windows;
    using System.Windows.Data;

    public class StringToVisibilityConverter1 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string strValue)
            {
                return string.IsNullOrEmpty(strValue) ? Visibility.Collapsed : Visibility.Visible;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public partial class AddGiftWindow : Window
    {
        private readonly IGiftService GiftService;
        private readonly int BoardId;

        public AddGiftWindow(int boardId)
        {
            InitializeComponent();
            BoardId = boardId;
            Log.Information("Initializing AddGiftWindow for BoardId {BoardId}", boardId);

            GiftService = new GiftService(new GiftRepository(new DataContext()));
            InitializePlaceholders();
        }

        private void InitializePlaceholders()
        {
            try
            {
                NamePlaceholder.Visibility = string.IsNullOrEmpty(NameTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
                DescriptionPlaceholder.Visibility = string.IsNullOrEmpty(DescriptionTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
                Log.Information("Placeholders initialized successfully in AddGiftWindow.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error initializing placeholders in AddGiftWindow.");
            }
        }

        private void AddGiftButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Log.Information("Attempting to add gift with Name: {Name}, Description: {Description}, BoardId: {BoardId}",
                    NameTextBox.Text, DescriptionTextBox.Text, BoardId);

                GiftService.AddGift(NameTextBox.Text, DescriptionTextBox.Text, BoardId);
                MessageBox.Show("Gift added successfully!");
                Log.Information("Gift added successfully to BoardId {BoardId}.", BoardId);

                Close();
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error adding gift to BoardId {BoardId}.", BoardId);
                MessageBox.Show("An error occurred while adding the gift. Please try again.");
            }
        }

        private void NameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                NamePlaceholder.Visibility = string.IsNullOrEmpty(NameTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
                Log.Debug("NameTextBox updated: {Text}", NameTextBox.Text);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error updating NameTextBox in AddGiftWindow.");
            }
        }

        private void DescriptionTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            try
            {
                DescriptionPlaceholder.Visibility = string.IsNullOrEmpty(DescriptionTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
                Log.Debug("DescriptionTextBox updated: {Text}", DescriptionTextBox.Text);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error updating DescriptionTextBox in AddGiftWindow.");
            }
        }
    }
}
