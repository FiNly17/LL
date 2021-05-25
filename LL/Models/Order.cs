using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LL.Models
{
	public class Order
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public User User { get; set; }

		[Required]
		public virtual List<Product> Things { get; set; } = new List<Product>();

		public DateTime Date { get; set; }

		public Order() => Id = -1;

		public Order(User user, List<Product> things, DateTime date)
		{
			Id = -1;

			User = user;
			Things = things;
			Date = date;
		}
	}
}