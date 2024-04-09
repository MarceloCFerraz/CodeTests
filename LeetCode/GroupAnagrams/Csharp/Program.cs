
static void PrintItems(IList<IList<string>> items)
{
    foreach (var item in items)
    {
        Console.Write($"[{string.Join(", ", item)}], ");
    }
    Console.WriteLine();
}

static IList<IList<string>> GroupAnagrams(string[] strings)
{
    var response = new List<IList<string>>();
    int count = -1;

    for (int i = 0; i < strings.Length; i++)
    {
        if (!response.Any(words => words.Contains(strings[i])))
        {
            response.Add([strings[i]]);
            count++;
        }
        else continue;

        for (int j = 0; j < strings.Length; j++)
        {
            if (j != i && isAnagram(strings[i], strings[j]))
                response[count].Add(strings[j]);
        }
    }

    Console.Write("Response: ");
    PrintItems(response);
    return response;
}

static bool isAnagram(string candidate, string word)
{
    if (candidate.Length != word.Length) return false;

    var read = new Dictionary<char, int>(candidate.Length);

    for (var i = 0; i < word.Length; i++)
    {
        var s = candidate[i];
        var t = word[i];

        if (!read.ContainsKey(s))
            read.Add(s, 0);
        if (!read.ContainsKey(t))
            read.Add(t, 0);

        read[s] += 1;
        read[t] -= 1;
    }

    return read.All(m => m.Value == 0);
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

var result4 = GroupAnagrams(["abc", "cba", "cd", "bac"]);
var test4 = result4[0].SequenceEqual(["abc", "cba", "bac"]) // compare like this
    && result4[1].SequenceEqual(["cd"])
    ? "PASS" : "FAIL";

Console.WriteLine($"Test 4: {test4}");