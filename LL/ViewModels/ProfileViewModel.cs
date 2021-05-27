using System.Collections.Generic;

using LL.Models;
using LL.Services;

namespace LL.ViewModels
{
	internal class ProfileViewModel : ViewModel
	{
		public User User => UserManager.CurrentUser as User;

		public ProfileViewModel()
		{
		}
	}
}