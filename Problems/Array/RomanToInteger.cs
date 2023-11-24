namespace Samokhvalov.LeetCode.Problems.Array;

/// <summary>
/// Input: s = "MCMXCIV"
/// Output: 1994
/// Explanation: M = 1000, CM = 900, XC = 90 and IV = 4.
/// </summary>
public class RomanToInteger : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/roman-to-integer";

    public ProblemLevel Level => ProblemLevel.Medium;

    public void Run()
    {
        var s = "IM";
        Console.WriteLine($"{s} = {RomanToIntImpl3(s)}");
    }

    public bool Solved => true;
    
    private int RomanToInt(string s)
    {
        var resultAmount = 0;

        for (var i = 0; i < s.Length; i++)
        {
            if (i == s.Length - 1)
            {
                resultAmount += GetIntByRoman(s[i]);
                continue;
            }
            
            var complexValue = GetIntByComplexRoman(s[i], s[i + 1]);
            if (complexValue != -1)
            {
                resultAmount += complexValue;
                i++;
                continue;
            }

            resultAmount += GetIntByRoman(s[i]);
        }
        
        return resultAmount;

        int GetIntByRoman(char roman)
        {
            return roman switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => 0
            };
        }

        int GetIntByComplexRoman(char romanFirst, char romanSecond)
        {
            var complexRoman = new string(new[] { romanFirst, romanSecond });
            
            return complexRoman switch
            {
                "IV" => 4,
                "IX" => 9,
                "XL" => 40,
                "XC" => 90,
                "CD" => 400,
                "CM" => 900,
                _ => -1
            };
        }
    }

    private int RomanToIntImpl2(string s)
    {
        var result = 0;
        
        for (var i = 0; i < s.Length; i++)
        {
            if (i == s.Length - 1)
            {
                result += GetIntByRoman(s[i]);
                continue;
            }

            var valueRoman = s[i];
            var nextValueRoman = s[i + 1];
            if (CanBeComplex(valueRoman, nextValueRoman))
            {
                result += GetIntByRoman(nextValueRoman) - GetIntByRoman(valueRoman);
                i++;
                continue;
            }

            result += GetIntByRoman(valueRoman);
        }
        
        return result;
        
        int GetIntByRoman(char roman)
        {
            return roman switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => 0
            };
        }

        bool CanBeComplex(char romanFirst, char romanNext)
        {
            return (romanFirst == 'I' && romanNext is 'V' or 'X') ||
                   (romanFirst == 'X' && romanNext is 'L' or 'C') ||
                   (romanFirst == 'C' && romanNext is 'D' or 'M');
        }
    }
    
    public int RomanToIntImpl3(string s) {
        int res = 0;
        int prev=0;
        Dictionary<char, int> romanNumerals =
            new Dictionary<char, int>
            {
                {'M', 1000},
                {'D', 500},
                {'C', 100},
                {'L' , 50},
                {'X' , 10},
                {'V' , 5},
                {'I' , 1}
            };
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (prev <= romanNumerals[s[i]])
            {
                res += romanNumerals[s[i]];
            }
            else if (prev > romanNumerals[s[i]])
            {
                res -= romanNumerals[s[i]];
            }
            prev = romanNumerals[s[i]];
        }
        return res;
    }
}