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

		public static string Rus(this OrderStatuses status)
		{
			switch (status)
			{
				case OrderStatuses.AwaitingConfirmation:
					return "ожидает подтверждения";

				case OrderStatuses.DeliveryInProgress:
					return "доставляется";

				case OrderStatuses.Delivered:
					return "доставлен";

				case OrderStatuses.Declined:
					return "отклонён";

				default:
					throw new InvalidOperationException();
			}
		}
	}
}