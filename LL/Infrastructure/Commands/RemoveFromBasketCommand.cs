using System;

using LL.Models;
using LL.Services;
using LL.ViewModels;
using LL.Views;

namespace LL.Infrastructure.Commands
{
	internal class RemoveFromBasketCommand : Command
	{
		public override bool CanExecute(object parameter) => true;

		public override void Execute(object parameter)
		{
			if (parameter is Product product && BasketManager.Products.Contains(product))
			{
				BasketManager.Remove(product);
				var window = BasketWindow.Instance;
				if (window != null)
					(window.DataContext as BasketViewModel).Refresh();
			}
			else
				throw new InvalidOperationException();
		}
	}
}