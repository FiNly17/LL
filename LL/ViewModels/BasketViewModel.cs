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

		public List<Product> Products => BasketManager.Products;

		public double Sum => Products.Sum(item => item.Price);

		public ICommand BuyCommand { get; set; }

		public void OnBuyCommandExecuted(object p) => Buy();

		public bool CanBuyCommnadExecuted(object p) => Products.Count() != 0;

		public BasketViewModel()
		{
			BuyCommand = new RelayCommand(OnBuyCommandExecuted, CanBuyCommnadExecuted);
		}

		private void Buy()
		{
			BasketManager.Buy();
			MessageBox.Show("Заказ успешно оформлен");
			CloseRequest?.Invoke(this, EventArgs.Empty);
		}
	}
}