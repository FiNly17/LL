using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LL.View
{
    /// <summary>
    /// Логика взаимодействия для Window_Of_Project.xaml
    /// </summary>
    public partial class Window_Of_Project : Window
    {
		public static Window_Of_Project Instance { get; private set; }
		public static Pages CurrentPage { get; private set; }
		public Window_Of_Project()
        {
            InitializeComponent();
			Pages page = Pages.MainPage;
			Page content1 = new MainPage();
			CurrentPage = page;
			MainContent.Content = content1;
		}

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

		public void SwitchPage(Pages page)
		{
			Page content;

			switch (page)
			{
				case Pages.MainPage:
					content = new MainPage();
					break;
				case Pages.CatalogPage:
					content = new CatalogPage();
					break;
				//case Pages.UsersInfo:
				//	content = new UsersInfoPage();
				//	break;
				default:
					MessageBox.Show("Страница не найдена");
					content = new MainPage();
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
