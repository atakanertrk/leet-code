using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithmsConsoleApp.DataStructures
{
    public class RecursiveBinarySearchTree
    {
        private class Node
        {
            public Node(int value)
            {
                Value = value;
            }
            public int Value { get; init; }
            public Node? RightNode { get; set; }
            public Node? LeftNode { get; set; }
        }

        private Node? _rootNode;

        public void Run()
        {
            LoadDummyBinarySearchTree();
            FindNodeWithValue(99999, _rootNode);
            FindNodeWithValue(15,_rootNode);

            Console.WriteLine("...traverse start");
            Traverse(_rootNode);
        }

        private void LoadDummyBinarySearchTree()
        {
            var values = new int[] { 22,5,10,7,15,20,9,30,40,23 };
            foreach (var value in values)
            {
                AddNode(_rootNode,value);
            }
        }

        private void FindNodeWithValue(int val,Node currentNode)
        {
            Console.WriteLine($"Searching: {val}, currentNode: {currentNode.Value}");

            if (currentNode.Value == val)
            {
                Console.WriteLine($"found {val}!");
                return;
            }

            if (currentNode.Value < val && currentNode.RightNode is not null)
            {
                FindNodeWithValue(val, currentNode.RightNode);
            }
            if (currentNode.Value > val && currentNode.LeftNode is not null)
            {
                FindNodeWithValue(val, currentNode.LeftNode);
            }
        }

        private void AddNode(Node? currentNode, int valueToBeAdded)
        {
            if (currentNode is null)
            {
                _rootNode = new Node(valueToBeAdded);
                return;
            }

            if (valueToBeAdded > currentNode.Value)
            {
                if (currentNode.RightNode is null)
                {
                    currentNode.RightNode = new Node(valueToBeAdded);
                }
                else
                {
                    AddNode(currentNode.RightNode, valueToBeAdded);
                }
                return;
            }
            if (valueToBeAdded < currentNode.Value)
            {
                if (currentNode.LeftNode is null)
                {
                    currentNode.LeftNode = new Node(valueToBeAdded);
                }
                else
                {
                    AddNode(currentNode.LeftNode, valueToBeAdded);
                }
                return;
            }
            else
            {
                Console.WriteLine($"duplicate value not added to tree {valueToBeAdded}");
            }
        }

        private void Traverse(Node? node)
        {
            if (node is null)
            {
                return;
            }
            Traverse(node.LeftNode);
            Console.WriteLine(node.Value);
            Traverse(node.RightNode);
        }
    }
}