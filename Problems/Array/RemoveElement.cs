namespace Samokhvalov.LeetCode.Problems.Array;

/// <summary>
/// Input: nums = [3,2,2,3], val = 3
/// Output: 2, nums = [2,2,_,_]
/// </summary>
public class RemoveElement : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/remove-element/";

    public ProblemLevel Level => ProblemLevel.Easy;
    
    public void Run()
    {
        var nums = new[] { 1,5,6,7,8,8 };
        var val = 1;

        Console.WriteLine($"Before remove -> {string.Join(", ", nums)}");
        
        var result = RemoveElementImpl2(nums, val);
        
        Console.WriteLine($"result = {result}");
        Console.WriteLine($"After remove -> {string.Join(", ", nums)}");
    }

    public bool Solved => true;
    
    private int RemoveElementImpl(int[] nums, int val)
    {
        var cursor = 0;
        var result = 0;
        var _ = 111;

        while (cursor < nums.Length)
        {
            if (nums[cursor] == val)
            {
                nums[cursor] = nums[nums.Length - 1 - result];
                nums[nums.Length - 1 - result] = _;
                result++;
                continue;
            }

            cursor++;
        }

        return nums.Length - result;
    }
    
    private int RemoveElementImpl2(int[] nums, int val)
    {
        var index = 0;
        for(var i = 0; i< nums.Length; i++)
        {
            if (nums[i] == val) continue;
            nums[index] = nums[i];
            index++;
        }
        return index;
    }
}