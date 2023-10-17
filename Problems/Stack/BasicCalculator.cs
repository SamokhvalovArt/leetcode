namespace Samokhvalov.LeetCode.Problems.Stack;

/// <summary>
/// s consists of digits, '+', '-', '(', ')', and ' '.
/// </summary>
public class BasicCalculator : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/basic-calculator";

    public ProblemLevel Level => ProblemLevel.Hard;

    public void Run()
    {
        var s = "2+2";
        Console.WriteLine($"{s} = {Calculate(s)}");
    }

    public bool Solved => false;
    
    private  int Calculate(string s)
    {
        return -1;
    }
}