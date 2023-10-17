namespace Samokhvalov.LeetCode.Problems.Stack;

/// <summary>
/// s consists of digits, '+', '-', '(', ')', and ' '.
/// (1+(44+5+2)-3)+(6+8)
/// 2-1 + (2+4) 
/// </summary>
public class BasicCalculator : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/basic-calculator";

    public ProblemLevel Level => ProblemLevel.Hard;

    public void Run()
    {
        var s = "(-1+(-44+5+2)-3)+(6+8)"; // -1+-44+5 +2 -3+6+8
        Console.WriteLine($"{s} = {Calculate(s)}");
    }

    public bool Solved => false;
    
    private  int Calculate(string s)
    {
        var calculationStack = new Stack<string>();
        foreach (var c in s.Where(x => char.IsDigit(x) || x == '+' || x == '-'))
        {
        }

        return -1;
        
        int Calculate(int rightValue, int leftValue, string operation)
        {
            return operation switch
            {
                "+" => rightValue + leftValue,
                "-" => rightValue - leftValue,
                _ => throw new NotSupportedException()
            };
        }
    }
}