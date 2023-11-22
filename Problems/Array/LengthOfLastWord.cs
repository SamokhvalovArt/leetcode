namespace Samokhvalov.LeetCode.Problems.Array;

public class LengthOfLastWord : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/length-of-last-word";

    public ProblemLevel Level => ProblemLevel.Easy;

    public void Run()
    {
        var s = "Hello World    ";
        
        Console.WriteLine(s);
        Console.WriteLine($"LengthOfLastWord = {LengthOfLastWordImpl2(s)}");
    }

    public bool Solved => true;
    
    private int LengthOfLastWordImpl(string s)
    {
        const char space = ' ';  
        var counter = 0;
     
        s = s.TrimEnd(space);

        for (var i = 0; i < s.Length; i++)
        {
            if (s[i] == space)
            {
                counter = 0;
                continue;
            }

            counter++;
        }
        
        return counter;
    }
    
    private int LengthOfLastWordImpl2(string s)
    {
        const char space = ' ';  
        var counter = 0;
        
        for (var i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == space)
            {
                if (counter != 0)
                {
                    break;
                }
                continue;
            }

            counter++;
        }
        
        return counter;
    }
}