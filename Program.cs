// See https://aka.ms/new-console-template for more information

using System.Reflection;
using Samokhvalov.LeetCode;

foreach (var leetCodeProblem in GetAllProblems().Where(x => !x.Solved))
{
    Console.WriteLine($"-----{leetCodeProblem.GetType().Name}-----");
    leetCodeProblem.Run();
    Console.WriteLine();
}

Console.ReadLine();

static IEnumerable<ILeetCodeProblem?> GetAllProblems()
{
    // Get all types in the current assembly that implement IMyInterface
    var interfaceType = typeof(ILeetCodeProblem);
    var implementingTypes = Assembly.GetExecutingAssembly().GetTypes()
        .Where(t => interfaceType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

    // Initialize instances of implementing classes and call DoSomething()
    foreach (var implementingType in implementingTypes)
    {
        yield return (ILeetCodeProblem)Activator.CreateInstance(implementingType)!;
    }
}