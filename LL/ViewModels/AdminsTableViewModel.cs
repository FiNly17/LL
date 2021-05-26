using System.Collections.Generic;
using System.Windows.Input;

using LL.Infrastructure.Commands;

using LL.Models;

using LL.Services;
using LL.Views;

namespace LL.ViewModels
{
	public class AdminsTableViewModel : ViewModel
	{
		private string _query = string.Empty;

		public string Query
		{
			get { return _query; }
			set { SetProperty(ref _query, value); }
		}

		private List<Admin> _searchResult;

		public List<Admin> SearchResult
		{
			get => _searchResult;
			set => SetProperty(ref _searchResult, value);
		}

		public ICommand SearchCommand { get; set; }

		private void OnSearchCommandExecuted(object p) => Search();

		private static bool CanSearchCommandExecute(object p) => true;

		public ICommand NewAdminCommand { get; set; }

		private void OnNewAdminCommandExecuted(object p) => NewAdmin();

		private static bool CanNewAdminCommandExecute(object p) => (UserManager.CurrentUser as Admin).Type == AdminType.Major;

		public AdminsTableViewModel()
		{
			SearchCommand = new RelayCommand(OnSearchCommandExecuted, CanSearchCommandExecute);
			NewAdminCommand = new RelayCommand(OnNewAdminCommandExecuted, CanNewAdminCommandExecute);
			Search();
		}

		private void Search() => SearchResult = DataContext.SearchAdmins(Query);

		private void NewAdmin()
		{
			var window = new AdminRegistrationWindow();
			window.ShowDialog();
			Search();
		}
	}
}