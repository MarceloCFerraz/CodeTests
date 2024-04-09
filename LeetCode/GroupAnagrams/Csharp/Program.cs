
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
    var map = new Dictionary<string, IList<string>>();

    for (int i = 0; i < strings.Length; i++)
    {
        var word = strings[i];

        var arr = word.ToCharArray();
        Array.Sort(arr);

        var sorted = new string(arr);

        if (map.ContainsKey(sorted))
            map[sorted].Add(word);
        else
            map.Add(sorted, new List<string>() { word });
    }

    var response = new List<IList<string>>(map.Values);

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