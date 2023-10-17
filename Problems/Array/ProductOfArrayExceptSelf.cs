namespace Samokhvalov.LeetCode.Problems.Array;

public class ProductOfArrayExceptSelf : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/product-of-array-except-self";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        var nums = new[] { 1, 2, 3, 0 };
        
        Console.WriteLine($"Before action -> {string.Join(", ", nums)}");
        Console.WriteLine($"Before action -> {string.Join(", ", ProductExceptSelf(nums))}");
    }

    private int[] ProductExceptSelf(int[] nums)
    {
        var totalProduct = 1;
        var zeroCount = 0;
        var resultNums = new int[nums.Length];
        
        foreach (var t in nums)
        {
            if (t == 0)
            {
                zeroCount++;
                continue;
            }

            totalProduct *= t;
        }
        
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0 && zeroCount == 0)
            {
                resultNums[i] = totalProduct / nums[i];
                continue;
            }

            if (nums[i] == 0 && zeroCount == 1)
            {
                resultNums[i] = totalProduct / 1;
                continue;
            }

            resultNums[i] = 0;
        }

        return resultNums;
    }
    
    public bool Solved => true;
}