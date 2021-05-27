using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				BasketManager.Add(product);
			else
				throw new InvalidOperationException();
		}
	}
}