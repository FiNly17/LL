using System.Linq;

using LL.Models;
using LL.Services;

namespace LL.ViewModels
{
	public class ProductInfoViewModel : ViewModel
	{
		public static Product InitialProduct { get; set; }

		public Product Product { get; }

		public bool IsClothing => Product.Type == ProductTypes.Clothing;

		public ClothingSizes ClothingSize => (Product as Clothing).Size;

		public double ShoesSize => (Product as Shoes).Size;

		public bool IsReviewed => DataContext.GetInstance().Reviews.ToList().Any(review => review.User == UserManager.CurrentUser);

		public ProductInfoViewModel()
		{
			Product = InitialProduct;
			InitialProduct = null;
		}
	}
}