using System.Windows;

using LL.ViewModels;
using LL.Services;
using LL.Models;

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
			if ((DataContext as ProductInfoViewModel).IsReviewed)
				NewReview_StackPanel.Visibility = Visibility.Collapsed;
		}

		private void MinimizeWindow_Button_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

		private void Close_Button_Click(object sender, RoutedEventArgs e) => Close();
	}
}