namespace Samokhvalov.LeetCode.Problems.SlidingWindow;

public class LongestSubstringWithoutRepeatingCharacters : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/longest-substring-without-repeating-characters";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        var s = "bbtablud";
        Console.WriteLine($"S = {s}");
        Console.WriteLine($"Result = {LengthOfLongestSubstringImpl3(s)}");
    }

    private int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0)
        {
            return 0;
        }
        
        var result = 1;
        var leftIndex = 0;
        var rightIndex = 1;
        
        while (leftIndex + result < s.Length)
        {
            var localResult = 1;
            while (rightIndex < s.Length)
            {
                var h = s.Substring(leftIndex, localResult).IndexOf(s[rightIndex]);

                if (h != -1)
                {
                    rightIndex += 1;
                    leftIndex += 1 + (h+1);
                    break;
                }

                localResult++;
                rightIndex += 1;
            }
            
            if (localResult > result)
            {
                result = localResult;
            }
        }

        return result;
    }

    private int LengthOfLongestSubstringImpl2(string s)
    {
        if (s.Length == 0)
        {
            return 0;
        }
        if (s.Length == 1)
        {
            return 1;
        }
        
        var windowSize = 1;
        var leftIndex = 0;

        while (leftIndex + windowSize <= s.Length)
        {
            var subStr = s.Substring(leftIndex, windowSize);

            if (subStr.Distinct().Count() != subStr.Length)
            {
                leftIndex += 1;
                continue;
            }

            if (leftIndex + windowSize == s.Length)
            {
                break;
            }

            if (subStr.Contains(s[leftIndex + windowSize]))
            {
                leftIndex += 1;
                continue;
            }

            windowSize += 1;
        }
        
        
        return windowSize;
    }


    private int LengthOfLongestSubstringImpl3(string s)
    {
        if (s.Length < 2)
        {
            return s.Length;
        }

        var leftIndex = 0;
        var rightIndex = 1;
        var result = 0;
        
        while (rightIndex < s.Length)
        {
            for (var j = leftIndex; j < rightIndex; j++)
            {
                if (s[rightIndex] == s[j])
                {
                    leftIndex = j + 1;
                }
            }
            
            result = Math.Max(rightIndex - leftIndex + 1, result);
            rightIndex += 1;
        }

        return result;
    }
    
    
    public bool Solved => true;
}