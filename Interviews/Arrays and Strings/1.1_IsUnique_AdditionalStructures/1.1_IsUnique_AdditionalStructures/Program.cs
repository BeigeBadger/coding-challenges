using System;
using System.Linq;

namespace _1._1_IsUnique_AdditionalStructures
{
	internal class Program
	{
		/// <summary>
		/// Is Unique: Implement an algorithm to determine if a string has all unique characters.
		/// </summary>
		/// <param name="args"></param>
		private static void Main(string[] args)
		{
			Console.WriteLine("Please enter your input string");

			string inputString = "";

			do
			{
				inputString = Console.ReadLine();
			}
			while (string.IsNullOrWhiteSpace(inputString));

			Console.WriteLine(GenerateOutcome(inputString));
			Console.ReadLine();
		}

		private static string GenerateOutcome(string inputString)
		{
			char[] allInputedCharacters = inputString.ToCharArray();
			char[] distinctCharacters = allInputedCharacters.Distinct().ToArray();

			int totalNumberOfCharacters = allInputedCharacters.Length;
			int numberOfDistinctCharacters = distinctCharacters.Length;

			bool areAllCharactersUnique = totalNumberOfCharacters == numberOfDistinctCharacters;

			return $"{(areAllCharactersUnique ? "Only unique characters are contained in" : "There are duplicated characters in")} '{inputString}'.";
		}
	}
}