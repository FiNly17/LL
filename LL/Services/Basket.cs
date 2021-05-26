using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LL.Models;

namespace LL.Services
{
	public static class Basket
	{
		public static List<Product> Products { get; private set; }

		static Basket()
		{
			Products = new List<Product>();
		}

		public static void Add(Product product) => Products.Add(product);

		public static void Remove(Product product) => Products.Remove(product);

		public static void Clear() => Products.Clear();

		public static void Buy()
		{
			if (Products.Count == 0)
				return;

			DataContext.GetInstance().Orders.Add(new Order(UserManager.CurrentUser as User, Products, DateTime.Now));
			DataContext.GetInstance().SaveChanges();
			Clear();
		}
	}
}