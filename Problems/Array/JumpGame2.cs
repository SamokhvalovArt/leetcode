namespace Samokhvalov.LeetCode.Problems.Array;

/// <summary>
/// Input: nums = [2,3,1,1,4]
/// Output: 2
/// Explanation: The minimum number of jumps to reach the last index is 2.
/// Jump 1 step from index 0 to 1, then 3 steps to the last index.
/// </summary>
public class JumpGame2 : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/jump-game-ii/";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        var nums = new[] { 2, 1, 9, 6, 9, 6, 1, 2, 9, 1, 1 };
        Console.WriteLine($"The result is -> {Jump(nums).ToString()}");
    }
    
    private int Jump(int[] nums)
    {
        var cursorFar = 0;
        var cursorEnd = 0;
        var jumpsCount = 0;

        for (var i = 0; i < nums.Length - 1; i++)
        {
            cursorFar = Math.Max(cursorFar, nums[i] + i);

            if (cursorEnd == i)
            {
                jumpsCount++;
                cursorEnd = cursorFar;
            }
        }

        return jumpsCount;
    }

    public bool Solved => true;
}