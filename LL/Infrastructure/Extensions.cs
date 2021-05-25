using System;

using LL.Models;

namespace LL.Infrastructure
{
	public static class Extensions
	{
		public static string Rus(this ProductTypes type)
		{
			switch (type)
			{
				case ProductTypes.Clothing:
					return "одежда";

				case ProductTypes.Shoes:
					return "обувь";

				default:
					throw new InvalidOperationException();
			}
		}
	}
}