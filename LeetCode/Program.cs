using System.Reflection;

namespace LeetCodeConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType($"LeetCodeConsoleApp.{nameof(CheckNeighbouringNumbersInMatrix)}")!;

            var instance = Activator.CreateInstance(type);

            MethodInfo methodInfo = type.GetMethod("Run")!;
            methodInfo!.Invoke(instance, null);
        }
    }

    public abstract class LeetCodeRunner
    {
        public abstract void Run();
    }
}
