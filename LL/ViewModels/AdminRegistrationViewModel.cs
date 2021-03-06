using System;
using System.Windows.Input;
using System.Windows;

using LL.Infrastructure.Commands;

using LL.Services;
using System.ComponentModel;
using LL.Models;

namespace LL.ViewModels
{
	internal class AdminRegistrationViewModel : ViewModel, IDataErrorInfo
	{
		private string _login;

		public string Login
		{
			get { return _login; }
			set { SetProperty(ref _login, value); }
		}

		private string _password;

		public string Password
		{
			get { return _password; }
			set { SetProperty(ref _password, value); }
		}

		private string _eMail;

		public string EMail
		{
			get { return _eMail; }
			set { SetProperty(ref _eMail, value); }
		}

		private string _phone;

		public string Phone
		{
			get { return _phone; }
			set { SetProperty(ref _phone, value); }
		}

		private string _surname;

		public string Surname
		{
			get { return _surname; }
			set { SetProperty(ref _surname, value); }
		}

		private string _name;

		public string Name
		{
			get { return _name; }
			set { SetProperty(ref _name, value); }
		}

		private string _middleName;

		public string MiddleName
		{
			get { return _middleName; }
			set { SetProperty(ref _middleName, value); }
		}

		public string Error => throw new NotImplementedException();

		public string this[string columnName] => Validate(columnName);

		public ICommand RegistrationCommand { get; set; }

		private static bool CanRegistrationCommandExecute(object p) => (UserManager.CurrentUser as Admin).Type == AdminType.Major;

		private void OnRegistrationCommandExecuted(object p) => ProcessRegistration();

		public AdminRegistrationViewModel()
		{
			RegistrationCommand = new RelayCommand(OnRegistrationCommandExecuted, CanRegistrationCommandExecute);
		}

		private void ProcessRegistration()
		{
			var check = CheckFields();
			if (!string.IsNullOrEmpty(check))
			{
				MessageBox.Show(check);
				return;
			}

			var (result, error) = UserManager.RegisterAdmin(Login, Password, EMail, Phone, Surname, Name, MiddleName);
			if (result)
			{
				MessageBox.Show("Админ успешно зарегистрирован");
			}
			else
			{
				MessageBox.Show(error, "Не удалось зарегистрировать аккаунт администратора");
			}
		}

		private string CheckFields()
		{
			string errors = string.Empty;

			errors += Validate("Login") + "\n";
			errors += Validate("Password") + "\n";
			errors += Validate("EMail") + "\n";
			errors += Validate("Phone") + "\n";
			errors += Validate("Surname") + "\n";
			errors += Validate("Name") + "\n";
			errors += Validate("MiddleName") + "\n";

			return errors.Trim();
		}

		private string Validate(string columnName)
		{
			if (columnName == null)
				return string.Empty;

			string error = string.Empty;

			switch (columnName)
			{
				case "Login":
					{
						if (string.IsNullOrEmpty(Login))
							return "Введите логин";

						var (isValid, forbiddenSymbols) = Validator.Validate(Login, Validator.loginRegex);

						if (!isValid)
							return $"В логине присутсвуют недопустимые символы: {Validator.JoinSymbols(forbiddenSymbols)}";
					}
					break;

				case "Password":
					{
						if (string.IsNullOrEmpty(Password))
							return "Введите пароль";

						if (Password.Length < 3)
							return "Пароль слишком короткий";
					}
					break;

				case "EMail":
					{
						if (string.IsNullOrEmpty(EMail))
							return "Введите почту";

						var (isValid, _) = Validator.Validate(EMail, Validator.eMailRegex);
						if (!isValid)
							return "Введённая строка не является электронной почтой";
					}
					break;

				case "Phone":
					{
						if (string.IsNullOrEmpty(Phone))
							return "Введите телефон";

						var (isValid, _) = Validator.Validate(Phone, Validator.phoneRegex);

						if (!isValid)
							return "Введённая строка не является телефоном";
					}
					break;

				case "Surname":
					{
						if (string.IsNullOrEmpty(Surname))
							return "Введите фамилию";

						var (isValid, forbiddenSymbols) = Validator.Validate(Surname, Validator.nameRegex);

						if (!isValid)
							return $"В фамилии присутсвуют недопустимые символы: {Validator.JoinSymbols(forbiddenSymbols)}";
					}
					break;

				case "Name":
					{
						if (string.IsNullOrEmpty(Name))
							return "Введите имя";

						var (isValid, forbiddenSymbols) = Validator.Validate(Name, Validator.nameRegex);

						if (!isValid)
							return $"В имени присутсвуют недопустимые символы: {Validator.JoinSymbols(forbiddenSymbols)}";
					}
					break;

				case "MiddleName":
					{
						if (string.IsNullOrEmpty(MiddleName))
							return "Введите отчество";

						var (isValid, forbiddenSymbols) = Validator.Validate(MiddleName, Validator.nameRegex);

						if (!isValid)
							return $"В отчестве присутсвуют недопустимые символы: {Validator.JoinSymbols(forbiddenSymbols)}";
					}
					break;
			}

			return error;
		}
	}
}