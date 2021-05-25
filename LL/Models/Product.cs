using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using LL.Infrastructure;

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
		public ProductType Type { get; set; }

		public double Price { get; set; }

		public byte[] Image { get; set; }

		public virtual List<Order> Orders { get; set; } = new List<Order>();

		[NotMapped]
		public string FullName => $"{Brand} {Model}";

		public Product()
		{
			Id = -1;
		}

		protected Product(string model, string brand, double price, byte[] image, ProductType type)
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

	public enum ProductType
	{
		Clothing,
		Shoes,
		None
	}
}