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
            Console.WriteLine(
           """
               Calculating Neighbours For;
                { 9, 4 }
                { 6, 3 }
                { 5, 8 }

           """);
            int[,] matrix =
            {
                { 9, 4 },
                { 6, 3 },
                { 5, 8 }
            };
            var neighbourList = FindNeighbours(matrix);
            PrintNeighbourRelationship(neighbourList);

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(
    """
               Calculating Neighbours For;
                { 9, 77, 4, 12 }
                { 6, 11, 3, 32 }
                { 5, 23, 8, 16 }
                { 89, 42, 55, 76 }

          """);
            int[,] matrix2 = 
            {
                { 9, 77, 4, 12 },
                { 6, 11, 3, 32 },
                { 5, 23, 8, 16 },
                { 89, 42, 55, 76 }
            };
            var neighbourList2 = FindNeighbours(matrix2);
            PrintNeighbourRelationship(neighbourList2);
        }

        private void PrintNeighbourRelationship(List<Neighbour> neighboursList)
        {
            foreach (var neighbour in neighboursList)
            {
                Console.WriteLine(neighbour.Value);
                PrintNeighboursOfValue(neighbour);
            }
        }

        private void PrintNeighboursOfValue(Neighbour neighbour)
        {
            foreach (var value in neighbour.Neighbours)
            {
                Console.WriteLine($"  -{value}");
            }
        }

        private List<Neighbour> FindNeighbours(int[,] matrix)
        {
            // my assumption is each element is neighbour of its +/- 1 on both x and y axis
            // therefore I create Neighbour class and List of it to contain neigbour relationship
            var neighboursList = new List<Neighbour>();
            for (int y = 0; y < matrix.GetLength(0); y++)
            {
                for (int x = 0; x < matrix.GetLength(1); x++)
                {
                    var currentValue = (int)matrix.GetValue(y, x);
                    var neighbour = new Neighbour() { Value = currentValue, Neighbours = new List<int>() };

                    if (x + 1 < matrix.GetLength(1))
                    {
                        neighbour.Neighbours.Add((int)matrix.GetValue(y, x + 1));
                    }
                    if (x - 1 >= 0 && x - 1 < matrix.GetLength(1))
                    {
                        neighbour.Neighbours.Add((int)matrix.GetValue(y, x - 1));
                    }

                    if (y + 1 < matrix.GetLength(0))
                    {
                        neighbour.Neighbours.Add((int)matrix.GetValue(y + 1, x));
                    }
                    if (y - 1 >= 0 && y - 1 < matrix.GetLength(0))
                    {
                        neighbour.Neighbours.Add((int)matrix.GetValue(y - 1, x));
                    }
                    neighboursList.Add(neighbour);
                }
            }
            return neighboursList;
        }

        private class Neighbour
        {
            public int Value { get; set; }
            public List<int> Neighbours { get; set; }
        }
    }
}
