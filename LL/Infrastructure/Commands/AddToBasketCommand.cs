using System;
using System.Windows;

using LL.Models;
using LL.Services;

namespace LL.Infrastructure.Commands
{
	public class AddToBasketCommand : Command
	{
		public override bool CanExecute(object parameter) => true;

		public override void Execute(object parameter)
		{
			if (parameter is Product product)
			{
				BasketManager.Add(product);
				MessageBox.Show("Товар добавлен в корзину");
			}
			else
				throw new InvalidOperationException();
		}
	}
}