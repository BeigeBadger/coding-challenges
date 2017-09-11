using System;

namespace _1_2_CheckPermutation
{
	internal class Program
	{
		/// <summary>
		/// Given two strings, write a method to decide if one is a permutation of the other.
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

			string[] inputParts = inputString.Trim().Split('|');
			int expectedNumberOfArgs = 2;
			int actualNumberOfArgs = inputParts.Length;

			if (expectedNumberOfArgs != actualNumberOfArgs)
				throw new ArgumentException($"Expected {expectedNumberOfArgs} arguments but got {actualNumberOfArgs}");

			string permutationSeed = inputParts[0];
			string compareTo = inputParts[1];

			bool isAPermutation = IsPermutationSameLength(permutationSeed, compareTo);
			//bool isAPermutation = IsPermutationDifferentLengths(permutationSeed, compareTo);

			string outcomeMessage = $"'{compareTo}' {(isAPermutation ? "DOES" : "DOES NOT")} contain a permutation of '{permutationSeed}'.";

			Console.WriteLine(outcomeMessage);
			Console.ReadLine();
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

		/// <summary>
		/// Falls down if a character in the permutationSeed appears more than once.
		/// This will result in a false negative
		/// </summary>
		/// <returns></returns>
		private static bool IsPermutationDifferentLengths(string permutationSeed, string compareTo)
		{
			int numberOfPermutationChars = permutationSeed.Length;
			int numberOfCompareToChars = compareTo.Length;

			int[] permutationIndices = new int[numberOfPermutationChars];

			for (int i = 0; i < numberOfPermutationChars; i++)
			{
				char currentSearchChar = permutationSeed[i];
				int indexOfCharacter = compareTo.IndexOf(currentSearchChar);

				if (indexOfCharacter == -1)
					return false;

				permutationIndices[i] = indexOfCharacter;
			}

			Array.Sort(permutationIndices);

			int numberOfIndices = permutationIndices.Length;

			for (int j = 0; j < numberOfIndices - 1; j++)
			{
				int nextIndex = j + 1 < numberOfIndices ? j + 1 : -1;

				if (nextIndex == -1 || permutationIndices[nextIndex] - permutationIndices[j] >= 2)
					return false;
			}

			return true;
		}
	}
}