namespace Samokhvalov.LeetCode.Problems.Array;

/// <summary>
/// Input: prices = [2,3,4,7,1,5,3,4]
/// Output: 5
/// Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
/// Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.
/// </summary>
public class BestTimeToBuyAndSellStock : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/best-time-to-buy-and-sell-stock";

    public ProblemLevel Level => ProblemLevel.Easy;
    
    public void Run()
    {
        var prices = new[] { 7, 9 };
        
        Console.WriteLine($"Prices is {string.Join(", ", prices)}");
        Console.WriteLine($"Max profit is {MaxProfit(prices)}");
    }

    static int MaxProfit(int[] prices)
    {
        var maxProfit = 0;
        var cursor = 0;
        
        for (var i = 1; i < prices.Length; i++)
        {
            if (prices[i] < prices[cursor])
            {
                cursor = i;
                continue;
            }
            
            var tmpProfit = prices[i] - prices[cursor];
            if (tmpProfit > maxProfit)
            {
                maxProfit = tmpProfit;
            }
        }
        
        return maxProfit;
    }
    
    public bool Solved => true;
}