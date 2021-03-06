using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

using LL.Infrastructure.Commands;
using LL.Models;
using LL.Services;

namespace LL.ViewModels
{
	public class CatalogViewModel : ViewModel
	{
		public static CatalogViewModel Instance { get; private set; }

		public static string InitialQuery { get; set; }

		private string _query = string.Empty;

		public string Query
		{
			get { return _query; }
			set { SetProperty(ref _query, value); }
		}

		private List<Product> _bookmarks;

		public List<Product> Bookmarks
		{
			get { return _bookmarks; }
			set { SetProperty(ref _bookmarks, value); }
		}

		private List<Product> _searchResult;

		public List<Product> SearchResult
		{
			get => _searchResult;
			set => SetProperty(ref _searchResult, value);
		}

		private bool _isShoes = true;

		public bool IsShoes
		{
			get { return _isShoes; }
			set
			{
				SetProperty(ref _isShoes, value);
				Search();
			}
		}

		private int _sortIndex = 2;

		public int SortIndex
		{
			get { return _sortIndex; }
			set { SetProperty(ref _sortIndex, value); }
		}

		public ICommand SearchCommand { get; set; }

		private void OnSearchCommandExecuted(object p) => Search();

		private static bool CanSearchCommandExecute(object p) => true;

		public CatalogViewModel()
		{
			Instance = this;
			Bookmarks = (UserManager.CurrentUser as User).Bookmarks;

			SearchCommand = new RelayCommand(OnSearchCommandExecuted, CanSearchCommandExecute);
			Query = InitialQuery;
			Search();
		}

		public void Refresh()
		{
			Bookmarks = (UserManager.CurrentUser as User).Bookmarks;
			SearchResult = DataContext.GetInstance().Products.ToList().Where(item => SearchResult.Contains(item)).ToList();
		}

		public void Search()
		{
			var temp = DataContext.SearchProducts(Query, IsShoes ? ProductTypes.Shoes : ProductTypes.Clothing)
				.Where(item => item.Type == (IsShoes ? ProductTypes.Shoes : ProductTypes.Clothing));

			switch (SortIndex)
			{
				case 0:
					SearchResult = IsShoes
						? temp.OrderBy(item => (item as Shoes).Size).ToList()
						: Clothing.Sort(temp.Cast<Clothing>().ToList()).Cast<Product>().ToList();
					break;

				case 1:
					SearchResult = temp.OrderBy(item => item.Brand).ToList();
					break;

				case 2:
					SearchResult = temp.OrderBy(item => item.Price).ToList();
					break;

				default:
					SearchResult = temp.ToList();
					break;
			}
		}
	}
}