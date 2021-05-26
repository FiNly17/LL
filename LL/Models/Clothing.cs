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
	}

	public enum ClothingSizes
	{
		XS, S, M, L, XL, XXL,
		None
	}
}