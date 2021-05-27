using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using LL.Models;

namespace LL.Services
{
	public static class BasketManager
	{
		public static ObservableCollection<Product> Products { get; private set; }

		static BasketManager()
		{
			Products = new ObservableCollection<Product>();
		}

		public static void Add(Product product) => Products.Add(product);

		public static void Remove(Product product) => Products.Remove(product);

		public static void Clear() => Products.Clear();

		public static void Buy()
		{
			if (Products.Count == 0)
				return;

			DataContext.GetInstance().Orders.Add(new Order(UserManager.CurrentUser as User, new List<Product>(Products), DateTime.Now));
			DataContext.GetInstance().SaveChanges();
			Clear();
		}
	}
}