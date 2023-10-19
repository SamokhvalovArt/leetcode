namespace Samokhvalov.LeetCode.Problems.TwoPointers;

public class ContainerWithMostWater : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/container-with-most-water";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        var height = new[] { 1, 1 };

        Console.WriteLine($"Height => {string.Join(", ", height)}");
        Console.WriteLine($"MaxArea = {MaxArea(height)}");
    }

    public bool Solved => true;
    
    private static int MaxArea(int[] height)
    {
        var result = 0;
        var backIndex = height.Length - 1;
        for (var i = 0; i < backIndex;)
        {
            var rightHeight = height[backIndex];
            var leftHeight = height[i];
            
            var tmpValue = (backIndex - i) * Math.Min(rightHeight, leftHeight);
            result = tmpValue > result ? tmpValue : result;

            if (rightHeight < leftHeight)
            {
                backIndex--;
                continue;
            }

            i++;
        }

        return result;
    }
}