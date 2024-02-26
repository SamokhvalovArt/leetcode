namespace Samokhvalov.LeetCode.Problems.Intervals;

public class MergeIntervals : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/merge-intervals/description";

    public ProblemLevel Level => ProblemLevel.Medium;

    public void Run()
    {
        var intervals = new[]
        {
            new[] { 4, 5 },
            new[] { 6, 7 },
            new[] { 8, 9 },
            new[] { 1, 10 }
        };
        
        Console.WriteLine($"Intervals = {intervals.ToStringCollectionMatrix()}");
        Console.WriteLine($"Results = {Merge(intervals).ToStringCollectionMatrix()}");
    }

    public bool Solved => true;
    
    private int[][] Merge(int[][] intervals)
    {
        var results = new List<int[]>();

        System.Array.Sort(intervals, (x, y) => x[0] - y[0]);

        if (intervals.Length == 1)
        {
            results.Add(new []{intervals[0][0], intervals[0][1]});
            return results.ToArray();
        }
        
        var tmpInterval = new int[2];
        tmpInterval[0] = intervals[0][0];
        tmpInterval[1] = intervals[0][1];

        for (var j = 1; j < intervals.Length; j++)
        {
            if (tmpInterval[1] >= intervals[j][0])
            {
                if (tmpInterval[0] >= intervals[j][0])
                {
                    tmpInterval[0] = intervals[j][0];
                }
                
                if (tmpInterval[1] <= intervals[j][1])
                {
                    tmpInterval[1] = intervals[j][1];
                }
                
                continue;
            }
            
            results.Add(new []{tmpInterval[0], tmpInterval[1]});
            tmpInterval[0] = intervals[j][0];
            tmpInterval[1] = intervals[j][1];
        }
        results.Add(tmpInterval);

        return results.ToArray();
    }
}