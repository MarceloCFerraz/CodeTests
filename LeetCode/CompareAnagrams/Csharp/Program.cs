

static bool IsAnagram(string s, string t)
{
    if (
        s.Length != t.Length // If `s` and `t` are anagrams, they should have the same length
    ) return false;

    var count = s.Length;

    for (int i = 0; i < t.Length; i++)
    {
        Console.Write($"Checking {t[i]} ");
        Console.Write("Comparing with ");
        for (int j = 0; j < s.Length; j++)
        {
            Console.Write($"{s[j]} ");
            if (s[j] == t[i])
            {
                s = s.Remove(j, 1);
                Console.Write("(OK)");
                count--;
                break;
            }
        }
        Console.WriteLine();
        // // the above is basically doing this:
        // if (s.Contains(t[i]))
        //     count--;
    }
    Console.WriteLine();

    return count == 0;
}

var test1 = IsAnagram("word", "lord") ? "FAIL" : "PASS";
var test2 = IsAnagram("word", "word") ? "PASS" : "FAIL";
var test3 = IsAnagram("aacc", "ccac") ? "FAIL" : "PASS";

Console.WriteLine($"Test 1: {test1}");
Console.WriteLine($"Test 2: {test2}");
Console.WriteLine($"Test 3: {test3}");
