namespace Samokhvalov.LeetCode.Problems.Array;

/// <summary>
/// Input: nums = [0,0,0,1,2,2,2,2,2,3,3]
/// Output: 7, nums = [0,0,1,1,2,3,3,_,_]
/// Explanation: Your function should return k = 7
/// </summary>
public class RemoveDuplicatesFromSortedArrayPart2 : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/remove-duplicates-from-sorted-array-ii/";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        var nums = new[] { 0, 1, 1, 1, 2, 3 };
        
        Console.WriteLine($"Before remove -> {string.Join(", ", nums)}");
        var result = RemoveDuplicates(nums);
        Console.WriteLine($"result = {result}");
        Console.WriteLine($"After remove -> {string.Join(", ", nums)}");
    }

    public bool Solved => true;

    public int RemoveDuplicates_notMy_1(int[] nums) 
    {
        int i = 0;
        for (int j = 0; j < nums.Length; j++)
        {
            if (i < 2 || nums[j] != nums[i - 2])
            {
                nums[i++] = nums[j];
            }
        }

        return i;
    }
    
    public int RemoveDuplicates_notMy2(int[] nums) {
        int k = 0;
        int i = 0;
        
        // Handling cases where the input array has less than two elements
        while (i < nums.Length && k < 2) {
            nums[k++] = nums[i++];
        }
        
        for (i = 2; i < nums.Length; i++) {
            if (nums[i] != nums[k - 2]) {
                nums[k++] = nums[i];
            }
        }

        return k;
    }
    
    private int RemoveDuplicates(int[] nums)
    {
        var index = 0;
        for (var i = 1; i < nums.Length; i++)
        {
            if (nums[index] != nums[i])
            {
                index += nums[index] == nums[index + 1] ? 2 : 1;
                (nums[index], nums[i]) = (nums[i], nums[index]);
                continue;
            }

            nums[index + 1] = nums[i];

            if (i == nums.Length - 1 && i - index >= 1)
            {
                index++;
            }
        }
        index++;
        
        return index;
    }
}