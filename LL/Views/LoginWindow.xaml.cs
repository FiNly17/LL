using System.Windows;
using System.Windows.Input;

using LL.ViewModels;

namespace LL.Views
{
	/// <summary>
	/// Логика взаимодействия для LoginWindow.xaml
	/// </summary>
	public partial class LoginWindow : Window
	{
		public LoginWindow()
		{
			InitializeComponent();
			(DataContext as LoginViewModel).CloseRequest += (sender, e) => Close();
		}

		private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
				DragMove();
		}

		private void Create_Account(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
			{
				RegistrationWindow reg = new RegistrationWindow();
				reg.ShowDialog();
			}
		}

		private void MinimizeWindow_Button_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

		private void Close_Button_Click(object sender, RoutedEventArgs e) => Close();
	}
}