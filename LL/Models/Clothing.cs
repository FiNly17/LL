using System;
using System.Collections.Generic;

namespace LL.Models
{
	public class Clothing : Product
	{
		public ClothingSizes Size { get; set; }

		public Clothing()
		{
		}

		public Clothing(ClothingSizes size, string model, string brand, double price, byte[] image)
			: base(model, brand, price, image, ProductTypes.Clothing)
		{
			Size = size;
		}

		public override string ForSearch() => $"{base.ForSearch()} {Size}";

		public static List<Clothing> Sort(List<Clothing> list)
		{
			var values = Enum.GetValues(typeof(ClothingSizes));
			List<Clothing> result = new List<Clothing>();

			for (int i = 0; i < values.Length - 1; i++)
			{
				var pop = list.FindAll(item => ((int)item.Size) == i);
				result.AddRange(pop);
			}

			return result;
		}
	}

	public enum ClothingSizes
	{
		XS, S, M, L, XL, XXL,
		None
	}
}