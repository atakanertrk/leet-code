using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeConsoleApp
{
    public class CheckNeighbouringNumbersInMatrix : LeetCodeRunner
    {
        // Check CheckNeighbouringNumbersInMatrix-1.png for implemented example input/output
        /*
           x>
             | 9 4 |
             | 6 3 |
             | 5 8 |
           ^Y
               
         */
        public override void Run()
        {
            int[,] matrix = 
            { 
                { 9, 4 }, 
                { 6, 3 }, 
                { 5, 8 }
            };

            var neighboursList = new List<Neighbour>();
            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    var currentValue = (int)matrix.GetValue(y, x);
                    var neighbour = new Neighbour() { Value = currentValue, Neighbours = new List<int>() };
                    int xNeighbourIndex2 = x - 1;
                    int yNeighbourIndex1 = y + 1;
                    int yNeighbourIndex2 = y - 1;

                    if (x + 1 >= 0 && x + 1 <= matrix.GetLength(1))
                    {
                        neighbour.Neighbours.Add((int)matrix.GetValue(y, x + 1));
                    }
                    if (x - 1 >= 0 && x + 1 <= matrix.GetLength(1))
                    {
                        neighbour.Neighbours.Add((int)matrix.GetValue(y, x - 1));
                    }

                    if (y + 1 >= 0 && y + 1 <= matrix.GetLength(0))
                    {
                        neighbour.Neighbours.Add((int)matrix.GetValue(y + 1, x));
                    }
                    if (y - 1 >= 0 && y + 1 <= matrix.GetLength(0))
                    {
                        neighbour.Neighbours.Add((int)matrix.GetValue(y - 1, x));
                    }
                }
            }
        }

        private class Neighbour
        {
            public int Value { get; set; }
            public List<int> Neighbours { get; set; }
        }
    }
}
