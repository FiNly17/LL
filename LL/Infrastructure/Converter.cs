using System;

namespace LL.Infrastructure
{
	public static class Converter
	{
		public static double? StringToDouble(string stringValue)
		{
			try
			{
				return Convert.ToDouble(stringValue.Replace(".", ","));
			}
			catch
			{
				return null;
			}
		}
	}
}