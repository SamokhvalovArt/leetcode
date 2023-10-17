using System.Text;

namespace Samokhvalov.LeetCode.Problems.Stack;

/// <summary>
/// Input: path = "/home//foo/"
/// Output: "/home/foo"
///
/// Input: path = "/../"
/// Output: "/"
///
/// Input: path = "test/../test01"
/// </summary>
public class SimplifyPath : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/simplify-path";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        var path = "/home/";
        
        Console.WriteLine($"Path -> {path}");
        Console.WriteLine($"Simply path -> {SimplifyPathImpl(path)}");
    }

    public bool Solved => true;
    
    private string SimplifyPathImpl(string path)
    {
        var folders = new Stack<string>();
        var pathTmp = path.Replace("//", "/").TrimEnd('/');

        foreach (var item in pathTmp.Split("/"))
        {
            switch (item)
            {
                case "":
                case ".":
                    continue;
                case "..":
                {
                    if (folders.Count != 0)
                    {
                        folders.Pop();
                    }
                    continue;
                }
                default:
                    folders.Push(item);
                    break;
            }
        }

        if (folders.Count == 0)
        {
            return "/";
        }
        
        var builder = new StringBuilder();
        while (folders.Count > 0)
        {
            builder.Insert(0, folders.Pop()).Insert(0, "/");
        }

        return builder.ToString();
    }
}