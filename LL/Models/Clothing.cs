namespace LL.Models
{
	public class Clothing : Product
	{
		public ClothingSize Size { get; set; }

		public Clothing(ClothingSize size, string model, string brand, double price, byte[] image)
			: base(model, brand, price, image, ProductType.Clothing)
		{
			Size = size;
		}
	}

	public enum ClothingSize
	{
		XS, S, M, L, XL, XXL
	}
}