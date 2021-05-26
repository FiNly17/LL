using System.Collections.Generic;
using System.Windows.Input;

using LL.Infrastructure.Commands;

using LL.Models;

using LL.Services;

namespace LL.ViewModels
{
	public class UsersTableViewModel : ViewModel
	{
		private string _query = string.Empty;

		public string Query
		{
			get { return _query; }
			set { SetProperty(ref _query, value); }
		}

		private List<User> _searchResult;

		public List<User> SearchResult
		{
			get => _searchResult;
			set => SetProperty(ref _searchResult, value);
		}

		public ICommand SearchCommand { get; set; }

		private void OnSearchCommandExecuted(object p) => Search();

		private static bool CanSearchCommandExecute(object p) => true;

		public UsersTableViewModel()
		{
			SearchCommand = new RelayCommand(OnSearchCommandExecuted, CanSearchCommandExecute);
			Search();
		}

		private void Search() => SearchResult = DataContext.SearchUsers(Query);
	}
}