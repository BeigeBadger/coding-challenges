using System;
using System.Text.RegularExpressions;

namespace _1_3_Urlify
{
	internal class Program
	{
		private const string replacement = "%20";

		/// <summary>
		/// Write a method to replace all spaces in a string with '%20: You may assume that the string
		/// has sufficient space at the end to hold the additional characters, and that you are given the "true"
		/// length of the string.
		///
		/// EXAMPLE
		/// Input: "Mr John Smith        ", 13
		/// Output: "Mr%20John%20Smith"
		/// </summary>
		private static void Main(string[] args)
		{
			Console.WriteLine("Please enter your input string in the form of: 'string in goes here, trueLength' where true length is an int");

			string inputString = "";

			do
			{
				inputString = Console.ReadLine();
			}
			while (string.IsNullOrWhiteSpace(inputString));

			string[] inputParts = inputString.Trim().Split(',');
			int expectedNumberOfArgs = 2;
			int actualNumberOfArgs = inputParts.Length;

			if (expectedNumberOfArgs != actualNumberOfArgs)
				throw new ArgumentException($"Expected {expectedNumberOfArgs} arguments but got {actualNumberOfArgs}");

			string inputText = inputParts[0];
			bool isInt = int.TryParse(inputParts[1], out int inputTrueLength);

			if (!isInt)
				throw new ArgumentException($"Expected {nameof(inputTrueLength)} to be an integer but it was not, '{inputTrueLength}' is not a valid integer.");

			//string outcomeMessage = UrlifyUsingStringMethods(inputText, inputTrueLength);
			string outcomeMessage = UrlifyUsingRegex(inputText, inputTrueLength);

			Console.WriteLine(outcomeMessage);
			Console.ReadLine();
		}

		private static string UrlifyUsingStringMethods(string input, int length)
		{
			string trimmedInput = input.Substring(0, length);

			string[] inputWords = trimmedInput.Split(' ');
			string output = string.Join(replacement, inputWords);

			return output;
		}

		private static string UrlifyUsingRegex(string input, int length)
		{
			string trimmedInput = input.Substring(0, length);

			string pattern = @"\s+";
			Regex regex = new Regex(pattern);
			string output = regex.Replace(trimmedInput, replacement);

			return output;
		}
	}
}