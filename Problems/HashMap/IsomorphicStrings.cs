namespace Samokhvalov.LeetCode.Problems.HashMap;

/// <summary>
/// Input: s = "paper", t = "tttle"
/// Output: true
///
/// Input: s = "foo", t = "bar"
/// Output: false
/// </summary>
public class IsomorphicStrings : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/isomorphic-strings";

    public ProblemLevel Level => ProblemLevel.Easy;
    
    public void Run()
    {
        var s = "paper";
        var t = "title";
        
        Console.WriteLine($"First string = {s}");
        Console.WriteLine($"Second string = {t}");
        Console.WriteLine($"Is isomorphic -> {IsIsomorphicImpl2(s, t)}");
    }

    public bool Solved => true;
    
    private static bool IsIsomorphic(string s, string t)
    {
        var dictS = new Dictionary<char, char>();
        var dictT = new Dictionary<char, char>();

        for (var i = 0; i < s.Length; i++)
        {
            var chS = s[i];
            var chT = t[i];
            
            dictS.TryAdd(chS, chT);
            dictT.TryAdd(chT, chS);

            if (dictS[chS] != chT || dictT[chT] != chS)
            {
                return false;
            }
        }
        
        return true;
    }
    
    private static bool IsIsomorphicImpl2(string s, string t)
    {
        var dict = new Dictionary<char, char>();

        for (var i = 0; i < s.Length; i++)
        {
            var chS = s[i];
            var chT = t[i];

            dict.TryAdd(chS, chT);
            dict.TryAdd(chT, chS);
            
            if (dict[chS] != chT || dict[chT] != chS)
            {
                return false;
            }
        }
        
        return true;
    }
}