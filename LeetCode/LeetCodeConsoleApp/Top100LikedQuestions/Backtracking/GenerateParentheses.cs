using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeConsoleApp
{
    public class GenerateParentheses : LeetCodeRunner
    {
        private List<string> result = new List<string>();

        public override void Run()
        {
            int count = 3; // total open/close paranthese. For example 3 is -> ((()))
            Generate("", 0, 0, count);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        private void Generate(string current, int open, int close, int n)
        {
            if (current.Length == n * 2)
            {
                result.Add(current);
                return;
            }

            if (open < n)
            {
                Generate(current + "(", open + 1, close, n);
            }
            if (close < open)
            {
                Generate(current + ")", open, close + 1, n);
            }
        }


    }
}
