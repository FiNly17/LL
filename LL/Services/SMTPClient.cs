using System;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Security;

namespace LL.Services
{
	public static class SMTPClient
	{
		private static readonly string address;
		private static readonly SecureString password;
		private static readonly string host;
		private static readonly int port;

		public static bool IsAvailable { get; }

		static SMTPClient()
		{
			try
			{
				address = ConfigurationManager.AppSettings["SMTPAddress"];
				password = new SecureString();
				foreach (var ch in ConfigurationManager.AppSettings["SMTPPassword"].ToCharArray())
					password.AppendChar(ch);
				password.MakeReadOnly();
				host = ConfigurationManager.AppSettings["SMTPHost"];
				port = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]);
				IsAvailable = true;
			}
			catch (Exception ex)
			{
				Logger.Log(ex);
				IsAvailable = false;
			}
		}

		public static void SendMail(string fromName, string toMail, string toName, string subject, string body)
		{
			if (!IsAvailable)
				return;

			try
			{
				var from = new MailAddress(address, fromName);
				var to = new MailAddress(toMail, toName);

				using (var mailMessage = new MailMessage(from, to))
				{
					using (var smtp = new SmtpClient())
					{
						mailMessage.Subject = subject;
						mailMessage.Body = body;

						smtp.Host = host;
						smtp.Port = port;
						smtp.EnableSsl = true;
						smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
						smtp.UseDefaultCredentials = false;

						smtp.Credentials = new NetworkCredential(from.Address, password);

						smtp.Send(mailMessage);
					}
				}
			}
			catch (Exception ex)
			{
				Logger.Log(ex);
			}
		}
	}
}