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
				var user = UserManager.CurrentUser as User;
				if (user.Bookmarks.Contains(product))
				{
					user.Bookmarks.Remove(product);
					if (MainWindow.Instance.CurrentPage == Pages.BookmarkPage)
						MainWindow.Instance.Refresh();
				}
				else
					user.Bookmarks.Add(product);
			}
			else
				throw new NotImplementedException();
		}
	}
}