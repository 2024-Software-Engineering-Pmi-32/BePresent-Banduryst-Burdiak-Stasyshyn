using bepresent_wpf.BLL;
using bepresent_wpf.DAL;
using System.Globalization;
using System;
using System.Windows;
using System.Windows.Data;



namespace bepresent_wpf.Presentation
{
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
        private readonly IGiftService _giftService;
        private readonly int _boardId;

        public AddGiftWindow(int boardId)
        {
            InitializeComponent();
            _boardId = boardId;
            _giftService = new GiftService(new GiftRepository(new DataContext()));
            InitializePlaceholders(); 
        }

        private void InitializePlaceholders()
        {
            NamePlaceholder.Visibility = string.IsNullOrEmpty(NameTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
            DescriptionPlaceholder.Visibility = string.IsNullOrEmpty(DescriptionTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void AddGiftButton_Click(object sender, RoutedEventArgs e)
        {
            _giftService.AddGift(NameTextBox.Text, DescriptionTextBox.Text, _boardId);
            MessageBox.Show("Gift added successfully!");
            Close();
        }

        private void NameTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            NamePlaceholder.Visibility = string.IsNullOrEmpty(NameTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }

        private void DescriptionTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            DescriptionPlaceholder.Visibility = string.IsNullOrEmpty(DescriptionTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
