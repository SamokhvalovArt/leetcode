using System.Text;

namespace Samokhvalov.LeetCode.Problems.Array;

public class ReverseWordsInString : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/reverse-words-in-a-string";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        var s = "a good   example";
        Console.WriteLine($"String -> '{s}'");
        Console.WriteLine($"ReversString -> '{ReverseWordsImpl2(s)}'");
    }

    public bool Solved => true;
    
    private string ReverseWords(string s)
    {
        var builder = new StringBuilder();
        var splitArray = s.Split(" ");
        for (var i = splitArray.Length - 1; i >= 0; i--)
        {
            var value = splitArray[i];
            if (value == "") 
            {
                continue;
            }

            builder.Append(value).Append(' ');
        }
        
        return builder.ToString().Trim(' ');
    }

    private string ReverseWordsImpl2(string s)
    {
        var arrayResult = new char[s.Length];
        for (var i = 0; i < arrayResult.Length; i++)
        {
            arrayResult[i] = ' ';
        }
        
        var index = s.Length - 1;
        var countOfChars = 0;
        for (var i = s.Length - 1; i >= 0; i--)
        {
            var value = s[i];

            if (value != ' ' && i != 0)
            {
                continue;
            }

            if (index != i && i != 0)
            {
                for (var j = i; j <= index; j++)
                {
                    if (s[j] == ' '){continue;}
                    arrayResult[countOfChars++] = s[j];
                }
                arrayResult[countOfChars++] = ' ';
                index = i;
            }

            if (i == 0)
            {
                if (index == i && value != ' ')
                {
                    arrayResult[countOfChars++] = value;
                }

                if (index != i && value != ' ')
                {
                    for (var j = i; j <= index; j++)
                    {
                        arrayResult[countOfChars++] = s[j];
                    }    
                }

                if (index != i && value == ' ')
                {
                    for (var j = i; j <= index; j++)
                    {
                        if (s[j] == ' '){continue;}
                        arrayResult[countOfChars++] = s[j];
                    }    
                }
            }

            index--;
        }

        return new string(arrayResult).TrimEnd();
    }
}