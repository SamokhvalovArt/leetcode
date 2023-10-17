namespace Samokhvalov.LeetCode.Problems.Array;

/// <summary>
/// Input: nums = [0,0,1,1,1,2,2,3,3,4]
/// Output: 5, nums = [0,1,2,3,4,_,_,_,_,_]
/// </summary>
public class RemoveDuplicatesFromSortedArray : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/remove-duplicates-from-sorted-array";

    public ProblemLevel Level => ProblemLevel.Easy;
    
    public void Run()
    {
        var nums = new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
        
        Console.WriteLine($"Before remove -> {string.Join(", ", nums)}");
        
        var result = RemoveDuplicates(nums);
        
        Console.WriteLine($"result = {result}");
        Console.WriteLine($"After remove -> {string.Join(", ", nums)}");
    }
    
    public int RemoveDuplicates(int[] nums)
    {
        var index = 0;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[index] == nums[i])
            {
                continue;
            }

            index++;
            nums[index] = nums[i];
        }

        return index + 1;
    }

    public bool Solved => true;
}