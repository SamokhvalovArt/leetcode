namespace Samokhvalov.LeetCode.Problems.Array;

/// <summary>
/// You are given two integer arrays nums1 and nums2, sorted in non-decreasing order, and two integers m and n,
/// representing the number of elements in nums1 and nums2 respectively.
/// Merge nums1 and nums2 into a single array sorted in non-decreasing order.
/// The final sorted array should not be returned by the function, but instead be stored inside the array nums1.
/// To accommodate this, nums1 has a length of m + n, where the first m elements denote the elements that should be merged,
/// and the last n elements are set to 0 and should be ignored. nums2 has a length of n.
///
/// Input: nums1 = [1,2,3,0,0,0], m = 3, nums2 = [2,5,6], n = 3
/// Output: [1,2,2,3,5,6]
///
/// [3,4,5,0,0], m = 3, nums2 = [1,2], n = 2
/// </summary>
public sealed class MergeSortedArray : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/merge-sorted-array/";
    
    public ProblemLevel Level => ProblemLevel.Easy;
    
    public void Run()
    {
        var nums1 = new[] { 1, 2, 3, 0, 0, 0 };
        var m = 3;
        var nums2 = new[] { 2, 5, 6 };
        var n = 3;
        
        Console.WriteLine($"Before merge -> {string.Join(", ", nums1)}");
        
        Merge(nums1, m, nums2, n);
        
        Console.WriteLine($"After merge -> {string.Join(", ", nums1)}");
    }

    public bool Solved => true;

    private void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var nums1Copy = new int[m + n];
        nums1.CopyTo(nums1Copy, 0);

        var nums1Index = 0;
        var nums2Index = 0;
        for (var i = 0; i < n + m; i++)
        {
            if (nums1Index == m)
            {
                nums1[i] = nums2[nums2Index];
                nums2Index++;
                continue;
            }
            
            if (nums2Index == n)
            {
                nums1[i] = nums1Copy[nums1Index];
                nums1Index++;
                continue;
            }
           
            var nums1Value = nums1Copy[nums1Index];
            var nums2Value = nums2[nums2Index];
            if (nums1Value <= nums2Value)
            {
                nums1[i] = nums1Copy[nums1Index];
                nums1Index++;
            }
            else
            {
                nums1[i] = nums2[nums2Index];
                nums2Index++;
            }
        }
    }
}