namespace Samokhvalov.LeetCode.Problems.TwoPointers;

/// <summary>
/// Input: numbers = [1, 2, 7, 11, 15], target = 13
///        numbers = [2, 3, 4],         target = 6
/// Output: [1,2]
/// Explanation: The sum of 2 and 7 is 9. Therefore, index1 = 1, index2 = 2. We return [1, 2].v
/// </summary>
public class TwoSumIiInputArrayIsSorted : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/two-sum-ii-input-array-is-sorted";

    public ProblemLevel Level => ProblemLevel.Medium;

    public void Run()
    {
        var numbers = new[] { -1, -1, 1 };
        var target = -2;
        
        Console.WriteLine($"Numbers => {string.Join(", ", numbers)}");
        Console.WriteLine($"Target => {target}");
        Console.WriteLine($"TwoSum => {string.Join(",", TwoSum(numbers, target))}");
    }

    public bool Solved => true;
    
    private int[] TwoSum(int[] numbers, int target)
    {
        var i = 0;
        for (var backIndex = numbers.Length - 1;;)
        {
            if (numbers[i] + numbers[backIndex] > target)
            {
                backIndex--;
                continue;
            }
            
            if (numbers[i] + numbers[backIndex] < target)
            {
                i++;
                continue;
            }

            if (numbers[i] + numbers[backIndex] == target)
            {
                return backIndex > i
                    ? new[] { i + 1, backIndex + 1 }
                    : new[] { backIndex + 1, i + 1 };
            }
        }
    }
}