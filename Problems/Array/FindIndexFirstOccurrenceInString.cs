namespace Samokhvalov.LeetCode.Problems.Array;

/// <summary>
/// Input: haystack = "sadbutsad", needle = "sad"
/// Output: 0
/// Explanation: "sad" occurs at index 0 and 6.
/// The first occurrence is at index 0, so we return 0.
/// </summary>
public class FindIndexFirstOccurrenceInString : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/find-the-index-of-the-first-occurrence-in-a-string";
    
    public ProblemLevel Level => ProblemLevel.Easy;
    
    public void Run()
    {
        var haystack = "ddsaesadbutsad";
        var needle = "sad";

        Console.WriteLine($"Haystack = {haystack}, Needle = {needle}");
        Console.WriteLine($"StrStr = {StrStr(haystack, needle)}");
    }

    public bool Solved => true;
    
    private int StrStr(string haystack, string needle)
    {
        if (needle.Length > haystack.Length)
        {
            return -1;
        }

        return haystack.IndexOf(needle);
    }
}