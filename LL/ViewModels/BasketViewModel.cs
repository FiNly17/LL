using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;

using LL.Infrastructure.Commands;
using LL.Models;
using LL.Services;
using LL.Views;

namespace LL.ViewModels
{
	public class BasketViewModel : ViewModel, ICloseable
	{
		public event EventHandler CloseRequest;

		private List<Product> _products;

		public List<Product> Products
		{
			get { return _products; }
			set { SetProperty(ref _products, value); }
		}

		public double Sum => Products.Sum(item => item.Price);

		public ICommand BuyCommand { get; set; }

		public void OnBuyCommandExecuted(object p) => Buy();

		public bool CanBuyCommnadExecuted(object p) => Products.Count() != 0;

		public BasketViewModel()
		{
			BuyCommand = new RelayCommand(OnBuyCommandExecuted, CanBuyCommnadExecuted);
			Refresh();
			BasketManager.Products.CollectionChanged += (sender, e) => Refresh();
		}

		public void Refresh() => Products = BasketManager.Products.ToList();

		private void Buy()
		{
			BasketManager.Buy();
			MessageBox.Show("Заказ успешно оформлен");
			CloseRequest?.Invoke(this, EventArgs.Empty);
		}
	}
}