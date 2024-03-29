static int[]? TwoSum(int[] nums, int target)
{
    var response = new Dictionary<int, int>();

    for (int i = 0; i < nums.Length; i++)
    {
        var difference = target - nums[i];

        if (response.ContainsKey(difference))
            return new int[] { i, response[difference] };

        response[nums[i]] = i;
    }
    return null;
}

/*
Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
You may assume that each input would have exactly one solution, and you may not use the same element twice.
You can return the answer in any order.

Example 1:
    Input: nums = [2,7,11,15], target = 9
    Output: [0,1]
    Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].

Example 2:
    Input: nums = [3,2,4], target = 6
    Output: [1,2]

Example 3:
    Input: nums = [3,3], target = 6
    Output: [0,1]
*/


var result1 = TwoSum([3, 2, 4], 6);
var test1 = result1 != null
    && (result1[0] == 1 && result1[1] == 2
        || result1[0] == 2 && result1[1] == 1)
    && (result1.Length == 2)
    ? "PASS" : "FAIL";

Console.WriteLine($"Test 1: {test1}");

var result2 = TwoSum([3, 3], 6);
var test2 = result2 != null
    && (result2[0] == 0 && result2[1] == 1
        || result2[0] == 1 && result2[1] == 0)
    && (result2.Length == 2)
    ? "PASS" : "FAIL";

Console.WriteLine($"Test 2: {test2}");

var result3 = TwoSum([2, 7, 11, 15], 9);
var test3 = result3 != null
    && (result3[0] == 0 && result3[1] == 1
        || result3[0] == 1 && result3[1] == 0)
    && (result3.Length == 2)
    ? "PASS" : "FAIL";

Console.WriteLine($"Test 3: {test3}");
