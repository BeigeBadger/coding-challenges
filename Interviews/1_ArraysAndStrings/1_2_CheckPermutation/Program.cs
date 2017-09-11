using System;

namespace _1_2_CheckPermutation
{
	internal class Program
	{
		private const int expectedNumberOfArgs = 2;

		/// <summary>
		/// Given two strings, write a method to decide if one is a permutation of the other.
		/// </summary>
		private static void Main(string[] args)
		{
			Console.WriteLine("Please enter your input string in the form of: stringToMutate|comparisonString");

			string inputString = "";

			do
			{
				inputString = Console.ReadLine();
			}
			while (string.IsNullOrWhiteSpace(inputString));

			string[] inputParts = inputString.Trim().Split('|');
			int actualNumberOfArgs = inputParts.Length;

			HandleNumberOfArgumentsMismatch(expectedNumberOfArgs, actualNumberOfArgs);

			string permutationSeed = inputParts[0];
			string compareTo = inputParts[1];

			bool isAPermutation = IsPermutationSameLength(permutationSeed, compareTo);
			//bool isAPermutation = IsPermutationRunningCharacterTotal(permutationSeed, compareTo);
			//bool isAPermutation = IsPermutationDifferentLengths(permutationSeed, compareTo);

			string outcomeMessage = $"'{compareTo}' {(isAPermutation ? "DOES" : "DOES NOT")} contain a permutation of '{permutationSeed}'.";

			Console.WriteLine(outcomeMessage);
			Console.ReadLine();
		}

		private static void HandleNumberOfArgumentsMismatch(int expectedNumberOfArgs, int actualNumberOfArgs)
		{
			if (expectedNumberOfArgs != actualNumberOfArgs)
				throw new ArgumentException($"Expected {expectedNumberOfArgs} arguments but got {actualNumberOfArgs}");
		}

		private static void IncrementCharacterOccuranceCount(char[] seedArray, int[] letterOccurances)
		{
			foreach (char c in seedArray)
			{
				letterOccurances[c]++;
			}
		}

		private static bool CalculateIsPermutation(char[] compareArray, int[] letterOccurances)
		{
			for (int i = 0; i < compareArray.Length; i++)
			{
				int character = compareArray[i];
				letterOccurances[character]--;

				if (letterOccurances[character] < 0)
				{
					return false;
				}
			}

			return true;
		}

		private static bool IsPermutationRunningCharacterTotal(string permutationSeed, string compareTo)
		{
			if (permutationSeed.Length != compareTo.Length)
			{
				return false;
			}

			int[] letters = new int[128];
			char[] seedArray = permutationSeed.ToCharArray();
			char[] compareArray = compareTo.ToCharArray();

			IncrementCharacterOccuranceCount(seedArray, letters);

			bool isPermuatation = CalculateIsPermutation(compareArray, letters);

			return isPermuatation;
		}

		private static bool IsPermutationSameLength(string permutationSeed, string compareTo)
		{
			char[] permutationSeedChars = permutationSeed.ToCharArray();
			char[] comparetoChars = compareTo.ToCharArray();

			if (permutationSeedChars.Length != comparetoChars.Length)
				return false;

			Array.Sort(permutationSeedChars);
			Array.Sort(comparetoChars);

			return permutationSeedChars.Equals(comparetoChars);
		}
	}
}