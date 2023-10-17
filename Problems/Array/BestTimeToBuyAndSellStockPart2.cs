namespace Samokhvalov.LeetCode.Problems.Array;

/// <summary>
/// Input: prices = [7,1,5,4,6,4]
/// Output: 7
/// Explanation: Buy on day 2 (price = 1) and sell on day 3 (price = 5), profit = 5-1 = 4.
/// Then buy on day 4 (price = 3) and sell on day 5 (price = 6), profit = 6-3 = 3.
/// Total profit is 4 + 3 = 7.
/// </summary>
public class BestTimeToBuyAndSellStockPart2 : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        var prices = new[] {4,3,3,2};
        
        Console.WriteLine($"Prices is {string.Join(", ", prices)}");
        Console.WriteLine($"Max total-profit is {MaxProfit(prices)}");
    }

    static int MaxProfit(int[] prices)
    {
        var profit = 0;
        var totalProfit = 0;
        var cursor = 0;

        for (var i = 1; i < prices.Length; i++)
        {
            if (prices[i] <= prices[i-1])
            {
                totalProfit += profit;
                profit = 0;
                cursor = i;
                continue;
            }

            var tmpProfit = prices[i] - prices[cursor];
            if (tmpProfit > profit)
            {
                profit = tmpProfit;
            }

            if (i == prices.Length - 1)
            {
                totalProfit += profit;
            }
        }
        
        return totalProfit;
    }

    public bool Solved => true;
}