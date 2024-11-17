using System;

/*
 * Write a function ToWeirdCase that accepts a string, and returns the same string with all even indexed characters in each word upper cased, and all odd indexed characters in each word lower cased.
 * The indexing just explained is zero based, so the zero-ith index is even, therefore that character should be upper cased.
 *
 * The passed in string will only consist of alphabetical characters and spaces(' ').
 * Spaces will only be present if there are multiple words. Words will be separated by a single space(' ').
 *
 * Examples:
 *   "String" => "StRiNg"
 *   "Weird string case" => "WeIrD StRiNg CaSe"
**/

public class Program
{
	public static string ToWeirdCase(string s)
	{
		return ""; // your code here
	}

	public static void Main()
	{
		Console.WriteLine("Testing your code...");
		bool passing = true;

		var result1 = ToWeirdCase("String");
		if (result1 != "StRiNg") {
			passing = false;
			Console.WriteLine("Tests failed, got \"" + result1 + "\" for input String, expected \"StRiNg\"");
		}

		var result2 = ToWeirdCase("Weird string case");
		if (result2 != "WeIrD StRiNg CaSe") {
			passing = false;
			Console.WriteLine("Tests failed, got \"" + result2 + "\" for input String, expected \"WeIrD StRiNg CaSe\"");
		}

		var result3 = ToWeirdCase("This is a test");
		if (result3 != "ThIs Is A TeSt") {
			passing = false;
			Console.WriteLine("Tests failed, got \"" + result3 + "\" for input String, expected \"ThIs Is A TeSt\"");
		}

		var result4 = ToWeirdCase("");
		if (result4 != "") {
			passing = false;
			Console.WriteLine("Tests failed, got \"" + result4 + "\" for input String, expected \"\"");
		}

		if (passing)
			Console.WriteLine("All tests passed!");
	}
}
