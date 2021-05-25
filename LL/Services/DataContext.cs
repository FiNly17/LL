using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;

using LL.Models;

namespace LL.Services
{
	public class DataContext : DbContext
	{
		#region Connection

		private static readonly string connectionString;

		static DataContext()
		{
			connectionString = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;

			Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataContext>());
		}

		#endregion Connection

		#region Singleton

		private static DataContext _instance;

		public static DataContext GetInstance()
		{
			if (_instance == null)
			{
				_instance = new DataContext();
				if (_instance.Accounts.Count() == 0)
				{
					_instance.Accounts.Add(new Admin("Kirill", UserManager.HashPassword("123"), "kirill@gmail.com", "+375291112233", "Олешкевич", "Кирилл", "Вадимович"));
					_instance.SaveChanges();
				}
			}
			return _instance;
		}

		public static DataContext GetInstance(string connectionString)
		{
			if (_instance == null)
				_instance = new DataContext(connectionString);
			return _instance;
		}

		private DataContext() : base(connectionString)
		{
		}

		private DataContext(string connectionString) : base(connectionString)
		{
		}

		#endregion Singleton

		#region Tables

		public DbSet<Account> Accounts { get; set; }

		public DbSet<Product> Products { get; set; }

		public DbSet<Order> Orders { get; set; }

		#endregion Tables

		#region Methods

		public static List<User> GetUsers() => GetInstance().Accounts
			.Where(account => account.AccountType == AccountType.User)
			.Select(account => account as User).ToList();

		public static List<User> SearchUsers(string query)
		{
			query = query?.ToLower();

			if (!string.IsNullOrEmpty(query))
			{
				var tags = query.Split(' ');

				return GetUsers().Where(user =>
						tags.All(tag => user.ForSearch().ToLower().Contains(tag))).ToList();
			}
			else
				return GetUsers();
		}

		public static List<Admin> SearchAdmins(string query)
		{
			query = query?.ToLower();

			if (!string.IsNullOrEmpty(query))
			{
				var tags = query.Split(' ');

				return GetInstance().Accounts.Where(account => account.AccountType == AccountType.Admin &&
						tags.All(tag => account.ForSearch().ToLower().Contains(tag))).Cast<Admin>().ToList();
			}
			else
				return GetInstance().Accounts.ToList().Where(account => account.AccountType == AccountType.Admin).Cast<Admin>().ToList();
		}

		public static List<Product> SearchProducts(string query, ProductTypes type = ProductTypes.None)
		{
			query = query?.ToLower();

			if (!string.IsNullOrEmpty(query))
			{
				var tags = query.Split(' ');

				switch (type)
				{
					case ProductTypes.Clothing:
						return GetInstance().Products.Where(product => product.Type == ProductTypes.Clothing &&
					tags.All(tag => product.ForSearch().ToLower().Contains(tag))).ToList();

					case ProductTypes.Shoes:
						return GetInstance().Products.Where(product => product.Type == ProductTypes.Shoes &&
					tags.All(tag => product.ForSearch().ToLower().Contains(tag))).ToList();

					default:
						return GetInstance().Products.Where(product =>
						   tags.All(tag => product.ForSearch().ToLower().Contains(tag))).ToList();
				}
			}
			else
				return GetInstance().Products.ToList();
		}

		#endregion Methods
	}
}