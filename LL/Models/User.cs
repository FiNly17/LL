using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LL.Models
{
	public class User : Account
	{
		[Required]
		public string Address { get; set; }

		public virtual List<Order> Orders { get; set; } = new List<Order>();

		public virtual List<Product> Bookmarks { get; set; } = new List<Product>();

		[NotMapped]
		public List<Product> Basket { get; set; } = new List<Product>();

		public User() : base(AccountType.User)
		{
		}

		public User(string login, string password, string eMail, string phone, string surname, string name, string middleName, string address)
			: base(login, password, eMail, phone, surname, name, middleName, AccountType.User)
		{
			Address = address;
		}

		public override string ForSearch() => $"{base.ForSearch()} {Address}".ToLower();
	}
}