using System.ComponentModel.DataAnnotations;

namespace LL.Models
{
	public class Admin : Account
	{
		[Required]
		public AdminType Type { get; set; }

		public Admin() : base(AccountType.Admin)
		{
		}

		public Admin(string login, string password, string eMail, string phone, string surname, string name, string middleName)
			: base(login, password, eMail, phone, surname, name, middleName, AccountType.Admin) { }
	}

	public enum AdminType
	{
		Major,
		Minor
	}
}