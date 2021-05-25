using System.Windows;
using System.Windows.Input;

using LL.ViewModels;

namespace LL.Views
{
	/// <summary>
	/// Логика взаимодействия для MainWindow.xaml
	/// </summary>
	public partial class RegistrationWindow : Window
	{
		public RegistrationWindow()
		{
			InitializeComponent();
			(DataContext as RegistrationViewModel).CloseRequest += (sender, e) => Close();
		}

		private void ExitButton_MouseDown(object sender, MouseButtonEventArgs e)
		{
			Close();
		}

		private void Sv_MouseDown(object sender, MouseButtonEventArgs e)
		{
			WindowState = WindowState.Minimized;
		}

		private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ChangedButton == MouseButton.Left)
				DragMove();
		}

		public bool IsExists(object sender, object sender2)
		{
			return true;
		}

		private void Authoris_Click(object sender, RoutedEventArgs e)
		{
		}

		private void Reg_Click(object sender, RoutedEventArgs e)
		{
		}

		private void myButton_MouseDown(object sender, MouseButtonEventArgs e)
		{
			MessageBox.Show("Logged in!", "Success");
			MainWindow window1 = new MainWindow();
			window1.Show();
			Close();
		}
	}
}