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

            // if (i != j && candidate == word) // change condition to check if word and candidate are anagrams
            if (i != j && areAnagrams(candidate, word)) // change condition to check if word and candidate are anagrams
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

static bool areAnagrams(string s, string t)
{
    if (s.Length != t.Length) return false;

    var count = new Dictionary<char, int>();

    for (int i = 0; i < s.Length; i++)
    {
        if (!count.TryGetValue(s[i], out _))
            count.Add(s[i], 0);

        if (!count.TryGetValue(t[i], out _))
            count.Add(t[i], 0);

        count[s[i]]++;
        count[t[i]]--;
    }

    return count.All(el => el.Value == 0);
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
var test2 = result2[0].SequenceEqual([""]) // check if the first element is an array with an empty string
    ? "PASS" : "FAIL";

Console.WriteLine($"Test 2: {test2}");

var result3 = GroupAnagrams(["abc"]);
var test3 = result3[0].SequenceEqual(["abc"]) // check if the first element is an array with "abc"
    ? "PASS" : "FAIL";

Console.WriteLine($"Test 3: {test3}");