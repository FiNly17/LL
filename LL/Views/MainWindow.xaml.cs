using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LL.Views
{
	/// <summary>
	/// Логика взаимодействия для Window_Of_Project.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static MainWindow Instance { get; private set; }
		public static Pages CurrentPage { get; private set; }

		public MainWindow()
		{
			InitializeComponent();
			Pages page = Pages.MainPage;
			Page content1 = new HomePage();
			CurrentPage = page;
			MainContent.Content = content1;
		}

		private void Image_MouseDown(object sender, MouseButtonEventArgs e)
		{
			Close();
		}

		public void SwitchPage(Pages page)
		{
			Page content;

			switch (page)
			{
				case Pages.MainPage:
					content = new HomePage();
					break;

				case Pages.CatalogPage:
					content = new CatalogPage();
					break;
				//case Pages.UsersInfo:
				//	content = new UsersInfoPage();
				//	break;
				default:
					MessageBox.Show("Страница не найдена");
					content = new HomePage();
					break;
			}

			CurrentPage = page;
			MainContent.Content = content;
		}

		private void MainPage_Button_Click(object sender, RoutedEventArgs e) => SwitchPage(Pages.MainPage);

		private void Catalog_Button_Click(object sender, RoutedEventArgs e) => SwitchPage(Pages.CatalogPage);

		//private void UsersInfo_Button_Click(object sender, RoutedEventArgs e) => SwitchPage(Pages.UsersInfo);
	}
}