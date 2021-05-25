using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace LL.Views
{
	/// <summary>
	/// Логика взаимодействия для CatalogPage.xaml
	/// </summary>
	public partial class CatalogPage : Page
	{
		public CatalogPage()
		{
			InitializeComponent();
		}

		public void CreatePr(object sender, RoutedEventArgs e)
		{
			Product blck = new Product();
			var uriSource = new Uri("C:\\Studing\\Курсовой проект\\LL\\LL\\Images\\heart2.png");
			blck.PhotoPr.Source = new BitmapImage(uriSource);
			blck.Price.Text = "22,00";
			blck.Company.Text = "Adidas";
			blck.Size.Text = "39";
			blck.Height = 400;
			blck.Width = 300;
			Catalogs.Children.Add(blck);
		}
	}
}