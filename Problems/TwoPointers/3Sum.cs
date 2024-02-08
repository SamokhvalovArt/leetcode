using System.Collections.ObjectModel;

namespace Samokhvalov.LeetCode.Problems.TwoPointers;

/// <summary>
/// Given an integer array nums,
/// return all the triplets
/// [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.
///
/// Input: nums = [-1,0,1,2,-1,-4]
/// Output: [[-1,-1,2],[-1,0,1]]
/// </summary>
public class ThreeSum : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/3sum";

    public ProblemLevel Level => ProblemLevel.Medium;

    public void Run()
    {
        var nums = new[] { -5, -1, 0 , 1, 3, 1, 5 };
        
        Console.WriteLine($"Nums = {nums.ToStringCollection()}");
        Console.WriteLine($"ThreeSum = {string.Join("| ", ThreeSumImpl_2(nums).Select(x => x.ToStringCollection()))}");
    }

    public bool Solved => true;


    private IList<IList<int>> ThreeSumImpl_2(int[] nums)
    {
        System.Array.Sort(nums);
        var results = new List<IList<int>>();

        for (var i = 0; i < nums.Length; i++)
        {
            var iValue = nums[i];
            var lIndex = i + 1;
            var rIndex = nums.Length - 1;

            while (lIndex < rIndex)
            {
                if (i > 0 && iValue == nums[i - 1])
                {
                    lIndex += 1;
                    continue;
                }

                var sum = iValue + nums[lIndex] + nums[rIndex];
                if (sum > 0)
                {
                    rIndex -= 1;
                    continue;
                }
                if (sum < 0)
                {
                    lIndex += 1;
                    continue;
                }

                results.Add(new[] { iValue, nums[lIndex], nums[rIndex] });
                lIndex += 1;
                while (nums[lIndex] == nums[lIndex - 1] && lIndex < rIndex)
                {
                    lIndex += 1;
                }
            }
        }

        return results;
    }
    
    private IList<IList<int>> ThreeSumImpl(int[] nums)
    {
        if (nums.Length <= 2)
        {
            return new Collection<IList<int>>();
        }

        var result = new List<IList<int>>();
        
        System.Array.Sort(nums);
        var startIndex = nums.Length / 2;
        var rightIndex = startIndex + 1;
        var leftIndex = startIndex - 1;
        while (leftIndex >= 0 && rightIndex < nums.Length)
        {
            var allMoreZero = false;
            var allLessZero = false;
            for (var i = leftIndex + 1; i < rightIndex; i++)
            {
                var sum = nums[leftIndex] + nums[i] + nums[rightIndex];
                allMoreZero = sum >= 0;
                allLessZero = sum <= 0;

                if (sum == 0)
                {
                    result.Add(new[] { nums[leftIndex], nums[i], nums[rightIndex] });
                }
            }

            if (allMoreZero)
            {
                leftIndex -= 1;
                rightIndex -= 1;
                if (leftIndex < 0)
                {
                    break;
                }

                continue;
            }
            if (allLessZero)
            {
                rightIndex += 1;
                leftIndex += 1;
                if (rightIndex >= nums.Length)
                {
                    break;
                }

                continue;
            }

            if (rightIndex + 1 < nums.Length - 1)
            {
                rightIndex += 1;
                continue;
            }

            if (leftIndex - 1 != 0)
            {
                leftIndex -= 1;
                continue;
            }
        }

        return result;
    }
}