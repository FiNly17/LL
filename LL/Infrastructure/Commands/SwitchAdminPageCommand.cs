using System;

using LL.Models;
using LL.Services;
using LL.Views;

namespace LL.Infrastructure.Commands
{
	public class SwitchAdminPageCommand : Command
	{
		public override bool CanExecute(object parameter) => UserManager.AccountType == AccountType.Admin;

		public override void Execute(object parameter)
		{
			if (parameter is AdminPages page)
				AdminWindow.Instance.SwitchPage(page);
			else
				throw new InvalidOperationException();
		}
	}
}