using System.Windows;

using LL.ViewModels;

namespace LL.Views
{
	/// <summary>
	/// Логика взаимодействия для ProductInfoWindow.xaml
	/// </summary>
	public partial class ProductInfoWindow : Window
	{
		public ProductInfoWindow()
		{
			InitializeComponent();
			CheckReview();
			(DataContext as ProductInfoViewModel).Reviewed += (sender, e) => CheckReview();
		}

		private void CheckReview()
		{
			if ((DataContext as ProductInfoViewModel).IsReviewed)
				NewReview_StackPanel.Visibility = Visibility.Collapsed;
		}

		private void MinimizeWindow_Button_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

		private void Close_Button_Click(object sender, RoutedEventArgs e) => Close();
	}
}