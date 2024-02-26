namespace Samokhvalov.LeetCode.Problems.Intervals;

public class InsertInterval : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/insert-interval/description";

    public ProblemLevel Level => ProblemLevel.Medium;

    public void Run()
    {
        var intervals = new[]
        {
            new[] { 1, 3 },
            new[] { 6, 9 },
        };

        var newInterval = new[] { 2, 5 };

        Console.WriteLine($"Intervals => {intervals.ToStringCollectionMatrix()} ; Insert => {newInterval.ToStringCollection()}");
        Console.WriteLine($"Intervals => {InsertImpl2(intervals, newInterval).ToStringCollectionMatrix()}");
    }

    public bool Solved => false;
    
    // private int[][] Insert(int[][] intervals, int[] newInterval)
    // {
    //     if (intervals.Length == 0)
    //     {
    //         return new[] { newInterval };
    //     }
    //
    //     var listResults = new List<int[]>();
    //
    //     var i = 0;
    //     while (i < intervals.Length)
    //     {
    //         if (intervals[i][1] < newInterval[0])
    //         {
    //             listResults.Add(intervals[i]);
    //             i += 1;
    //             continue;
    //         }
    //
    //         // Define from interval
    //         int[2] fromInterval = null;
    //         for (int j = i; j < intervals.Length; j++)
    //         {
    //             if (intervals[j][0] > newInterval[0])
    //             {
    //                 fromInterval = new();
    //                 fromInterval[0] = intervals[j][0];
    //                 fromInterval[1] = intervals[j][1];
    //                 break;
    //             }    
    //         }
    //         
    //         // Define to interval
    //         int[2] toInterval = null;
    //         for (int j = i; j < intervals.Length; j++)
    //         {
    //             if (intervals[j][0] < newInterval[1])
    //             {
    //                 toInterval = new();
    //                 toInterval[0] = intervals[j][0];
    //                 toInterval[1] = intervals[j][1];
    //                 break;
    //             }    
    //         }
    //
    //
    //
    //         for (int j = i; j < intervals.Length; j++)
    //         {
    //             if (newInterval[1] > tmpInterval[1])
    //             {
    //                 listResults.Add(new []
    //                 {
    //                     Math.Min(newInterval[0], tmpInterval[0]), 
    //                     Math.Max(newInterval[0], tmpInterval[0]),
    //                 });
    //                 listResults.Add(new[] { newInterval[1], tmpInterval[1] });
    //                 i = j + 1;
    //                 break;
    //             }         
    //             
    //             
    //         }
    //     }
    //     
    //     return listResults.ToArray();
    // }

    private int[][] InsertImpl2(int[][] intervals, int[] newInterval)
    {
        if (intervals.Length == 0)
        {
            return new[] { newInterval };
        }

        var listResults = new List<int[]>();
        for (var i = 0; i < intervals.Length; i++)
        {
            if (intervals[i][0] > newInterval[1])
            {
                listResults.Add(new []
                {
                    newInterval[0],
                    newInterval[1],
                });
                newInterval[0] = intervals[i][0];
                newInterval[1] = intervals[i][1];
            } else if (intervals[i][1] < newInterval[0])
            {
                listResults.Add(new []
                {
                    intervals[i][0],
                    intervals[i][1],
                });
            }
            else
            {
                newInterval[0] = Math.Min(newInterval[0], intervals[i][0]);
                newInterval[1] = Math.Max(newInterval[1], intervals[i][1]);                
            }
        }
        
        listResults.Add(newInterval);

        return listResults.ToArray();
    }
}