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
			if ((DataContext as ProductInfoViewModel).IsReviewed)
				NewReview_StackPanel.Visibility = Visibility.Collapsed;
		}
	}
}