namespace Samokhvalov.LeetCode.Problems.HashMap;

public class WordPattern : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/word-pattern/";

    public ProblemLevel Level => ProblemLevel.Easy;
    
    public void Run()
    {
        var patter = "abb";
        var s = "dog cat dog";
        
        Console.WriteLine($"Pattern = {patter}, String = {s}");
        Console.WriteLine($"Result => {WordPatternIml2(patter, s)}");
    }

    public bool Solved => true;
    
    private bool WordPatternIml(string pattern, string s)
    {
        var result = true;
        var splitStringArray = s.Split(" ");
        if (pattern.Length != splitStringArray.Length)
        {
            return false;
        }

        var dictString = new Dictionary<string, char>();
        var dictPattern = new Dictionary<char, string>();

        for (var i = 0; i < pattern.Length; i++)
        {
            var str = splitStringArray[i];
            var patternChar = pattern[i];
            var containsPatternChar = dictPattern.TryGetValue(patternChar, out var tmpSrt);
            var containsString = dictString.TryGetValue(str, out var patternCharTmp);

            if (containsPatternChar != containsString)
            {
                return false;
            }

            if (containsPatternChar && containsString && 
                (tmpSrt != str || patternCharTmp != patternChar))
            {
                return false;
            }

            dictPattern[patternChar] = str;
            dictString[str] = patternChar;
        }
        
        return result;
    }

    private bool WordPatternIml2(string pattern, string s)
    {
        var splitStr = s.Split(" ");
        var dict = new Dictionary<string, char>();
        
        if (splitStr.Length != pattern.Length)
        {
            return false;
        }

        for (var i = 0; i < pattern.Length; i++)
        {
            var splitStrTmp = splitStr[i];
            var patternCharTmp = pattern[i];
            var containsPattern = dict.TryGetValue(splitStrTmp, out var charTmp);

            if (containsPattern && patternCharTmp != charTmp)
            {
                return false;
            }

            if (!containsPattern)
            {
                if (dict.ContainsValue(patternCharTmp))
                {
                    return false;
                }

                dict[splitStrTmp] = patternCharTmp;
            }
        }

        return true;
    }
}