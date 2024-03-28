// See https://aka.ms/new-console-template for more information
using System.Data;

bool ContainsDuplicate(List<short> nums)
{
    if (nums.Count() < 1 || nums.Count() > 105)
        throw new DataException("The array must contain min 1 and max 105 elements");
    var read = new HashSet<short>();

    for (int i = 0; i < nums.Count(); i++)
    {
        var num = nums[i];

        if (read.Contains(num)) { return true; }
        else { read.Add(num); }
    }
    return false;
}

var test1 = new List<short>(106) { 1, 2, 3, 1 };
var result1 = ContainsDuplicate(test1) ? "PASS" : "FAIL";

var test2 = new List<short>(106) { 1, 2, 3, 4 };
var result2 = ContainsDuplicate(nums: test2) ? "FAIL" : "PASS";

var test3 = new List<short>(106) { 1, 1, 1, 3, 3, 4, 3, 2, 4, 2 };
var result3 = ContainsDuplicate(test3) ? "PASS" : "FAIL";

Console.WriteLine($"Test 1: {result1}");
Console.WriteLine($"Test 2: {result2}");
Console.WriteLine($"Test 3: {result3}");