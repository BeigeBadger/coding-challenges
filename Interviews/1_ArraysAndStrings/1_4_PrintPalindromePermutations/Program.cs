using System;
using System.Collections.Generic;
using System.Linq;

namespace _1_4_PrintPalindromePermutations
{
	internal class Program
	{
		/// <summary>
		/// Given a string, write a function to check if it is a permutation of a palindrome. A palindrome is a word or phrase that is the same forwards and backwards. A permutation
		// is a rearrangement of letters.The palindrome does not need to be limited to just dictionary words.
		// EXAMPLE
		// Input: Tact Coa
		// Output: True (permutations: "taco cat". "atco cta". etc.)
		/// </summary>
		private static void Main(string[] args)
		{
			Console.WriteLine("Please enter your input string:");

			string inputString = "";

			do
			{
				inputString = Console.ReadLine();
			}
			while (string.IsNullOrWhiteSpace(inputString));

			// Prevent spaces from being treated as characters
			string sanitisedInput = inputString.Replace(" ", "");
			bool isPalindrome = CanStringCanBeMutatedIntoAPalindrome(sanitisedInput);

			string outcomeMessage = $"The input string '{inputString}' {(isPalindrome ? "DOES" : "DOES NOT")} meet the criteria for a palindrome.";

			Console.WriteLine(outcomeMessage);
			Console.ReadLine();
		}

		// Test input "", "taco cat", "nope", "wahwahwah", "tactcoapapa"
		private static bool CanStringCanBeMutatedIntoAPalindrome(string input)
		{
			char[] characters = input.ToCharArray();
			Dictionary<char, int> characterOccurances = GetCharacterOccuranceMapping(characters);
			bool meetsPalindromeCriteria = HasPalindromeCharacteristics(characterOccurances);

			return meetsPalindromeCriteria;
		}

		private static Dictionary<char, int> GetCharacterOccuranceMapping(char[] characters)
		{
			Dictionary<char, int> charOccurances = new Dictionary<char, int>();

			for (int i = 0; i < characters.Length; i++)
			{
				char currentCharacter = characters[i];
				bool keyExists = charOccurances.ContainsKey(currentCharacter);

				if (keyExists)
				{
					charOccurances[currentCharacter] += 1;
				}
				else
				{
					charOccurances.Add(currentCharacter, 1);
				}
			}

			return charOccurances;
		}

		private static bool HasPalindromeCharacteristics(Dictionary<char, int> characterOccurances)
		{
			// Failure conditions: More than one character having an odd number of occurances

			List<int> occurances = characterOccurances.Values.ToList();
			int numberOfCharactersWithAnOddNumberOfOccurances = 0;

			for (int i = 0; i < occurances.Count; i++)
			{
				if (occurances[i] % 2 != 0)
				{
					numberOfCharactersWithAnOddNumberOfOccurances++;
				}
			}

			return numberOfCharactersWithAnOddNumberOfOccurances <= 1;
		}
	}
}