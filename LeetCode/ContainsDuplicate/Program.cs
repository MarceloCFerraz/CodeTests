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

Console.WriteLine($"Contains Duplis? {ContainsDuplicate(new List<short>(106) { 1, 2, 2, 4, 5 })}");