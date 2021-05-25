using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LL.Models;
using LL.Services;

namespace LL.ViewModels
{
	internal class CatalogViewModel : ViewModel
	{
		public List<Product> Products { get; }

		public CatalogViewModel()
		{
			Products = DataContext.GetInstance().Products.ToList();
		}
	}
}