using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
				DataContext.GetInstance().Orders.Find(order.Id).Status = OrderStatuses.DeliveryInProgress;
				DataContext.GetInstance().SaveChanges();
				SMTPClient.SendMail(UserManager.CurrentUser.FullName, order.User.EMail, order.User.FullName, "Изменение статуса заказа",
					$"Ваш заказ {order.Id} доставлен");
			}
			else
				throw new InvalidOperationException();
		}
	}
}