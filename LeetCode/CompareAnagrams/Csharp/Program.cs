static bool IsAnagram(string s, string t)
{
    if (
        s.Length != t.Length // If `s` and `t` are anagrams, they should have the same length
    ) return false;

    var read = new int[26]; // 26 stands for 26 characters in the alphabet. We'll count ascii characters: https://www.ascii-code.com/

    for (int i = 0; i < s.Length; i++)
    {
        // lowercase a is 97 in ascii table, we can know exactly where to put the count for each character,
        // we just need to subtract its char count by 97  since we're only dealing with lowercase english letters, 
        // otherwise, would we'd replace 97 with something else (e.g., 65 to work with uppercase as well).
        // In such case, we'd also need to mess with the read size, 26 wouldn't be enough.
        // An implementation to support Unicode would probably be similar, but would probably use a lot more memory
        // since there are millions of unicase characters, so a better idea would probably to stick with the Dictionary version of this.
        read[s[i] - 'a'] += 1;
        read[t[i] - 'a'] -= 1;
    }

    foreach (var ascii in read)
        if (ascii != 0) return false;

    return true;
}

var test1 = IsAnagram("word", "lord") ? "FAIL" : "PASS";
var test2 = IsAnagram("word", "word") ? "PASS" : "FAIL";
var test3 = IsAnagram("aacc", "ccac") ? "FAIL" : "PASS";
var test4 = IsAnagram("tuxyz", "zyxut") ? "PASS" : "FAIL";

Console.WriteLine($"Test 1: {test1}");
Console.WriteLine($"Test 2: {test2}");
Console.WriteLine($"Test 3: {test3}");
Console.WriteLine($"Test 4: {test4}");
