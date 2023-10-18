namespace Samokhvalov.LeetCode.Problems.TwoPointers;

public class ContainerWithMostWater : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/container-with-most-water";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        var height = new[] { 7, 8, 6, 2, 5, 4, 8, 3, 7 };

        Console.WriteLine($"Height => {string.Join(", ", height)}");
        Console.WriteLine($"MaxArea = {MaxArea(height)}");
    }

    public bool Solved => false;
    
    private static int MaxArea(int[] height)
    {
        int CalculateXAxis(int fromIndex, int toIndex)
        {
            var rightHeight = height[fromIndex];
            var leftHeight = height[toIndex];

            return (toIndex - fromIndex) * (rightHeight > leftHeight ? rightHeight : leftHeight); 
        }
        
        var backIndex = height.Length - 1;
        return CalculateXAxis(0, backIndex);
    }
}