using System;
using System.Drawing;

using LL.Properties;

namespace LL.Infrastructure
{
	internal class ImageProvider
	{
		private static readonly ImageConverter converter = new ImageConverter();

		public static byte[] GetDefault() => (byte[])converter.ConvertTo(Resources.DefaultCover, typeof(byte[]));

		public static byte[] ImageToByte(string img)
		{
			try
			{
				return (byte[])converter.ConvertTo(new Bitmap(img), typeof(byte[]));
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return GetDefault();
			}
		}
	}
}