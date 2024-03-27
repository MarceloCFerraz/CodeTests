

static bool IsAnagram(string s, string t)
{
    if (
        s.Length != t.Length || // If `s` and `t` are anagrams, they should have the same length
        s.Length < 1 || t.Length > (5 * Math.Pow(10, 4)) // these are just part of the conditions for the problem.
    ) return false;

    // if we were dealing with unicode, the resolution would probably be a bit different, but the logic would remain the same:
    // We're going to split strings into a HashMap. Each character will be a key and their value will be a counter (how many time each char appear)
    var count = new Dictionary<char, int>();

    for (int i = 0; i < s.Length; i++)
    {
        var character = s[i];
        // first populates the HashMap with every character
        AddItem(character, count);
    }

    // then we're going to iterate through `t` and decrement each character count. if all chars have 0 count after this, we have an anagram
    for (int i = 0; i < s.Length; i++)
    {
        var character = t[i];
        try { DecreaseItem(character, count); }
        catch { return false; }
        // if there is an exception here, it means `t` has a character that `s` doesn't have, meaning they're not anagrams
    }

    // so let's check if there is a count that's different to 0
    for (int j = 0; j < s.Length; j++)
    {
        var character = s[j];
        if (count[character] != 0) return false;
    }

    // if the code didn't fail before, then we have a winner :)
    return true;
}

static void AddItem(char item, Dictionary<char, int> dict)
{
    // if the key doesn't exist already, it will throw an error when we try to increment its count
    try { dict[item]++; }
    catch { dict.Add(item, 1); }
}

static void DecreaseItem(char item, Dictionary<char, int> dict)
{
    // if the key doesn't exist already, it will throw an error when we try to decrement its count
    // we could change this function to return a boolean for successful or unsuccessful operations, but its easier this way
    dict[item]--;
}

var string1 = "word";
var string2 = "word";

var isAnagram = IsAnagram(string1, string2)
    ? $"{string1} and {string2} ARE anagrams"
    : $"{string1} and {string2} are NOT anagrams";

Console.WriteLine(isAnagram);
