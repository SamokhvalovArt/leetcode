namespace Samokhvalov.LeetCode.Problems.HashMap;

/// <summary>
/// Input: s = "anagram", t = "nagaram"
/// Output: true
/// </summary>
public class ValidAnagram : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/valid-anagram";

    public ProblemLevel Level => ProblemLevel.Easy;
    
    public void Run()
    {
        var s = "anagram";
        var t = "nagaramk";
        
        Console.WriteLine($"Is {s} and {t} anagram?");
        Console.WriteLine($"Answer => {IsAnagram(s, t)}");
    }

    private static bool IsAnagram(string s, string t) {

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
        
        if (s.Length != t.Length)
        {
            return false;
        }

        var dict1 = CreateAnagramDict(s);
        var dict2 = CreateAnagramDict(t);
        
        foreach (var keyValuePair in dict1)
        {
            if (!dict2.TryGetValue(keyValuePair.Key, out var value) || value != keyValuePair.Value)
            {
                return false;
            }
        }

        return true;
    }
    
    public bool Solved => true;
}