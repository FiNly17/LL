using System;
using System.Windows;
using System.Windows.Input;

using LL.Infrastructure.Commands;
using LL.Models;
using LL.Services;
using LL.Views;

namespace LL.ViewModels
{
	internal class MainViewModel : ViewModel, ICloseable
	{
		public event EventHandler CloseRequest;

		public User User => UserManager.CurrentUser as User;

		public ICommand LogoutCommand { get; set; }

		private static bool CanLogoutCommandExecute(object p) => UserManager.CurrentUser != null;

		private void OnLogoutCommandExecuted(object p) => Logout();

		public MainViewModel()
		{
			LogoutCommand = new RelayCommand(OnLogoutCommandExecuted, CanLogoutCommandExecute);
		}

		private void Logout()
		{
			UserManager.Logout();
			var window = new LoginWindow();
			Application.Current.MainWindow = window;
			CloseRequest?.Invoke(this, EventArgs.Empty);
			window.Show();
		}
	}
}