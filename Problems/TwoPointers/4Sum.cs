namespace Samokhvalov.LeetCode.Problems.TwoPointers;

public class FourSum : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/4sum";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        var nums = new[] { 1000000000,1000000000,1000000000,1000000000 };
        var target = -294967296;

        Console.WriteLine($"Nums = {nums.ToStringCollection()}, Target = {target}");
        Console.WriteLine(
            $"ThreeSum = {string.Join("| ", FourSumImpl(nums, target).Select(x => x.ToStringCollection()))}");
    }

    private IList<IList<int>> FourSumImpl(int[] nums, int target)
    {
        var results = new List<IList<int>>();
        
        if (nums.Length < 4)
        {
            return results;
        }
        
        System.Array.Sort(nums);
        for (var i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }

            for (var j = i + 1; j < nums.Length; j++)
            {
                if (j > i + 1 && nums[j] == nums[j - 1])
                {
                    continue;
                }

                var leftIndex = j + 1;
                var rightIndex = nums.Length - 1;

                while (leftIndex < rightIndex)
                {
                    var leftV = nums[leftIndex];
                    var rightV = nums[rightIndex];
                    var  sum = (long)nums[i] + nums[j] + leftV + rightV;

                    if (sum > target)
                    {
                        rightIndex -= 1;
                        continue;
                    }

                    if (sum < target)
                    {
                        leftIndex += 1;
                        continue;
                    }

                    results.Add(new[] { nums[i], nums[j], leftV, rightV });
                    
                    leftIndex += 1;
                    while (nums[leftIndex] == nums[leftIndex - 1] && leftIndex < rightIndex)
                    {
                        leftIndex += 1;
                    }
                }
            }
        }
        
        return results;
    }
    
    public bool Solved => true;
}