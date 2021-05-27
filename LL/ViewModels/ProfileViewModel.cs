using System.Collections.Generic;

using LL.Models;
using LL.Services;

namespace LL.ViewModels
{
    class ProfileViewModel :ViewModel
    {

		private User user = (UserManager.CurrentUser as User);

		public User Users
		{
			get { return user; }
			set { SetProperty(ref user, value); }
		}

		public ProfileViewModel()
		{
			Refresh();
		}

		private void Refresh() => Users = (UserManager.CurrentUser as User);
	}
}
