namespace Samokhvalov.LeetCode.Problems.SlidingWindow;

/// <summary>
/// Input: target = 7, nums = [2,3,1,2,4,3]
/// Output: 2
/// Explanation: The subarray [4,3] has the minimal length under the problem constraint.
/// </summary>
public class MinimumSizeSubarraySum : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/minimum-size-subarray-sum";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        var target = 11;
        var nums = new[] { 1 };
        
        Console.WriteLine($"Target - {target} ; Nums - {nums.ToStringCollection()}");
        Console.WriteLine($"Min sub array = {MinSubArrayLen(target, nums)}");
    }

    public bool Solved => true;
    
    private int MinSubArrayLen(int target, int[] nums)
    {
        var result = 0;
        var j = 0;
        var windowSum = nums[j];
        for (var i = 0; i < nums.Length && j < nums.Length; i++)
        {
            if (i != 0)
            {
                windowSum -= nums[i - 1];
            }
            
            while (windowSum < target && j < nums.Length - 1)
            {
                windowSum += nums[++j];
            }

            if (windowSum >= target)
            {
                var tmp = (j - i) + 1;
                result = result == 0 ? tmp : tmp < result ? tmp : result;
            }
        }
        
        return result;
    }
}