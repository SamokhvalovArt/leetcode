namespace Samokhvalov.LeetCode.Problems.HashMap;

/// <summary>
/// Input: nums = [2,7,11,15], target = 9
/// Output: [0,1]
/// Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
/// </summary>
public class TwoSum : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/two-sum";

    public ProblemLevel Level => ProblemLevel.Easy;
    
    public void Run()
    {
        var nums = new[] { -3, 4, 3, 90 };
        var target = 0;
        
        Console.WriteLine($"Nums => {nums.ToStringCollection()}");
        Console.WriteLine($"Target => {target}");
        Console.WriteLine($"TwoSum => {TwoSumImpl(nums, target).ToStringCollection()}");
    }

    public bool Solved => true;
    
    private int[] TwoSumImpl(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            var number = nums[i];

            var neededNumber = target - number;
            

            if (dict.TryGetValue(neededNumber, out var value))
            {
                return new[] { value, i };
            }
            
            dict[number] = i;
        }
        
        return new[] { 1 };
    }
}