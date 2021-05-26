using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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