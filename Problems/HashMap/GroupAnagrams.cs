namespace Samokhvalov.LeetCode.Problems.HashMap;

/// <summary>
/// Input: strs = ["eat","tea","tan","ate","nat","bat"]
/// Output: [["bat"],["nat","tan"],["ate","eat","tea"]]
/// </summary>
public class GroupAnagrams : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/group-anagrams/";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        var strs = new[] { "cab","tin","pew","duh","may","ill","buy","bar","max","doc" };
        
        Console.WriteLine($"Strings => {string.Join(", ", strs)}");
        var results = GroupAnagramsImpl(strs);
        Console.WriteLine($"Strings => {string.Join("|", results.Select(x => string.Join(", ", x)))}");
    }

    public bool Solved => true;
    
    private static IList<IList<string>> GroupAnagramsImpl(string[] strs)
    {
        string GetHashString(string str)
        {
            var key = new char[26];
            foreach (var letter in str)
            {
                key[letter - 'a']++;
            }
            return new string(key);
        }
        
        var dict = new Dictionary<string, List<string>>();
        
        foreach (var str in strs)
        {
            var array = str.ToCharArray();
            System.Array.Sort(array);

            var code = new string(array);

            if (dict.TryGetValue(code, out var list))
            {
                list.Add(str);
                dict[code] = list;
                continue;
            }

            dict[code] = new List<string> { str };
        }

        
        return dict.Select(x => x.Value.ToArray()).ToArray();
    }
}