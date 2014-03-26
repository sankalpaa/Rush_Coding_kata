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
		public void ToEnglishShouldReturnNumberInText(int number, string numberInText)
		{
			ToEnglish(number).Should().Be(numberInText);
		}

		private string ToEnglish(int number)
		{
			var numbers = new Dictionary<int, string>
			    {
				    {1, "one"},
				    {2, "two"},
				    {3, "three"},
			    };

			return numbers[number];
		}
	}
}
