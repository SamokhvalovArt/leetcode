namespace Samokhvalov.LeetCode.Problems.Stack;

public class MinStackWrap : ILeetCodeProblem
{
    public string ProblemUrl => "https://leetcode.com/problems/min-stack/";

    public ProblemLevel Level => ProblemLevel.Easy;
    
    public void Run()
    {
        MinStack minStack = new MinStack();
        minStack.Push(-2);
        minStack.Push(0);
        minStack.Push(-3);
        Console.WriteLine(minStack.GetMin()); // return -3
        minStack.Pop();
        Console.WriteLine(minStack.Top());    // return 0
        Console.WriteLine(minStack.GetMin()); // return -2
    }

    public bool Solved => true;
}

public class MinStack
{
    private readonly List<(int, int)> _container = new();
    
    public MinStack() {
        
    }
    
    public void Push(int val) {
        if (_container.Count == 0)
        {
            _container.Add((val, val));
            return;
        }

        var currentMinValue = _container[^1].Item2;
        _container.Add((val, val < currentMinValue ? val : currentMinValue));
    }
    
    public void Pop() {
        _container.RemoveAt(_container.Count - 1);
    }
    
    public int Top()
    {
        return _container[^1].Item1;
    }
    
    public int GetMin()
    {
        return _container[^1].Item2;
    }
}