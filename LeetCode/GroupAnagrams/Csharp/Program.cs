static void PrintItems(List<List<string>> items)
{
    foreach (var item in items)
    {
        Console.Write($"[{string.Join(", ", item)}], ");
    }
    Console.WriteLine();
}

static List<List<string>> GroupAnagrams(string[] strings)
{
    var response = new List<List<string>>();
    string? candidate = null;

    for (int i = 0; i < strings.Length; i++)
    {
        if (candidate == null)
        {
            candidate = strings[i];

            if (response.Any(a => a.Contains(candidate)))
                continue;

            response.Add([candidate]);
        }

        for (int j = 0; j < strings.Length; j++)
        {
            var word = strings[j];

            if (i != j && candidate == word) // change condition to check if word and candidate are anagrams
                response
                    .Find(a => a.Contains(candidate))
                    ?.Add(word);
        }
        candidate = null;
    }

    Console.Write("Response: ");
    PrintItems(response);
    return response;
}


/*
Example 1:
    Input: strings = ["abc", "vc" "acb"].
    Output: [["abc","acb"], ["vc"]]

Example 2:
    Input: strings = [""]
    Output: [[""]]

Example 3:
    Input: strings = ["abc"]
    Output: [["abc"]]
*/
var result1 = GroupAnagrams(["abc", "vc", "abc"]);
var test1 = result1[0].SequenceEqual(["abc", "abc"]) // compare like this
    && Enumerable.SequenceEqual(result1[1], ["vc"]) // or like this
    ? "PASS" : "FAIL";

Console.WriteLine($"Test 1: {test1}");

var result2 = GroupAnagrams([""]);
var test2 = result2[0].SequenceEqual([""]) // compare like this
    ? "PASS" : "FAIL";

Console.WriteLine($"Test 2: {test2}");

var result3 = GroupAnagrams(["abc"]);
var test3 = result3[0].SequenceEqual(["abc"]) // compare like this
    ? "PASS" : "FAIL";

Console.WriteLine($"Test 3: {test3}");