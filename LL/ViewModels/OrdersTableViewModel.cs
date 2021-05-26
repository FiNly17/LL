using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using LL.Infrastructure.Commands;

using LL.Models;

using LL.Services;

namespace LL.ViewModels
{
	internal class OrdersTableViewModel : ViewModel
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

		public OrdersTableViewModel()
		{
			SearchCommand = new RelayCommand(OnSearchCommandExecuted, CanSearchCommandExecute);
			Search();
		}

		private void Search() => SearchResult = DataContext.SearchAdmins(Query);
	}
}