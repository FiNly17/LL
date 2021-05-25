using LL.Models;
using LL.Services;

namespace LL.ViewModels
{
	internal class AdminViewModel : ViewModel
	{
		public bool IsMajorAdmin => (UserManager.CurrentUser as Admin).Type == AdminType.Major;
	}
}