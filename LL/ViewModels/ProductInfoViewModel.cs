using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

using LL.Infrastructure.Commands;
using LL.Models;
using LL.Services;

namespace LL.ViewModels
{
	public class ProductInfoViewModel : ViewModel
	{
		public event EventHandler Reviewed;

		public static Product InitialProduct { get; set; }

		public Product Product { get; }

		private int _userRating = 5;

		public int UserRating
		{
			get { return _userRating; }
			set { SetProperty(ref _userRating, value); }
		}

		private string _userComment = string.Empty;

		public string UserComment
		{
			get { return _userComment; }
			set { SetProperty(ref _userComment, value); }
		}

		public string UserName => UserManager.CurrentUser.FullName;

		public bool IsClothing => Product.Type == ProductTypes.Clothing;

		public ClothingSizes ClothingSize => (Product as Clothing).Size;

		private List<Review> _reviews;

		public List<Review> Reviews
		{
			get { return _reviews; }
			set { SetProperty(ref _reviews, value); }
		}

		public double ShoesSize => (Product as Shoes).Size;

		public bool IsReviewed => DataContext.GetInstance().Reviews.ToList()
			.Any(review => review.Product == Product && review.User == UserManager.CurrentUser);

		public ICommand ReviewCommand { get; set; }

		private void OnReviewCommandExecuted(object p) => Review();

		private static bool CanReviewCommandExecute(object p) => true;

		public ProductInfoViewModel()
		{
			ReviewCommand = new RelayCommand(OnReviewCommandExecuted, CanReviewCommandExecute);

			Product = InitialProduct;
			InitialProduct = null;
			Reviews = DataContext.GetInstance().Reviews.ToList().Where(item => item.Product == Product).ToList();
		}

		private void Review()
		{
			DataContext.GetInstance().Products.Find(Product.Id).Reviews.Add(
				new Review(UserManager.CurrentUser as User, Product, UserRating, UserComment));
			DataContext.GetInstance().SaveChanges();
			Reviewed?.Invoke(this, EventArgs.Empty);
			Reviews = DataContext.GetInstance().Reviews.ToList().Where(item => item.Product == Product).ToList();
		}
	}
}