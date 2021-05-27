using System.Windows.Controls;

using LL.ViewModels;

namespace LL.Views
{
	/// <summary>
	/// Логика взаимодействия для MainPage.xaml
	/// </summary>
	public partial class HomePage : Page
	{
		public HomePage()
		{
			InitializeComponent();
		}

		private void GoTo(string query)
		{
			CatalogViewModel.InitialQuery = query;
			MainWindow.Instance.SwitchPage(Pages.CatalogPage);
		}

		private void GoesSL_Click(object sender, System.Windows.RoutedEventArgs e) => GoTo("SCARLXRD");

		private void GoesGh_Click(object sender, System.Windows.RoutedEventArgs e) => GoTo("Ghostemane");

		private void GoesSS_Click(object sender, System.Windows.RoutedEventArgs e) => GoTo("$uicide Boy$");
	}
}