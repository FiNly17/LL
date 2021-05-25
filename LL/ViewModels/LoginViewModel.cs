using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

using LL.Infrastructure.Commands;
using LL.Services;
using LL.Views;

namespace LL.ViewModels
{
	public class LoginViewModel : ViewModel, ICloseable
	{
		public event EventHandler CloseRequest;

		private string _login = string.Empty;

		public string Login
		{
			get { return _login; }
			set { SetProperty(ref _login, value); }
		}

		private string _password = string.Empty;

		public string Password
		{
			get { return _password; }
			set { SetProperty(ref _password, value); }
		}

		public ICommand LoginCommand { get; set; }

		private static bool CanLoginCommandExecute(object p) => UserManager.CurrentUser == null;

		private void OnLoginCommandExecuted(object p) => ProcessLogin();

		public LoginViewModel()
		{
			LoginCommand = new RelayCommand(OnLoginCommandExecuted, CanLoginCommandExecute);
		}

		private void ProcessLogin()
		{
			if (UserManager.Login(Login, Password))
			{
				var window = new MainWindow();
				Application.Current.MainWindow = window;
				CloseRequest.Invoke(this, EventArgs.Empty);
				window.Show();
			}
			else
			{
				MessageBox.Show("Неверный логин или пароль", "Ошибка авторизации");
			}
		}
	}
}