namespace Samokhvalov.LeetCode.Problems.Stack;

public class ValidParentheses : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/valid-parentheses";

    public ProblemLevel Level => ProblemLevel.Easy;
    
    public void Run()
    {
        var s = "{";
        Console.WriteLine(s);
        Console.WriteLine(IsValid(s));
    }

    public bool Solved => true;
    
    static bool IsValid(string s)
    {
        var settings = new Dictionary<char, char>
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' }
        };

        var openBasket = new Stack<char>();
        for (var i = 0; i < s.Length; i++)
        {
            if (settings.ContainsKey(s[i]))
            {
                openBasket.Push(s[i]);
                continue;
            }

            if (openBasket.Count == 0)
            {
                return false;
            }
            
            var tmpOpenChar = openBasket.Pop();
            if (s[i] != settings[tmpOpenChar])
            {
                return false;
            }
        }

        return openBasket.Count == 0;
    }
}