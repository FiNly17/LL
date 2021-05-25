using System.Collections.Generic;
using System.Windows.Input;

using LL.Infrastructure.Commands;
using LL.Models;
using LL.Services;

namespace LL.ViewModels
{
	public class ProductsTableViewModel : ViewModel
	{
		private string _query = string.Empty;

		public string Query
		{
			get { return _query; }
			set { SetProperty(ref _query, value); }
		}

		private ProductType _productType = ProductType.None;

		public ProductType ProductType
		{
			get { return _productType; }
			set { SetProperty(ref _productType, value); }
		}

		private List<Product> _searchResult;

		public List<Product> SearchResult
		{
			get => _searchResult;
			set => SetProperty(ref _searchResult, value);
		}

		public ICommand SearchCommand { get; set; }

		private void OnSearchCommandExecuted(object p) => Search();

		private static bool CanSearchCommandExecute(object p) => true;

		public ProductsTableViewModel()
		{
			SearchCommand = new RelayCommand(OnSearchCommandExecuted, CanSearchCommandExecute);
			Search();
		}

		private void Search() => SearchResult = DataContext.SearchProducts(Query, ProductType);
	}
}