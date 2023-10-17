namespace Samokhvalov.LeetCode.Problems.Array;

/// <summary>
/// -------- Example 1
/// Input: gas = [1,2,3,4,5], cost = [3,4,5,1,2]
/// Output: 3
/// -------- Example 2
/// Input: gas = [2,3,4], cost = [3,4,3]
/// Output: -1
/// </summary>
public class GasStation : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/gas-station";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        var gas = new[] { 1, 2, 3, 4, 5 };
        var cost = new[] { 3, 4, 5, 1, 2 };
        
        Console.WriteLine($"Gas => {string.Join(", ", gas)}");
        Console.WriteLine($"Cost => {string.Join(", ", cost)}");
        Console.WriteLine($"Results = {CanCompleteCircuitNew(gas, cost)}");
    }

    private static int CanCompleteCircuitNew(int[] gas, int[] cost)
    {
        if (gas.Sum() < cost.Sum()) return -1;

        var currentTankSize = 0;
        var index = 0;
        for (var i = 0; i < gas.Length; i++)
        {
            currentTankSize += gas[i] - cost[i];
            if (currentTankSize < 0)
            {
                currentTankSize = 0;
                index = i + 1;
            }
        }
    
        return index;
    }

    private static int CanCompleteCircuit(int[] gas, int[] cost)
    {
        for (var index = 0; index < gas.Length; index++)
        {
            var currentTankSize = 0;
            var i = index;
            var f = true;
            do
            {
                currentTankSize = currentTankSize + gas[i] - cost[i];
                i = i + 1 == gas.Length ? 0 : i + 1;
                
                if (i == index && currentTankSize >= 0)
                {
                    continue;
                }

                if (currentTankSize <= 0)
                {
                    f = false;
                    break;
                }
            } while (i != index);

            if (i == index && f)
            {
                return index;
            }
        }
        
        return -1;
    }

    public bool Solved => true;
}