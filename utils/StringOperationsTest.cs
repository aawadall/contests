using System.Collections.Generic;
using NUnit.Framework;

namespace utils
{
    public class StringOperationsTest
    {
        /// <summary>
        /// Test Cases for permutations of a string
        /// made of the following components:
        /// - test case name
        /// - input string
        /// - expected output
        /// </summary>
        /// <value></value>
        private static object[] _permuteTestCases =
        new object[] {
            new object[] { "Empty String", "", new string[]{} },
            new object[] { "Single Character", "a", new string[]{"a"} },
            new object[] { "Two Characters", "ab", new string[]{"ab", "ba"} },
            new object[] { "Three Characters", "abc", new string[]{"abc", "acb", "bac", "bca", "cab", "cba"} },
            new object[] { "Four Characters", "abcd", new string[]{"abcd", "abdc", "acbd", "acdb", "adbc", "adcb", "bacd", "badc", "bcad", "bcda", "bdac", "bdca", "cabd", "cadb", "cbad", "cbda", "cdab", "cdba", "dabc", "dacb", "dbac", "dbca", "dcab", "dcba"} },
        };
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCaseSource(nameof(_permuteTestCases))]
        public void PermuteTests(string testCaseName, string input, string[] expectedOutput)
        {
            string[] actual = input.Permute();
            var actualOutput = new SortedSet<string>(actual);

            Assert.AreEqual(new SortedSet<string>(expectedOutput), actualOutput);
        }


    }
}