namespace Samokhvalov.LeetCode.Problems.HashMap;

/// <summary>
// Input: n = 19
// Output: true
// Explanation:
// 12 + 92 = 82
// 82 + 22 = 68
// 62 + 82 = 100
// 12 + 02 + 02 = 1
/// </summary>
public class HappyNumber : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/happy-number";

    public ProblemLevel Level => ProblemLevel.Easy;
    
    public void Run()
    {
        var n = 19;
        Console.WriteLine($"N => {n}");
        Console.WriteLine($"Is happy number => {IsHappy(n)}");
    }

    public bool Solved => true;
    
    private bool IsHappy(int n)
    {
        var hashMap = new HashSet<int>();

        while (true)
        {
            var sumOfNumber = SumOfNumber(n);

            if (sumOfNumber == 1)
            {
                return true;
            }

            if (hashMap.Contains(sumOfNumber))
            {
                return false;
            }
            
            n = sumOfNumber;
            hashMap.Add(sumOfNumber);
        }

        int SumOfNumber(int n)
        {
            int sum = 0;
            while (n != 0)
            {
                int digit = n % 10;
                sum += digit * digit;
                n /= 10;
            }
            return sum;
        }
    }
}