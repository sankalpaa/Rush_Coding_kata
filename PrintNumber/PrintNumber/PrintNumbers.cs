using System.Text;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace PrintNumber
{
	public class PrintNumbers
	{
		[TestCase(1, "one")]
		[TestCase(2, "two")]
		[TestCase(3, "three")]
		[TestCase(20, "twenty")]
		[TestCase(21, "twenty one")]
		[TestCase(24, "twenty four")]
		[TestCase(30, "thirty")]
		[TestCase(35, "thirty five")]
		[TestCase(100, "one hundred")]
		[TestCase(110, "one hundred and ten")]
		[TestCase(556, "five hundred and fifty six")]
		[TestCase(7000, "seven thousand")]
		[TestCase(11812, "eleven thousand eight hundred and twelve")]
		[TestCase(13014, "thirteen thousand and fourteen")]
		public void ToEnglishShouldReturnNumberInText(int number, string numberInText)
		{
			ToEnglish(number).Should().Be(numberInText);
		}

		private string ToEnglish(int number)
		{
			int value;
			var numberTextBuilder = new StringBuilder();
			var tenth = new Dictionary<int, string>
				{
					{20,"twenty"},
					{30,"thirty"},
					{50, "fifty"},
				};
			var numbers = new Dictionary<int, string>
			    {
				    {1, "one"},
				    {2, "two"},
				    {3, "three"},
					{4, "four"},
					{5, "five"},
					{10, "ten"},
					{6, "six"},
					{7, "seven"},
					{11, "eleven"},
					{8, "eight"},
					{12, "twelve"},
					{13, "thirteen"},
					{14, "fourteen"},
			    };
			if (number >= 1000)
			{
				value = number / 1000;
				numberTextBuilder.Append(numbers[value]);
				numberTextBuilder.Append(" thousand");
				number %= 1000;
			}

			if (number >= 100)
			{
				value = number / 100;
				numberTextBuilder.Append(numberTextBuilder.Length > 1 ? " " : "");
				numberTextBuilder.Append(numbers[value]);
				numberTextBuilder.Append(" hundred");
				number %= 100;
			}

			if (number >= 20)
			{
				value = number / 10;
				numberTextBuilder.Append(numberTextBuilder.Length > 1 ? " and " : "");
				numberTextBuilder.Append(tenth[value * 10]);
				number %= 10;
			}
			if (number != 0)
			{
				numberTextBuilder.Append(numberTextBuilder.Length > 1 ? " " : "");
				numberTextBuilder.Append(numberTextBuilder.Length > 1 && number > 9 ? "and " : "");
				numberTextBuilder.Append(numbers[number]);
			}

			return numberTextBuilder.ToString();
		}
	}
}
