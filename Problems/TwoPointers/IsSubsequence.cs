namespace Samokhvalov.LeetCode.Problems.TwoPointers;

public class IsSubsequence : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/is-subsequence";

    public ProblemLevel Level => ProblemLevel.Easy;
    
    public void Run()
    {
        var s = "abc";
        var t = "ahbgdc";
        Console.WriteLine($"String_1 = {s} ; String_2 = {t}");
        Console.WriteLine($"Is subsequence => {IsSubsequenceImpl(s, t)}");
    }

    public bool Solved => true;
    
    private bool IsSubsequenceImpl(string s, string t)
    {
        if (s == "")
        {
            return true;
        }

        var j = 0;
        for (var i = 0; i < t.Length && j < s.Length; i++)
        {
            if (t[i] == s[j])
            {
                j++;
            }
        }

        return j == s.Length;
    }
}