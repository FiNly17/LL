using System;
using System.Windows;

using LL.Models;
using LL.Services;
using LL.Views;

namespace LL.Infrastructure.Commands
{
	internal class DeleteAdminCommand : Command
	{
		public override bool CanExecute(object parameter) => (UserManager.CurrentUser as Admin).Type == AdminType.Major;

		public override void Execute(object parameter)
		{
			if (parameter is Admin admin)
			{
				if (MessageBox.Show("Вы действительно хотите удалить администратора?", "Подтверждение действия", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
				{
					DataContext.GetInstance().Accounts.Remove(admin);
					DataContext.GetInstance().SaveChanges();
					AdminWindow.Instance.Refresh();
				}
			}
			else
				throw new InvalidOperationException();
		}
	}
}