using System.Reflection;

namespace LeetCodeConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var type = assembly.GetType($"LeetCodeConsoleApp.LetterCombinationsOfPhoneNumber");

            var instance = Activator.CreateInstance(type);

            MethodInfo methodInfo = type.GetMethod("Run");
            methodInfo.Invoke(instance, null);
        }
    }
}
