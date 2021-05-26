using LL.Services;

using System.Globalization;
using System.Threading;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Threading;

namespace LL
{
	/// <summary>
	/// Логика взаимодействия для App.xaml
	/// </summary>
	public partial class App : Application
	{
		public App()
		{
			InitCulture();
		}

		private void InitCulture()
		{
			var vCulture = new CultureInfo("ru-BY");

			Thread.CurrentThread.CurrentCulture = vCulture;
			Thread.CurrentThread.CurrentUICulture = vCulture;
			CultureInfo.DefaultThreadCurrentCulture = vCulture;
			CultureInfo.DefaultThreadCurrentUICulture = vCulture;

			FrameworkElement.LanguageProperty.OverrideMetadata(typeof(FrameworkElement),
				new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
		}

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