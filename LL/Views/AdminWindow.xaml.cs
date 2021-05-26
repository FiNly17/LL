using System.Windows;
using System.Windows.Controls;

using LL.ViewModels;

namespace LL.Views
{
	/// <summary>
	/// Логика взаимодействия для AdminWindow.xaml
	/// </summary>
	public partial class AdminWindow : Window
	{
		public static AdminWindow Instance { get; private set; }
		public static AdminPages CurrentPage { get; private set; }

		public AdminWindow()
		{
			InitializeComponent();
			Instance = this;

			if (!(DataContext as AdminViewModel).IsMajorAdmin)
				Admins_Button.Visibility = Visibility.Collapsed;
		}

		public void Refresh() => SwitchPage(CurrentPage);

		public void SwitchPage(AdminPages page)
		{
			Page content;

			switch (page)
			{
				case AdminPages.Products:
					content = new ProductsTablePage();
					break;

				case AdminPages.Users:
					content = new UsersTablePage();
					break;

				case AdminPages.Admins:
					content = new AdminsTablePage();
					break;

				case AdminPages.Editor:
					content = new ProductEditorPage();
					break;

				case AdminPages.Orders:
					break;

				case AdminPages.OrdersHistory:
					break;

				default:
					content = new ProductsTablePage();
					page = AdminPages.Admins;
					break;
			}

			CurrentPage = page;
			Main.Content = content;
		}

		private void Products_Button_Click(object sender, RoutedEventArgs e) => SwitchPage(AdminPages.Products);

		private void ProductEditor_Button_Click(object sender, RoutedEventArgs e) => SwitchPage(AdminPages.Editor);

		private void Users_Button_Click(object sender, RoutedEventArgs e) => SwitchPage(AdminPages.Users);

		private void Admins_Button_Click(object sender, RoutedEventArgs e) => SwitchPage(AdminPages.Admins);

		private void Orders_Button_Click(object sender, RoutedEventArgs e)
		{
		}

		private void OrdersHistory_Button_Click(object sender, RoutedEventArgs e)
		{
		}
	}
}