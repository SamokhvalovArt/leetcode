namespace Samokhvalov.LeetCode.Problems.Stack;

/// <summary>
/// Input: tokens = ["4","13","5","/","+"]
/// Output: 6
/// Explanation: (4 + (13 / 5)) = 6
/// </summary>
public class EvaluateReversePolishNotation : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/evaluate-reverse-polish-notation";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        var tokens = new[] { "10","6","9","3","+","-11","*","/","*","17","+","5","+" };
        
        Console.WriteLine($"Tokens -> {string.Join(" ",tokens)}");
        Console.WriteLine($"Calculation result -> {EvalRPN(tokens)}");
    }

    public bool Solved => true;
    
    private static int EvalRPN(string[] tokens)
    {
        var supportedOperations = new[] { "*", "+", "-", "/" };
        var values = new Stack<int>();
        
        foreach (var token in tokens)
        {
            if (!supportedOperations.Contains(token))
            {
                values.Push(Convert.ToInt32(token));
                continue;
            }

            var leftValue = values.Pop();
            var rightValue = values.Pop();
            var newValue = Calculate(rightValue, leftValue, token);
            
            values.Push(newValue);
        }
        
        return values.Pop();

        int Calculate(int rightValue, int leftValue, string operation)
        {
            return operation switch
            {
                "+" => rightValue + leftValue,
                "-" => rightValue - leftValue,
                "*" => rightValue * leftValue,
                "/" => rightValue / leftValue,
                _ => throw new NotSupportedException()
            };
        }
    }
}