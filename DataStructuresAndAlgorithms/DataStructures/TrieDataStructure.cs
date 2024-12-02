using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithmsConsoleApp.DataStructures
{
    public class TrieDataStructure
    {
        public void Run()
        {
            var wordsToAdd = new string[] { "dart", "detect", "device", "apartment", "advance", "apple" };
            var wordsToSearch = new string[] { "detect", "apartment", "apartmenttt", "ap","test" };
            var rootTrie = new Trie();

            foreach (var word in wordsToAdd)
            {
                rootTrie.Add(word);
                Console.WriteLine($"Added {word} to Trie");
            }

            foreach (var word in wordsToSearch)
            {
                if (rootTrie.Contains(word))
                {
                    Console.WriteLine($"Trie contain {word}");
                }
                else
                {
                    Console.WriteLine($"Trie does not contains {word}");
                }
            }
        }
    
        private class Trie
        {
            public bool IsLastWord { get; set; }
            public Dictionary<char, Trie> Childs { get; set; } = new();

            public void Add(string word)
            {
                var current = this;
                foreach (var c in word)
                {
                    if (!current.Childs.TryGetValue(c,out var child))
                    {
                        child = new Trie();
                        current.Childs.Add(c, child);
                    }

                    current = child;
                }
                current.IsLastWord = true;
            }

            public bool Contains(string word)
            {
                Trie current = this;

                foreach (var c in word)
                {
                    if (!current.Childs.TryGetValue(c,out current))
                    {
                        return false;
                    }
                }

                return current.IsLastWord;
            }
        }
    }
}
