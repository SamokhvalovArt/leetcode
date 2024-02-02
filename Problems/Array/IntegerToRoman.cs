using System.Text;

namespace Samokhvalov.LeetCode.Problems.Array;

public class IntegerToRoman : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/integer-to-roman";

    public ProblemLevel Level => ProblemLevel.Medium;

    public void Run()
    {
        var num = 1;
        // 823 (800 + 20 + 3)
        // 800 -> [500, 100, 100, 100]
        // 20  -> [10, 10]
        // 3   -> [1, 1, 1]
        
        Console.WriteLine($"Num = {num}");
        Console.WriteLine($"Result = {IntToRomanImpl2(num)}");
        Console.WriteLine($"Result = {IntToRomanImpl3(num)}");
    }

    public bool Solved => true;
    
    private string IntToRoman(int num)
    {
        var config = new Dictionary<int, string>()
        {
            { 1, "I" },
            { 5, "V" },
            { 10, "X" },
            { 50, "L" },
            { 100, "C" },
            { 500, "D" },
            { 1000, "M" },
            { 5000, "_" }
        };
        
        var exceptions = new Dictionary<int, string>
        {
            {4, "IV"},
            {9, "IX"},
            {40, "XL"},
            {90, "XC"},
            {400, "CD"},
            {900, "CM"}
        };

        var builder = new StringBuilder();
        var splitInt = SplitInt(num);
        foreach (var t in splitInt)
        {
            if (t == 0)
            {
                continue;
            }

            builder.Append(IntToRomanLocal(t));
        }

        return builder.ToString();
        
        int[] SplitInt(int number)
        {
            var n100 = number - (number % 1000);
            var n10 = number - (n100 + (number % 100));
            var n1 = number - (n100 + n10 + (number % 10));
            var n = number - (n100 + n10 + n1);

            return new[] { n100, n10, n1, n };
        }

        string IntToRomanLocal(int number)
        {
            if (exceptions.TryGetValue(number, out var value) ||
                config.TryGetValue(number, out value))
            {
                return value;
            }
            
            
            
            return "X";
        }
    }

    private string IntToRomanImpl2(int num)
    {
        var config = new []
        {
            ( 1, "I" ),
            ( 4, "IV" ),
            ( 5, "V" ),
            ( 9, "IX" ),
            ( 10, "X" ),
            ( 40, "XL" ),
            ( 50, "L" ),
            ( 90, "XC" ),
            ( 100, "C" ),
            ( 400, "CD" ),
            ( 500, "D" ),
            ( 900, "CM" ),
            ( 1000, "M" )
        };

        var result = "";
        while (num > 0)
        {
            var configValue = config.Last(x => num >= x.Item1);
            num -= configValue.Item1;
            result = result + configValue.Item2;
        }

        return result;     
    }
    
    private string IntToRomanImpl3(int num)
    {
        var config = new []
        {
            ( 1, "I" ),
            ( 4, "IV" ),
            ( 5, "V" ),
            ( 9, "IX" ),
            ( 10, "X" ),
            ( 40, "XL" ),
            ( 50, "L" ),
            ( 90, "XC" ),
            ( 100, "C" ),
            ( 400, "CD" ),
            ( 500, "D" ),
            ( 900, "CM" ),
            ( 1000, "M" )
        };

        var result = "";
        while (num > 0)
        {
            for (var i = config.Length - 1; i >= 0 ; i--)
            {
                if (config[i].Item1 > num) { continue; }

                num -= config[i].Item1;
                result += config[i].Item2;    
                break;
            }
        }

        return result; 
    }
}