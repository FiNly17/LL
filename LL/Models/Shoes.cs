namespace LL.Models
{
	public class Shoes : Product
	{
		public double Size { get; set; }

		public Shoes(double size, string model, string brand, double price, byte[] image)
			: base(model, brand, price, image, ProductType.Shoes)
		{
			Size = size;
		}
	}
}