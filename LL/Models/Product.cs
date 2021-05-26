using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

using LL.Infrastructure;
using LL.Services;

namespace LL.Models
{
	public abstract class Product
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public string Model { get; set; }

		[Required]
		public string Brand { get; set; }

		[Required]
		public ProductTypes Type { get; set; }

		public double Price { get; set; }

		public byte[] Image { get; set; }

		public virtual List<Order> Orders { get; set; } = new List<Order>();

		[NotMapped]
		public string FullName => $"{Brand} {Model}";

		[NotMapped]
		public bool IsFavorite => (UserManager.CurrentUser as User).Bookmarks.Any(item => item ==this);

		public Product()
		{
			Id = -1;
		}

		protected Product(string model, string brand, double price, byte[] image, ProductTypes type)
		{
			Id = -1;

			Model = model;
			Brand = brand;
			Type = type;
			Price = price;
			Image = image;
		}

		public string ForSearch() => $"{Id} {Model} {Brand} {Type.Rus()} {Price}";
	}

	public enum ProductTypes
	{
		Clothing,
		Shoes,
		None
	}
}