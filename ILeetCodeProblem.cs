namespace Samokhvalov.LeetCode;

public enum ProblemLevel
{
    Easy,
    Medium,
    Hard
}

public interface ILeetCodeProblem
{
    string ProblemUrl { get; }
    
    ProblemLevel Level { get; }

    void Run();
    
    bool Solved { get; }
}