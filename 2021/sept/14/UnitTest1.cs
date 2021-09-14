using NUnit.Framework;
using Sol1;
namespace _14
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            _solution = new Solution();
            _solution.Debug = true;
        }

        [Test]
        [TestCaseSource(nameof(TestCases))]
        public void Test1(string input, string expected)
        {
            var actual = _solution.ReverseOnlyLetters(input);
            Assert.AreEqual(expected, actual, $"Input:{input}, Expected: {expected}, Actual: {actual}");
        }

        // Test Data
        static object[] TestCases = {
            new object[] {"ab-cd", "dc-ba"},
            new object[] {"a-bC-dEf-ghIj", "j-Ih-gfE-dCba"},
            new object[] {"Test1ng-Leet=code-Q!", "Qedo1ct-eeLg=ntse-T!"},
        };
        private Solution _solution;
    }
}