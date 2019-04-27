﻿using NUnit.Framework;
using System.Linq;
using Tools.DataStructures;

namespace Tools.Test.DataStructures
{
    [TestFixture]
    public class PrefixTreeTests
    {
        private static readonly string[] memoryDictionary =
            {
                "test",
                "try",
                "angle",
                "the",
                "people",
                "things",
                "these",
                "terra",
                "ark"
            };

        [Theory]
        [TestCase("Not In Dictionary", new string[] { })]
        [TestCase("te", new string[] { "test", "terra" })]
        [TestCase("th", new string[] { "things", "these", "the" })]
        [TestCase("tr", new string[] { "try" })]
        [TestCase("a", new string[] { "ark", "angle" })]
        [TestCase("", new string[] {
                "test",
                "try",
                "angle",
                "the",
                "people",
                "things",
                "these",
                "terra",
                "ark"
            })]
        public void SearchReturnsAllAvailableSubset(string searchString, string[] expected)
        {
            var trie = new PrefixTree();

            foreach(string word in memoryDictionary)
            {
                trie.Add(word);
            }

            var results = trie.Search(searchString);

            Assert.IsFalse(results.Except(expected).Any());
            Assert.IsFalse(expected.Except(results).Any());
        }
    }
}