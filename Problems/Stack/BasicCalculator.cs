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
        // 1 + 10
        
        var s = "10 + 20"; // -1+-44+5 +2 -3+6+8
        Console.WriteLine($"{s} = {Calculate(s)}");
    }

    public bool Solved => false;
    
    private  int Calculate(string s)
    {
        var calculationStack = new Stack<string>();
        var str = s.Replace("(", string.Empty).Replace(")", string.Empty).Replace(" ", string.Empty);

        for (var i = 0; i < str.Length; i++)
        {
            switch (s[i])
            {
                case '+':
                    break;
                default:
                    break;
            }
        }
        
        var sign = 0;
        
        foreach (var c in s.Where(x => char.IsDigit(x) || x == '+' || x == '-'))
        {
            switch (c)
            {
                case '+':
                    sign = 1;
                    break;
                default:
                    sign = 0;
                    break;
            }
        }

        return Convert.ToInt32(calculationStack.Pop());
        
        int DoMath(string rightValue, string leftValue, string operation)
        {
            return operation switch
            {
                "+" => Convert.ToInt32(rightValue) + Convert.ToInt32(leftValue),
                "-" => Convert.ToInt32(rightValue) - Convert.ToInt32(leftValue),
                _ => throw new NotSupportedException()
            };
        }
    }
}