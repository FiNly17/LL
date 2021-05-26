using System;
using System.Windows;

using LL.Models;
using LL.Services;
using LL.Views;

namespace LL.Infrastructure.Commands
{
	internal class DeleteProductCommand : Command
	{
		public override bool CanExecute(object parameter) => UserManager.AccountType == AccountType.Admin;

		public override void Execute(object parameter)
		{
			if (parameter is Product product)
			{
				if (MessageBox.Show("Вы действительно хотите удалить товар?", "Подтверждение действия", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
				{
					DataContext.GetInstance().Products.Remove(product);
					DataContext.GetInstance().SaveChanges();
					AdminWindow.Instance.Refresh();
				}
			}
			else
				throw new InvalidOperationException();
		}
	}
}