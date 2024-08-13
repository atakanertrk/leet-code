
namespace LeetCodeConsoleApp
{
    public class CombinationSumProblem : LeetCodeRunner
    {
        public IList<IList<int>> CombinationSum(int[] candidates, int target)
        {
            IList<IList<int>> output = new List<IList<int>>();
            var current = new List<int>();
            Calculate(0, current, candidates,target, output);
            return output;
        }

        public override void Run()
        {
            var result = CombinationSum([2, 3, 6, 7], 7);
            foreach (var item in result)
            {
                Console.WriteLine("---");
                Console.WriteLine(string.Join(", ",item));
            }
        }

        private void Calculate(int candidateIndex, List<int> current, int[] candidates, int target, IList<IList<int>> output)
        {
            if (candidateIndex > candidates.Length - 1)
            {
                return;
            }

            int total = current.Sum(i => i);
            if (total == target)
            {
                output.Add(new List<int>(current)); 
                return; // exit
            }

            int candidate = candidates[candidateIndex];

            if (total + candidate <= target)
            {
                current.Add(candidate);
                Calculate(candidateIndex, current, candidates, target, output);
                current.RemoveAt(current.Count - 1); // Backtrack
            }

            Calculate(candidateIndex + 1, current, candidates, target, output);  // next candidate
        }
    }
}
