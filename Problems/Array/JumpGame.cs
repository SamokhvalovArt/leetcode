namespace Samokhvalov.LeetCode.Problems.Array;

/// <summary>
/// Input: nums = [2,3,1,1,4]
/// Output: true
/// Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
/// [2, 0, 0] -> true
/// [2, 0] -> true
/// [1] -> true
/// [0] -> true
/// [2] -> false
/// </summary>
public class JumpGame : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/jump-game";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        var nums = new[] { 3, 2, 5, 0, 4 };
        Console.WriteLine($"The result is -> {CanJump(nums).ToString()}");
        Console.WriteLine($"The result is -> {CanJumpImpl2(nums).ToString()}");
    }
    
    private bool CanJump(int[] nums)
    {
        if (nums.Length == 1 && nums[0] <= 1) return true;
        if (nums.Length == 1) return false;

        var index = 0;
        while (index < nums.Length)
        {
            var stepsCount = nums[index];
            for (var i = index; i < index + nums[index]; i++)
            {
                if (i == nums.Length) return true;
                if (nums[i] > stepsCount)
                {
                    index = i;
                    break;
                }
                stepsCount--;
            }

            if (stepsCount == 0)
            {
                if (index == nums.Length - 1) return true;
                if (nums[index] == 0) return false;
                index += nums[index];
            }
        }

        return true;
    }

    private bool CanJumpImpl2(int[] nums)
    {
        var power = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            power--;
            power = Math.Max(power, nums[i]);
            if (power == 0 && i != nums.Length - 1)
            {
                return false;
            }
        }
        return true;
    }

    public bool Solved => true;
}