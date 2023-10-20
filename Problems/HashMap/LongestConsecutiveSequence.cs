namespace Samokhvalov.LeetCode.Problems.HashMap;

/// <summary>
/// Input: nums = [100,4,200,1,3,2]
/// Output: 4
/// Explanation: The longest consecutive elements sequence is [1, 2, 3, 4]. Therefore its length is 4.
/// </summary>
public class LongestConsecutiveSequence : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/longest-consecutive-sequence";

    public ProblemLevel Level => ProblemLevel.Medium;
    public void Run()
    {
        var nums = new[] { 1,5,0,3,2,4 };
        
        Console.WriteLine($"Nums => {nums.ToStringCollection()}");
        Console.WriteLine($"LongestConsecutive => {LongestConsecutive(nums)}");
    }

    public bool Solved => false;
    
    private static int LongestConsecutive(int[] nums)
    {
        var elements = new Dictionary<int, int>();
        var longestConsecutive = 1;
        foreach (var num in nums)
        {
            if (elements.ContainsKey(num))
            {
                continue;
            }

            

            // longestConsecutive = numConsecutive > longestConsecutive ? numConsecutive : longestConsecutive;
        }
        
        return longestConsecutive;
    }
}