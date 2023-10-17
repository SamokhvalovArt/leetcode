namespace Samokhvalov.LeetCode.Problems.Array;

/// <summary>
/// Input: nums = [2,2,1,1,1,2,2]
/// Output: 2
/// </summary>
public class MajorityElement : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/majority-element";

    public ProblemLevel Level => ProblemLevel.Easy;
    
    public void Run()
    {
        var nums = new[] { 2, 1, 1};
        var result = MajorityElementImpl(nums);
        
        Console.WriteLine($"Majority element is {result}");
    }

    private static int MajorityElementImpl(int[] nums)
    {
        // идея в том что нет необходимости считать остальные элементы
        // спиздил
        var value = -1;
        var count = 0;
        
        foreach (var num in nums)
        {
            if (count == 0)
            {
                value = num;
                count++;
                continue;
            }

            if (value != num)
            {
                count--;
                continue;
            } 

            count++;
        }

        return value;
    }

    private static int MajorityElementImplFirstSolution(int[] nums)
    {
        return nums.GroupBy(x => x)
            .Select(x => (x.Key, x.Count()))
            .OrderByDescending(x => x.Item2)
            .FirstOrDefault().Key;   
    }
    
    public bool Solved => true;
}