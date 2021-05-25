using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace LL.Services
{
	public static class Validator
	{
		public static Regex NameRegex = new Regex(@"^[А-Яа-яЁёA-Za-z \-]+$");

		public static (bool isValid, List<string> forbiddenSymbols) Validate(string value, Regex regex)
		{
			if (regex.IsMatch(value))
				return (true, null);

			return (false, value.ToCharArray()
				.Where(symbol => !regex.IsMatch(symbol.ToString()))
				.Select(symbol => symbol.ToString()).ToList());
		}

		public static string JoinSymbols(List<string> symbols) => "\"" + string.Join("\", \"", symbols) + "\"";
	}
}