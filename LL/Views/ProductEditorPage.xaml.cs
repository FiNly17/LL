using System.Windows;
using System.Windows.Controls;

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
			if (ShoesSize_Stackpanel == null || ClothingSize_ComboBox == null)
				return;

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