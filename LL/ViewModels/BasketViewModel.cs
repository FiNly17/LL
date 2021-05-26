using System.Collections.Generic;

using LL.Models;
using LL.Services;

namespace LL.ViewModels
{
	public class BasketViewModel : ViewModel
	{
		private List<Product> _products;

		public List<Product> Products
		{
			get { return _products; }
			set { SetProperty(ref _products, value); }
		}

		public BasketViewModel()
		{
			Refresh();
		}

		private void Refresh() => Products = Basket.Products;
	}
}