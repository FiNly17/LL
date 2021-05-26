using System;

using LL.Models;
using LL.Services;
using LL.ViewModels;
using LL.Views;

namespace LL.Infrastructure.Commands
{
	internal class EditProductCommand : Command
	{
		public override bool CanExecute(object parameter) => UserManager.AccountType == AccountType.Admin;

		public override void Execute(object parameter)
		{
			if (parameter is Product product)
			{
				ProductEditorViewModel.InitialProduct = product;
				AdminWindow.Instance.SwitchPage(AdminPages.Editor);
			}
			else
				throw new InvalidOperationException();
		}
	}
}