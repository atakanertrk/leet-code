using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeConsoleApp
{
    internal class ShiftingTwoDimMatrix : LeetCodeRunner
    {
        private static char[,] arr = new char[,]
        {
         // -> x
            { '1', '0', '1', '0', '1', '0', '0', '0' },
            { '1', '1', '0', '0', '1', '0', '1', '0' },
            { '1', '1', '0', '0', '0', '1', '1', '0' },
            { '1', '1', '0', '1', '0', '0', '0', '0' },
            { '1', '0', '0', '0', '0', '1', '0', '0' },
            { '1', '1', '1', '0', '1', '0', '1', '0' },
            { '1', '1', '0', '0', '1', '0', '0', '0' },
            { '1', '1', '0', '0', '1', '0', '0', '0' },
            { '1', '1', '1', '1', '0', '0', '1', '0' }
        // ^y
        };
        // output should look like following
        //01010100
        //01100101
        //01100011
        //01101000
        //01000010
        //01110101
        //01100100

        public override void Run()
        {
            var shiftedArr = ShiftArray(arr);
        }

        private char[,] ShiftArray(char[,] input, int shiftAmount = 1)
        {
            var yLength = input.GetLength(0);
            var xLength = input.GetLength(1);
            char[,] output = new char[yLength, xLength];

            for (int y = 0; y < yLength; y++)
            {
                for (int x = 0; x < xLength; x++)
                {
                    if (x < shiftAmount)
                    {
                        output[y, x] = '0';
                    }
                    else
                    {
                        output[y, x] = input[y, x - shiftAmount];
                    }
                }
            }
            
            return output;
        }
    }
}
