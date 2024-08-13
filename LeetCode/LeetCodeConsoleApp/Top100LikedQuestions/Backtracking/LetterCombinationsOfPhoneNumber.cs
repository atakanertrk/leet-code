using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeConsoleApp
{
    public class LetterCombinationsOfPhoneNumber : LeetCodeRunner
    {
        Dictionary<char, char[]> keypad = new Dictionary<char, char[]>
        {
            {'2', new char[] {'a', 'b', 'c'}},
            {'3', new char[] {'d', 'e', 'f'}},
            {'4', new char[] {'g', 'h', 'i'}},
            {'5', new char[] {'j', 'k', 'l'}},
            {'6', new char[] {'m', 'n', 'o'}},
            {'7', new char[] {'p', 'q', 'r', 's'}},
            {'8', new char[] {'t', 'u', 'v'}},
            {'9', new char[] {'w', 'x', 'y', 'z'}}
        };

        public override void Run()
        {
            var output = LetterCombinations("234");
            // adg, adh, adi, aeg, aeh, aei, afg, afh, afi, bdg, bdh, bdi, beg, beh, bei, bfg, bfh, bfi, cdg, cdh, cdi, ceg, ceh, cei, cfg, cfh, cfi
            foreach (var item in output)
            {
                Console.WriteLine(item);
            }
        }

        public IList<string> LetterCombinations(string digits)
        {
            List<string> combinations = new List<string>();

            if (digits.Length == 0)
            {
                return combinations;
            }

            if (digits.Length == 1)
            {
                return keypad[digits[0]].Select(x => x.ToString()).ToList();
            }

            combinations.Add("");

            foreach (var digit in digits)
            {
                var characters = keypad[digit];
                var tempCombinations = new List<string>();

                foreach (var combination in combinations)
                {
                    foreach (var c in characters)
                    {
                        tempCombinations.Add(combination + c);
                    }
                }

                combinations = tempCombinations;
            }
            return combinations;
        }
    }
}
