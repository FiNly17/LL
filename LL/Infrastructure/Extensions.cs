using System;

using LL.Models;

namespace LL.Infrastructure
{
	public static class Extensions
	{
		public static string Rus(this ProductType type)
		{
			switch (type)
			{
				case ProductType.Clothing:
					return "одежда";

				case ProductType.Shoes:
					return "обувь";

				default:
					throw new InvalidOperationException();
			}
		}
	}
}