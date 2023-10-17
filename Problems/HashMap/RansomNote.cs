namespace Samokhvalov.LeetCode.Problems.HashMap;

/// <summary>
/// Input: ransomNote = "aa", magazine = "aab"
/// Output: true
/// </summary>
public class RansomNote : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/ransom-note";

    public ProblemLevel Level => ProblemLevel.Easy;
    
    public void Run()
    {
        var ransomNote = "ab";
        var magazine = "ba";

        Console.WriteLine($"|{ransomNote}| can constructed by using |{magazine}| = {CanConstruct(ransomNote, magazine)}");
    }

    public bool Solved => true;
    
    private static bool CanConstruct(string ransomNote, string magazine)
    {
        var dictionary = new Dictionary<char, int>();
        
        // fill the dict
        foreach (var c in ransomNote)
        {
            if (dictionary.TryGetValue(c, out var count))
            {
                count++;
                dictionary[c] = count;
            }
            else
            {
                dictionary.Add(c, 1);
            }
        }
        
        // check magazine
        foreach (var c in magazine)
        {
            if (dictionary.Count == 0)
            {
                return true;
            }

            if (!dictionary.TryGetValue(c, out var count))
            {
                continue;
            }
            
            count--;
            if (count == 0)
            {
                dictionary.Remove(c);
            }
            else
            {
                dictionary[c] = count;
            }
        }
        
        return dictionary.Count == 0;
    }
}