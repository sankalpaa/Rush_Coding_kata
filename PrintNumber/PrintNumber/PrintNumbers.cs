﻿using System.Text;
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
		public void ToEnglishShouldReturnNumberInText(int number, string numberInText)
		{
			ToEnglish(number).Should().Be(numberInText);
		}

		private string ToEnglish(int number)
		{
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
			    };
			if (number >= 20)
			{
				int value = number / 10;
				numberTextBuilder.Append(tenth[value * 10]);
				number %= 10;
			}
			if (number != 0)
			{
				numberTextBuilder.Append(numberTextBuilder.Length > 1 ? " " : "");
				numberTextBuilder.Append(numbers[number]);
			}

			return numberTextBuilder.ToString();
		}
	}
}
