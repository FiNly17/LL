using System.Windows;

using LL.ViewModels;

namespace LL.Views
{
	/// <summary>
	/// Логика взаимодействия для BasketWindow.xaml
	/// </summary>
	public partial class BasketWindow : Window
	{
		public static BasketWindow Instance { get; private set; }

		public BasketWindow()
		{
			InitializeComponent();
			Instance = this;
			(DataContext as BasketViewModel).CloseRequest += (sender, e) => Close();
		}

		private void MinimizeWindow_Button_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

		private void Close_Button_Click(object sender, RoutedEventArgs e)
		{
			Instance = null;
			Close();
		}
	}
}