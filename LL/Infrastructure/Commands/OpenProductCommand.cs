using System;

using LL.Models;
using LL.ViewModels;
using LL.Views;

namespace LL.Infrastructure.Commands
{
	public class OpenProductCommand : Command
	{
		public override bool CanExecute(object parameter) => true;

		public override void Execute(object parameter)
		{
			if (parameter is Product product)
			{
				ProductInfoViewModel.InitialProduct = product;
				var window = new ProductInfoWindow();
				window.ShowDialog();
			}
			else
				throw new InvalidOperationException();
		}
	}
}