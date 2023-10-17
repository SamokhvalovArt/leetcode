namespace Samokhvalov.LeetCode.Problems.Array;

public class InsertDeleteGetRandomO1 : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/insert-delete-getrandom-o1/";

    public ProblemLevel Level => ProblemLevel.Medium;
    
    public void Run()
    {
        var randomizedSet = new RandomizedSet();
        Console.WriteLine(randomizedSet.Insert(1)); // Inserts 1 to the set. Returns true as 1 was inserted successfully.
        Console.WriteLine(randomizedSet.Remove(2)); // Returns false as 2 does not exist in the set.
        Console.WriteLine(randomizedSet.Insert(2)); // Inserts 2 to the set, returns true. Set now contains [1,2].
        Console.WriteLine(randomizedSet.GetRandom()); // getRandom() should return either 1 or 2 randomly.
        Console.WriteLine(randomizedSet.Remove(1)); // Removes 1 from the set, returns true. Set now contains [2].
        Console.WriteLine(randomizedSet.Insert(2)); // 2 was already in the set, so return false.
        Console.WriteLine(randomizedSet.GetRandom()); // Since 2 is the only number in the set, getRandom() will 
    }

    public bool Solved => true;
}

public class RandomizedSet
{
    private readonly HashSet<int> _hashSet;
    private readonly Random _random;

    public RandomizedSet()
    {
        _hashSet = new HashSet<int>();
        _random = new Random();
    }
    
    public bool Insert(int val)
    {
        return _hashSet.Add(val);
    }
    
    public bool Remove(int val)
    {
        return _hashSet.Remove(val);
    }
    
    public int GetRandom()
    {
        return _hashSet.ElementAt(_random.Next(_hashSet.Count));
    }
}