using System;

using LL.Models;
using LL.Services;

namespace LL.Infrastructure.Commands
{
	internal class DeliveredStatusCommand : Command
	{
		public override bool CanExecute(object parameter) => parameter is Order order && order.Status == OrderStatuses.DeliveryInProgress;

		public override void Execute(object parameter)
		{
			if (parameter is Order order)
			{
				DataContext.GetInstance().Orders.Find(order.Id).Status = OrderStatuses.Delivered;
				DataContext.GetInstance().SaveChanges();
				SMTPClient.SendMail(UserManager.CurrentUser.FullName, order.User.EMail, order.User.FullName, "Изменение статуса заказа",
					$"Ваш заказ {order.ProductsStr} доставлен");
			}
			else
				throw new InvalidOperationException();
		}
	}
}