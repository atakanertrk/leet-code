using System;

namespace DataStructuresAndAlgorithmsConsoleApp.DataStructures
{
    public class FindIndexRecursive
    {
        int[] numbers = { 47, 56, 127, 963, 47, 15, 98, 32, 1 };
        public void Run()
        {
            var foundIndex = FindIndex_Recursive(98, 0);
            Console.WriteLine(foundIndex);
        }

        private int FindIndex_Recursive(int searchVal, int searchIndex)
        {
            if (searchIndex >= numbers.Length)
            {
                return -1;
            }

            if (numbers[searchIndex] == searchVal)
            {
                return searchIndex;
            }

            return FindIndex_Recursive(searchVal, ++searchIndex);
        }

    }
}