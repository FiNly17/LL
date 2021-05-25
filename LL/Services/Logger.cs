using System;
using System.IO;

namespace LL.Services
{
	internal class Logger
	{
		public const string fileName = "LL.log";

		public static void Log(string msg)
		{
			using (var sw = new StreamWriter(fileName))
			{
				sw.WriteLine($"{DateTime.Now:G}: {msg}");
			}
		}

		public static void Log(Exception ex)
		{
			using (var sw = new StreamWriter(fileName))
			{
				sw.WriteLine($"{DateTime.Now:G}: {ex.Message}\n{ex.InnerException}\n{ex.StackTrace}");
			}
		}
	}
}