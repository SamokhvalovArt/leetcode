namespace Samokhvalov.LeetCode.Problems.Array;

/// <summary>
/// Input: nums = [1,2,3,4,5,6,7], k = 3
/// Output: [5,6,7,1,2,3,4]
/// </summary>
public class RotateArray : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/rotate-array";

    public ProblemLevel Level => ProblemLevel.Easy;
    
    public void Run()
    {
        var nums = new []{ 1, 2, 3 };
        var k = 4;
        Console.WriteLine($"Before remove -> {string.Join(", ", nums)}");
        RotateImpl1(nums, k);
        Console.WriteLine($"After remove -> {string.Join(", ", nums)}");
    }

    static void RotateImpl1(int[] nums, int k)
    {
        if (nums.Length == 1)
        {
            return;
        }

        if (nums.Length < k)
        {
            k -= (k / nums.Length)*nums.Length;
        }
        
        var nums2 = new int[nums.Length];
        System.Array.Copy(nums, nums2, nums.Length);
        System.Array.Copy(nums2, nums2.Length - k, nums, 0, k);
        System.Array.Copy(nums2, 0, nums, k, nums.Length - k);
    }
    
    public bool Solved => true;
}