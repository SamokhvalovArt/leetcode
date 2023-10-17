namespace Samokhvalov.LeetCode.Problems.Other;

/// <summary>
/// Input: s = "cbaebabacd", p = "abc"
/// Output: [0,6]
/// Explanation:
/// The substring with start index = 0 is "cba", which is an anagram of "abc".
/// The substring with start index = 6 is "bac", which is an anagram of "abc".
/// </summary>
public class FindAllAnagramsInString : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/find-all-anagrams-in-a-string";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        var s = "cbaebabacd";
        var p = "abc";
        
        Console.WriteLine($"{s} <-> {p}");
        Console.WriteLine(string.Join(", ", FindAnagramsImpl2(s, p)));
    }
    
    private IList<int> FindAnagrams(string s, string p)
    {
        Dictionary<char, int> CreateAnagramDict(string str)
        {
            var dict = new Dictionary<char, int>();
            foreach (var c in str)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c] += 1;
                    continue;
                }

                dict[c] = 1;
            }

            return dict;
        }

        if (p.Length > s.Length)
        {
            return new List<int>();
        }

        var resultList = new List<int>();
        var patternLength = p.Length;
        var pattern = CreateAnagramDict(p);
        for (var i = 0; i <= s.Length - patternLength; i++)
        {
            var checkValue = CreateAnagramDict(s.Substring(i, patternLength));
            var isAnagram = true;
            foreach (var keyValuePair in pattern)
            {
                if (checkValue.TryGetValue(keyValuePair.Key, out var value) && value == keyValuePair.Value)
                {
                    continue;
                }
                isAnagram = false;
                break;
            }

            if (isAnagram)
            {
                resultList.Add(i);
            }
        }

        return resultList;
    }

    private IList<int> FindAnagramsImpl2(string s, string p)
    {
        if (p.Length > s.Length)
        {
            return new List<int>();
        }

        var resultList = new List<int>();
        var patternLength = p.Length;
        var patter = GetHash(p);
        for (var i = 0; i <= s.Length - patternLength; i++)
        {
            var checkValue = GetHash(s.Substring(i, patternLength));
            if (IsSame(patter, checkValue))
            {
                resultList.Add(i);
            }
        }

        return resultList;
        
        char[] GetHash(string str)
        {
            var key = new char[26];
            foreach (var letter in str)
            {
                key[letter - 'a']++;
            }
            return key;
        }

        bool IsSame(char[] a, char[] b)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
    
    
    public bool Solved => true;
}