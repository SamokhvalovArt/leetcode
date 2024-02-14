namespace Samokhvalov.LeetCode.Problems.Intervals;

public class SummaryRanges : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/summary-ranges";

    public ProblemLevel Level => ProblemLevel.Easy;
    
    public void Run()
    {
        var nums = new[] { -3, -2,-1,5 };
        Console.WriteLine($"Nums = {nums.ToStringCollection()}");
        Console.WriteLine($"Results = {SummaryRangesImpl(nums).ToStringCollection()}");
    }

    public bool Solved => true;
    
    private IList<string> SummaryRangesImpl(int[] nums)
    {
        var results = new List<string>();
        var i = 0;
        var j = 0;

        while (j < nums.Length)
        {
            if (j + 1 == nums.Length)
            {
                AddResult();
                j += 1;
                continue;
            }

            if (nums[j + 1] - nums[j] == 1)
            {
                j += 1;
                continue;
            }
            
            AddResult();
            j += 1;
            i = j;
        }

        return results;

        void AddResult()
        {
            results.Add(i != j ? $"{nums[i]}->{nums[j]}" : nums[i].ToString());
        }
    }
}