using System.Windows;
using System.Windows.Controls;

using LL.ViewModels;

namespace LL.Views
{
	/// <summary>
	/// Логика взаимодействия для Window_Of_Project.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public static MainWindow Instance { get; private set; }
		public Pages CurrentPage { get; private set; }

		public MainWindow()
		{
			InitializeComponent();
			Instance = this;
			SwitchPage(Pages.MainPage);
			(DataContext as MainViewModel).CloseRequest += (sender, e) => Close();
		}

		public void Refresh() => SwitchPage(CurrentPage);

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

				case Pages.BookmarkPage:
					content = new BookmarksPage();
					break;

				default:
					MessageBox.Show("Страница не найдена");
					content = new HomePage();
					break;
			}

			CurrentPage = page;
			MainContent.Content = content;
		}

		private void Basket_Window_Click(object sender, RoutedEventArgs e)
		{
			BasketWindow bw = new BasketWindow();
			bw.ShowDialog();
		}

		private void MinimizeWindow_Button_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

		private void Close_Button_Click(object sender, RoutedEventArgs e) => Close();

		private void MainPage_Button_Click(object sender, RoutedEventArgs e) => SwitchPage(Pages.MainPage);

		private void BookmarksPage_Button_Click(object sender, RoutedEventArgs e) => SwitchPage(Pages.BookmarkPage);

		private void Catalog_Button_Click(object sender, RoutedEventArgs e) => SwitchPage(Pages.CatalogPage);

		//private void UsersInfo_Button_Click(object sender, RoutedEventArgs e) => SwitchPage(Pages.UsersInfo);
	}
}