using System.ComponentModel.DataAnnotations;

namespace LL.Models
{
	public class Review
	{
		[Key]
		public int Id { get; set; }

		[Required]
		public User User { get; set; }

		[Required]
		public Product Product { get; set; }

		[Required]
		public int Rating { get; set; }

		public string Comment { get; set; }

		public Review() => Id = -1;

		public Review(User user, Product product, int rating, string comment = null)
		{
			Id = -1;

			User = user;
			Product = product;
			Rating = rating;
			Comment = comment;
		}
	}
}