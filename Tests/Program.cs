using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LL.Services;

namespace Tests
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.WriteLine(TestMail() ? "Ok" : "Not ok");
		}

		public static bool TestMail()
		{
			return SMTPClient.SendMail("Отправитель", "kirilloleshkevich7@gmail.com", "Получатель", "Тест", "Тест тест тест", "chisinjorofake@gmail", "chi14789632", true);
		}
	}
}