namespace Samokhvalov.LeetCode.Problems.Array;

public class HIndex : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/h-index/";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        var citations = new[] { 3,0,6,1,5 };
        
        Console.WriteLine($"citations is {string.Join(", ", citations)}");
        Console.WriteLine($"H-Index is {HIndexImpl(citations)}");
    }
    
    private int HIndexImpl(int[] citations)
    {
        var ordered = citations.OrderByDescending(x => x).ToArray();
        for (var i = 0; i < citations.Length; i++)
        {
            if (i + 1 > ordered[i]) return i;
        }
        return citations.Length + 1;
    }

    public bool Solved => true;
}