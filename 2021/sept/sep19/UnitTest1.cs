using NUnit.Framework;
using System.Diagnostics;

namespace sep19
{
    public class Tests
    {
        private ISolution _solution;
        private delegate int TestDelegate(string s, string t);
        private int _maxTime = 100;

        [SetUp]
        public void Setup()
        {
            _solution = new Solution4();
            // log level 
            _solution.EnableDebug = false;
            Trace.Listeners.Add(new ConsoleTraceListener());
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void Test1(string testCaseName, string s, string t, int expected)
        {
            Trace.WriteLine(testCaseName);
            int actual;
            Profile(_solution.NumDistinct, s, t, testCaseName, out actual);
            Assert.AreEqual(expected, (int)actual);
        }

        private void Profile(TestDelegate testDelegate, string s, string t, string testCaseName, out int actual)
        {
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();
            actual = testDelegate(s, t);
            stopwatch.Stop();
            var time = stopwatch.ElapsedMilliseconds;
            Assert.LessOrEqual(time, _maxTime, $"{testCaseName} took {time}ms which is more than {_maxTime}ms");
        }

        private static object[] TestCases = {

            new object[] {
                "Example 1",
                "rabbbit",
                "rabbit",
                3
            },
            new object[] {
                "Example 2",
                "babgbag",
                "bag",
                5
            },
            new object[] {
                "Test case 41",
                "dbaaadcddccdddcadacbadbadbabbbcad",
                "dadcccbaab",
                702
            },
            new object[] {
                "Test case 53",
                "adbdadeecadeadeccaeaabdabdbcdabddddabcaaadbabaaedeeddeaeebcdeabcaaaeeaeeabcddcebddebeebedaecccbdcbcedbdaeaedcdebeecdaaedaacadbdccabddaddacdddc",
                "bcddceeeebecbc",
                700531452
            },
            new object[] {
                "Test case 51",
                "daacaedaceacabbaabdccdaaeaebacddadcaeaacadbceaecddecdeedcebcdacdaebccdeebcbdeaccabcecbeeaadbccbaeccbbdaeadecabbbedceaddcdeabbcdaeadcddedddcececbeeabcbecaeadddeddccbdbcdcbceabcacddbbcedebbcaccac",
                "ceadbaa",
                8556153
            },
        };
    }
}