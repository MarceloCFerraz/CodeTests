bool ContainsDuplicate(List<int> nums)
{
    var read = new HashSet<int>();

    for (int i = 0; i < nums.Count(); i++)
    {
        if (read.Contains(nums[i])) return true;
        else read.Add(nums[i]);
    }
    return false;
}

var test1 = new List<int>(106) { 1, 2, 3, 1 };
var result1 = ContainsDuplicate(test1) ? "PASS" : "FAIL";

var test2 = new List<int>(106) { 1, 2, 3, 4 };
var result2 = ContainsDuplicate(nums: test2) ? "FAIL" : "PASS";

var test3 = new List<int>(106) { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };
var result3 = ContainsDuplicate(test3) ? "PASS" : "FAIL";

Console.WriteLine($"Test 1: {result1}");
Console.WriteLine($"Test 2: {result2}");
Console.WriteLine($"Test 3: {result3}");