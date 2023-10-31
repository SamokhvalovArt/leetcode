using System.Globalization;

namespace Samokhvalov.LeetCode.Problems.HashMap;

/// <summary>
/// [5, 6, 1, 0, 2, 4, 3, 56, 50, 51, 52, 52]
/// 7 (0, 1, 2, 3, 4, 5, 6)
/// </summary>
public class LongestConsecutiveSequence : ILeetCodeProblem
{
    public string ProblemUrl { get; }
    public ProblemLevel Level { get; }
    
    public void Run()
    {
        var list = new List<int>();
        for (var i = 100000; i > 0; i--)
        {
            list.Add(i);
        }

        var numbers = new[] { 5, 6, 1, 0, 2, 4, 3, 56, 50, 51, 52, 52 };
        
        Console.WriteLine($"Numbers => {string.Join(", ", numbers)}");
        Console.WriteLine($"Result => {DoImpl1(numbers)}");
    }

    public bool Solved => true;

    private static int DoImpl1(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }
        
        System.Array.Sort(nums);

        var result = 1;
        var tmpResult = 1;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] == nums[i])
            {
                continue;
            }    
            
            if (nums[i - 1] + 1 == nums[i])
            {
                tmpResult++;
                result = tmpResult > result ? tmpResult : result;
                continue;
            }

            tmpResult = 1;
        }
        return result;
    }

    private static int DoImpl2(int[] numbers)
    {
        
        return -1;
    }
}