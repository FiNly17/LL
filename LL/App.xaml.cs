using LL.Services;

using System.Windows;
using System.Windows.Threading;

namespace LL
{
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application
	{
		private void Application_Startup(object sender, StartupEventArgs e)
		{
			DataContext.GetInstance();
		}

		private void Application_Exit(object sender, ExitEventArgs e)
		{
			DataContext.GetInstance().Dispose();
		}

		private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
		{
			DataContext.GetInstance().Dispose();
			Logger.Log(e.Exception);
		}
	}
}