using System;
using System.Collections.Generic;
using System.Windows.Input;

using LL.Infrastructure.Commands;

using LL.Models;

using LL.Services;

namespace LL.ViewModels
{
	internal class OrdersTableViewModel : ViewModel
	{
		private string _query = string.Empty;

		public string Query
		{
			get { return _query; }
			set { SetProperty(ref _query, value); }
		}

		private List<Order> _searchResult;

		public List<Order> SearchResult
		{
			get => _searchResult;
			set => SetProperty(ref _searchResult, value);
		}

		#region Commands

		public ICommand SearchCommand { get; set; }

		private void OnSearchCommandExecuted(object p) => Search(p);

		private static bool CanSearchCommandExecute(object p) => true;

		public ICommand DeliveryStartedCommand { get; set; }

		private void OnDeliveryStartedCommandExecuted(object p) => DeliveryStarted(p);

		private static bool CanDeliveryStartedCommandExecute(object p) => true;

		public ICommand DeliveredCommand { get; set; }

		private void OnDeliveredCommandExecuted(object p) => Delivered(p);

		private static bool CanDeliveredCommandExecute(object p) => true;

		public ICommand DeclineCommand { get; set; }

		private void OnDeclineCommandExecuted(object p) => Decline(p);

		private static bool CanDeclineCommandExecute(object p) => true;

		#endregion Commands

		public OrdersTableViewModel()
		{
			SearchCommand = new RelayCommand(OnSearchCommandExecuted, CanSearchCommandExecute);
			DeliveryStartedCommand = new RelayCommand(OnDeliveryStartedCommandExecuted, CanDeliveryStartedCommandExecute);
			DeliveredCommand = new RelayCommand(OnDeliveredCommandExecuted, CanDeliveredCommandExecute);
			DeclineCommand = new RelayCommand(OnDeclineCommandExecuted, CanDeclineCommandExecute);
		}

		private void Search(object p)
		{
			if (p is bool closed)
				SearchResult = DataContext.SearchOrders(Query, closed);
			else
				throw new InvalidOperationException();
		}

		private void DeliveryStarted(object p)
		{
			if (p is Order order)
				DataContext.ChangeOrderStatus(order, OrderStatuses.DeliveryInProgress);
			else
				throw new InvalidOperationException();
		}

		private void Delivered(object p)
		{
			if (p is Order order)
			{
				DataContext.ChangeOrderStatus(order, OrderStatuses.Delivered);
				SMTPClient.SendMail(UserManager.CurrentUser.FullName, order.User.EMail, order.User.FullName,
					"Оповещение", "Ваш заказ был доставлен");
			}
			else
				throw new InvalidOperationException();
		}

		private void Decline(object p)
		{
			if (p is Order order)
				DataContext.ChangeOrderStatus(order, OrderStatuses.Declined);
			else
				throw new InvalidOperationException();
		}
	}
}