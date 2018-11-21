using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTestProject4
{
    [TestFixture]
    public class UnitTest1
    {
        [TestCase(106, "2", true)]
        [TestCase(106, "11", true)]
        [TestCase(106, "0", false)]
        [TestCase(106, "12", false)]
        [TestCase(106, "99", true)]
        [TestCase(107, "2a", true)]
        [TestCase(107, "2b", true)]
        [TestCase(107, "14", true)]
        [TestCase(107, "1", true)]
        [TestCase(107, "2", false)]
        [TestCase(107, "12", false)]
        [TestCase(107, "99", true)]
        [TestCase(107, "abc", false)]
        public void valid_list(int year, string content, bool expected)
        {
            var medical = new Medical(year, content);
            Assert.AreEqual(expected, medical.IsValid());
        }
    }
}