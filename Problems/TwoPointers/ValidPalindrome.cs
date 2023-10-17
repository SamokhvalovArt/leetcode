namespace Samokhvalov.LeetCode.Problems.TwoPointers;

public class ValidPalindrome : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/valid-palindrome";

    public ProblemLevel Level => ProblemLevel.Easy;
    
    public void Run()
    {
        var s = "A man, a plan, a canal: Panama";
        Console.WriteLine($"Testing phrase -> {s}");
        Console.WriteLine($"Is palidrome -> {IsPalindrome2(s)}");
    }

    public bool Solved => true;

    private bool IsPalindrome2(string s)
    {
        var j = s.Length - 1;
        for (var i = 0; i < s.Length && j > 0; )
        {
            if (!char.IsLetterOrDigit(s[i]))
            {
                i++;
                continue;
            }

            if (!char.IsLetterOrDigit(s[j]))
            {
                j--;
                continue;
            }
            
            if ( char.ToLower(s[i]) != char.ToLower(s[j]) )
            {
                return false;
            }

            i++;
            j--;
        }

        return true;
    }
    
    private bool IsPalindrome(string s)
    {
        (int from, int to) edges = (97, 122);
        (int from, int to) upperEdges = (65, 90);

        var j = s.Length - 1;
        for (var i = 0; i < s.Length && j > 0;)
        {
            int sI = s[i];
            int sJ = s[j];
            
            // to lower case
            sI = sI >= upperEdges.from && sI <= upperEdges.to
                ? edges.from + (sI - upperEdges.from)
                : sI;
            sJ = sJ >= upperEdges.from && sJ <= upperEdges.to
                ? edges.from + (sJ - upperEdges.from)
                : sJ;
            
            // for sI skip
            if (sI < edges.from || sI > edges.to)
            {
                i++;
                continue;
            }
            
            // for sJ skip
            if (sJ < edges.from || sJ > edges.to)
            {
                j--;
                continue;
            }

            if (sI != sJ)
            {
                return false;
            }
            
            i++;
            j--;
        }

        return true;
    }
}