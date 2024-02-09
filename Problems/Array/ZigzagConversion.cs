namespace Samokhvalov.LeetCode.Problems.Array;

public class ZigzagConversion : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/zigzag-conversion";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        var s = "AB";
        var numRows = 1;
        
        Console.WriteLine($"S = {s}, numRows = {numRows}");
        Console.WriteLine($"Result = {Convert(s, numRows)}");
    }

    public bool Solved => true;
    
    private string Convert(string s, int numRows)
    {
        if (s.Length <= numRows || numRows == 1)
        {
            return s;
        }

        var list = new List<char>();
        var stepSize = 2 * numRows - 2;

        for (var i = 0; i < numRows; i++)
        {
            var x = i != 0 && i != numRows - 1
                ? i * 2
                : 0;

            for (var j = i; j < s.Length; j += stepSize)
            {
                list.Add(s[j]);
                if (x != 0)
                {
                    var nextIndex = j + (stepSize - x);
                    if (nextIndex < s.Length)
                    {
                        list.Add(s[j + (stepSize - x)]);    
                    }
                }
            }
        }
        
        return new string(list.ToArray());
    }
}