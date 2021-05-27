using System;

using LL.Models;
using LL.Services;
using LL.Views;

namespace LL.Infrastructure.Commands
{
	public class FavoriteCommand : Command
	{
		public override bool CanExecute(object parameter) => UserManager.AccountType == AccountType.User;

		public override void Execute(object parameter)
		{
			if (parameter is Product product)
			{
				if ((UserManager.CurrentUser as User).Bookmarks.Contains(product))
				{
					var userctx = DataContext.GetInstance().Accounts.Find(UserManager.CurrentUser.Id) as User;
					userctx.Bookmarks.Remove(product);
					DataContext.GetInstance().SaveChanges();

				}
				else
				{
					(DataContext.GetInstance().Accounts.Find(UserManager.CurrentUser.Id) as User).Bookmarks.Add(product);
					DataContext.GetInstance().SaveChanges();
					
				}
				MainWindow.Instance.Refresh();
			}
			else
				throw new NotImplementedException();
		}
	}
}