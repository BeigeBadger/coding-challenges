using System;
using System.Collections.Generic;

namespace _1_5_OneAway
{
	internal class Program
	{
		private const int expectedNumberOfArgs = 2;

		/// <summary>
		/// There are three types of edits that can be performed on strings: insert a character,
		/// remove a character, or replace a character.Given two strings, write a function to check if they are
		/// one edit (or zero edits) away.
		/// EXAMPLE
		/// pale, ple -> true
		/// pales, pale -> true
		/// pale, bale -> true
		/// pale, bake -> false
		/// </summary>
		private static void Main(string[] args)
		{
			Console.WriteLine("Please enter your input string in the form of: firstString, secondString");

			string inputString = "";

			do
			{
				inputString = Console.ReadLine();
			}
			while (string.IsNullOrWhiteSpace(inputString));

			string[] inputParts = inputString.Trim().Split(',');
			int actualNumberOfArgs = inputParts.Length;

			HandleNumberOfArgumentsMismatch(expectedNumberOfArgs, actualNumberOfArgs);

			// Remove any spaces from the input strings
			string inputOne = inputParts[0].Replace(" ", "").Trim();
			string inputTwo = inputParts[1].Replace(" ", "").Trim();

			bool isOneEditAway = IsOneEditAway(inputOne, inputTwo);

			string outcomeMessage = $"'{inputOne}' {(isOneEditAway ? "IS" : "IS NOT")} one edit away from '{inputTwo}'.";

			Console.WriteLine(outcomeMessage);
			Console.ReadLine();
		}

		private static void HandleNumberOfArgumentsMismatch(int expectedNumberOfArgs, int actualNumberOfArgs)
		{
			if (expectedNumberOfArgs != actualNumberOfArgs)
				throw new ArgumentException($"Expected {expectedNumberOfArgs} arguments but got {actualNumberOfArgs}");
		}

		private static bool IsOneEditAway(string inputOne, string inputTwo)
		{
			bool areStringsWithinLengthConstraint = StringLengthsAreWithinBounds(inputOne, inputTwo);

			if (!areStringsWithinLengthConstraint)
				throw new ArgumentException($"The difference in string lengths between '{inputOne}' and '{inputTwo}' is too great for them to be one edit away.");

			char[] inputOneChars = inputOne.ToCharArray();
			char[] inputTwoChars = inputTwo.ToCharArray();

			Dictionary<char, int> inputOneCharacterOccurances = GetCharacterOccuranceMapping(inputOneChars);
			Dictionary<char, int> inputTwoCharacterOccurances = GetCharacterOccuranceMapping(inputTwoChars);

			bool firstStringHasMoreUniqueCharacters = inputOneCharacterOccurances.Keys.Count >= inputTwoCharacterOccurances.Keys.Count;

			if (firstStringHasMoreUniqueCharacters)
				return DifferenceIsOneCharacter(inputOneCharacterOccurances, inputTwoCharacterOccurances, inputOneChars);

			return DifferenceIsOneCharacter(inputTwoCharacterOccurances, inputOneCharacterOccurances, inputTwoChars);
		}

		private static bool StringLengthsAreWithinBounds(string inputOne, string inputTwo)
		{
			int lengthDifference = inputOne.Length - inputTwo.Length;

			return lengthDifference >= -1 && lengthDifference <= 1;
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

		private static bool DifferenceIsOneCharacter(Dictionary<char, int> mappingWithMoreUniqueCharacters, Dictionary<char, int> mappingWithLessUniqueCharacters, char[] moreUniqueMappingChars)
		{
			int failureCasesEncountered = 0;

			for (int i = 0; i < mappingWithMoreUniqueCharacters.Count; i++)
			{
				char currentCharacter = moreUniqueMappingChars[i];

				bool hasKey = mappingWithLessUniqueCharacters.ContainsKey(currentCharacter);

				if (!hasKey || mappingWithMoreUniqueCharacters[currentCharacter] != mappingWithLessUniqueCharacters[currentCharacter])
				{
					failureCasesEncountered++;
					continue;
				}
			}

			return failureCasesEncountered <= 1;
		}
	}
}