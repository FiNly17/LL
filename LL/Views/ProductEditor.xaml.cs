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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LL.Views
{
	/// <summary>
	/// Логика взаимодействия для ProductEditorPage.xaml
	/// </summary>
	public partial class ProductEditorPage : Page
	{
		public ProductEditorPage()
		{
			InitializeComponent();
			ShoesSize_Stackpanel.Visibility = Visibility.Collapsed;
			ClothingSize_ComboBox.Visibility = Visibility.Collapsed;
		}

		private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var index = (sender as ComboBox).SelectedIndex;
			switch (index)
			{
				case 0:
					ShoesSize_Stackpanel.Visibility = Visibility.Collapsed;
					ClothingSize_ComboBox.Visibility = Visibility.Visible;
					break;

				case 1:
					ShoesSize_Stackpanel.Visibility = Visibility.Visible;
					ClothingSize_ComboBox.Visibility = Visibility.Collapsed;
					break;

				default:
					ShoesSize_Stackpanel.Visibility = Visibility.Collapsed;
					ClothingSize_ComboBox.Visibility = Visibility.Collapsed;
					break;
			}
		}
	}
}