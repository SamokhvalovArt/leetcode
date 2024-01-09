using System.Runtime.CompilerServices;

namespace Samokhvalov.LeetCode.Problems.Array;

public sealed class LongestCommonPrefix : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/longest-common-prefix";

    public ProblemLevel Level => ProblemLevel.Easy;

    public void Run()
    {
        var strs = new[] { "flower","flow","floght" };

        Console.WriteLine(strs.ToStringCollection());
        Console.WriteLine($"LongestCommonPrefix - {LongestCommonPrefixImpl2(strs)}");        
    }
    
    private string LongestCommonPrefixImpl(string[] strs)
    {
        var result = string.Empty;
        var comparingStr = strs[0];

        if (strs.Length == 1) {
            return comparingStr;
        }
        
        for (var i = 0; i < comparingStr.Length; i++)
        {
            for(var j = i; j < comparingStr.Length - i; j++)
            {
                var str = comparingStr.Substring(i, j);
                if (AllHas(str) && str.Length > result.Length)
                {
                    result = str;
                }
            }
        }
        
        return result;

        bool AllHas(string str)
        {
            for (var indexStr = 1; indexStr < strs.Length; indexStr++)
            {
                var tmp = strs[indexStr];
                if (tmp.Length < str.Length || !tmp.Contains(str))
                {
                    return false;
                }        
            }

            return true;
        }
    }
    
    private string LongestCommonPrefixImpl2(string[] strs)
    {
        var result = string.Empty;
        var comparingStr = strs[0];

        if (strs.Length == 1) {
            return comparingStr;
        }
        
        for(var j = 0; j <= comparingStr.Length; j++)
        {
            var str = comparingStr.Substring(0, j);
            if (AllHas(str) && str.Length > result.Length)
            {
                result = str;
            }
        }
        
        return result;

        bool AllHas(string str)
        {
            for (var indexStr = 1; indexStr < strs.Length; indexStr++)
            {
                var tmp = strs[indexStr];
                if (tmp.Length < str.Length || tmp.IndexOf(str) != 0)
                {
                    return false;
                }        
            }

            return true;
        }
    }

    public bool Solved => true;
}