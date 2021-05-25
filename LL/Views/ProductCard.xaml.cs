using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace LL.Views
{
	/// <summary>
	/// Логика взаимодействия для ProductCard.xaml
	/// </summary>
	public partial class ProductCard : UserControl
	{
		public ProductCard()
		{
			InitializeComponent();
		}

		private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			var img = sender as Image;
			var uriSource = new Uri("C:\\Studing\\Курсовой проект\\LL\\LL\\Images\\heart2.png");
			if (img != null)
				img.Source = new BitmapImage(uriSource);
		}
	}
}