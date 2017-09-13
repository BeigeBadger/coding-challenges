using System;
using System.Text;

namespace _1_6_StringCompression
{
	internal class Program
	{
		/// <summary>
		/// Implement a method to perform basic string compression using the counts
		/// of repeated characters.For example, the string aabcccccaaa would become a2b1c5a3.If the
		/// "compressed" string would not become smaller than the original string, your method should return
		/// the original string. You can assume the string has only uppercase and lowercase letters(a - z).
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

			HandleNonLetterCharacters(inputString);

			string outcomeMessage = $"The compressed string of '{inputString}' is '{CompressString(inputString)}'.";

			Console.WriteLine(outcomeMessage);
			Console.ReadLine();
		}

		private static void HandleNonLetterCharacters(string input)
		{
			foreach (char c in input)
			{
				if (!Char.IsLetter(c))
					throw new ArgumentException($"Input ({input}) contained non-letter characters.");
			}
		}

		private static string CompressString(string input)
		{
			string compressedString = BuildCompressedString(input);
			string result = compressedString.Length < input.Length ? compressedString : input;

			return result;
		}

		private static string BuildCompressedString(string input)
		{
			char[] inputChars = input.ToCharArray();

			int numberOfOccurances = 1;
			char lastChar = ' ';
			StringBuilder stringBuilder = new StringBuilder();

			for (int i = 0; i < inputChars.Length; i++)
			{
				char currentChar = inputChars[i];

				if (lastChar == currentChar)
				{
					numberOfOccurances++;

					if (i + 1 == inputChars.Length)
						stringBuilder.Append($"{lastChar}{numberOfOccurances}");
				}
				else if (lastChar != ' ')
				{
					stringBuilder.Append($"{lastChar}{numberOfOccurances}");
					numberOfOccurances = 1;
				}

				lastChar = currentChar;
			}

			return stringBuilder.ToString();
		}
	}
}