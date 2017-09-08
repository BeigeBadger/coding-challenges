using System;
using System.Linq;

namespace _1._1_IsUnique
{
	internal class Program
	{
		/// <summary>
		/// Is Unique: Implement an algorithm to determine if a string has all unique characters.
		/// What if you cannot use additional data structures?
		/// </summary>
		private static void Main(string[] args)
		{
			Console.WriteLine("Please enter your input string");

			string inputString = "";

			do
			{
				inputString = Console.ReadLine();
			}
			while (string.IsNullOrWhiteSpace(inputString));

			//bool areAllCharactersUnique = IsUniqueUsingLinq(inputString);
			bool areAllCharactersUnique = IsUniqueUsingArray(inputString);

			string outcomeMessage = $"{(areAllCharactersUnique ? "Only unique characters are contained in" : "There are duplicated characters in")} '{inputString}'.";

			Console.WriteLine(outcomeMessage);
			Console.ReadLine();
		}

		private static bool IsUniqueUsingLinq(string inputString)
		{
			char[] allInputedCharacters = inputString.ToCharArray();
			char[] distinctCharacters = allInputedCharacters.Distinct().ToArray();

			int totalNumberOfCharacters = allInputedCharacters.Length;
			int numberOfDistinctCharacters = distinctCharacters.Length;

			return totalNumberOfCharacters == numberOfDistinctCharacters)
		}

		private static bool IsUniqueUsingArray(string inputString)
		{
			int stringLength = inputString.Length;
			char[] allInputedCharacters = new char[stringLength];

			for (int i = 0; i < stringLength; i++)
			{
				if (Array.IndexOf(allInputedCharacters, inputString[i]) != -1)
					return false;

				allInputedCharacters[i] = inputString[i];
			}

			return true;
		}
	}
}