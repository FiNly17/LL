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

		public virtual List<Review> Reviews { get; set; } = new List<Review>();

		[NotMapped]
		public string FullName => $"{Brand} {Model}";

		[NotMapped]
		public string TypeStr => Type.Rus();

		[NotMapped]
		public string SizeStr => Type == ProductTypes.Clothing ? (this as Clothing).Size.ToString() : (this as Shoes).Size.ToString();

		[NotMapped]
		public bool IsFavorite => (UserManager.CurrentUser as User).Bookmarks.Any(item => item == this);

		public Product() => Id = -1;

		protected Product(string model, string brand, double price, byte[] image, ProductTypes type)
		{
			Id = -1;

			Model = model;
			Brand = brand;
			Type = type;
			Price = price;
			Image = image;
		}

		public virtual string ForSearch() => $"{Id} {Model} {Brand} {Type.Rus()} {Price} {SizeStr}".ToLower();
	}

	public enum ProductTypes
	{
		Clothing,
		Shoes,
		None
	}
}