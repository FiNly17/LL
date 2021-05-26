using System;
using System.Drawing;

using LL.Properties;
using LL.Services;

namespace LL.Infrastructure
{
	internal class ImageProvider
	{
		private static readonly ImageConverter converter = new ImageConverter();

		public static byte[] GetDefault() => (byte[])converter.ConvertTo(Resources.DefaultCover, typeof(byte[]));

		public static (bool status, byte[] result) ImageToByte(string img)
		{
			try
			{
				return (true, (byte[])converter.ConvertTo(new Bitmap(img), typeof(byte[])));
			}
			catch (Exception ex)
			{
				Logger.Log(ex.Message);
				return (false, GetDefault());
			}
		}
	}
}