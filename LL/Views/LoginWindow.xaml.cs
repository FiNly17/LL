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

		private void ExitButton_MouseDown(object sender, MouseButtonEventArgs e) => Close();

		private void Sv_MouseDown(object sender, MouseButtonEventArgs e) => WindowState = WindowState.Minimized;

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
				reg.Show();
				Close();
			}
		}
	}
}