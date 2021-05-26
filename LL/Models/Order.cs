using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using LL.Infrastructure;

namespace LL.Models
{
	public class Order
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public User User { get; set; }

		[Required]
		public virtual List<Product> Products { get; set; } = new List<Product>();

		public DateTime Date { get; set; }

		public OrderStatuses Status { get; set; }

		[NotMapped]
		public double Price => Products.Sum(item => item.Price);

		public Order() => Id = -1;

		public Order(User user, List<Product> products, DateTime date)
		{
			Id = -1;

			User = user;
			Products = products;
			Date = date;
		}

		public string ForSearch() => $"{Id} {User.FullName} {ProductsStr} {Date:G} {Status.Rus()} {Price}".ToLower();

		public string ProductsStr => string.Join(" ", Products.Select(product => product.FullName)).Trim();
	}

	public enum OrderStatuses
	{
		AwaitingConfirmation,
		Declined,
		DeliveryInProgress,
		Delivered
	}
}