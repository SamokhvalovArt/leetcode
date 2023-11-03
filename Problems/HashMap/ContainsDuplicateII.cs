namespace Samokhvalov.LeetCode.Problems.HashMap;

/// <summary>
/// Input: nums = [1,2,3,1], k = 3
/// Output: true
/// </summary>
public class ContainsDuplicateII : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/contains-duplicate-ii";

    public ProblemLevel Level => ProblemLevel.Easy;
    public void Run()
    {
        var nums = new[] { 1, 2, 3, 1 };
        var k = 3;

        Console.WriteLine(nums.ToStringCollection());
        Console.WriteLine(k);
        Console.WriteLine($"ContainsNearbyDuplicate => {ContainsNearbyDuplicate(nums, k)}");
    }

    public bool Solved => true;
    
    private bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>
        {
            [nums[0]] = 0
        };
        
        for (var i = 1; i < nums.Length; i++)
        {
            var value = nums[i];

            if (dict.TryGetValue(value, out var index) && Math.Abs(index - i) <= k)
            {
                return true;
            }

            dict[value] = i;
        }
        
        return false;
    }
}