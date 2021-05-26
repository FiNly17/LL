using System.Windows;
using System.Windows.Input;

using LL.ViewModels;

namespace LL.Views
{
	/// <summary>
	/// Логика взаимодействия для RegistrationWindow.xaml
	/// </summary>
	public partial class RegistrationWindow : Window
	{
		public RegistrationWindow()
		{
			InitializeComponent();
			(DataContext as RegistrationViewModel).CloseRequest += (sender, e) => Close();
		}

		private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
				DragMove();
		}

		private void Minimize_Button_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

		private void Close_Button_Click(object sender, RoutedEventArgs e) => Close();
	}
}