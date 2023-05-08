using Geranium.Reflection.Benchmarks;

namespace Geranium.Reflection.Tests.New
{
    [TestClass]
    public class NewTests
    {
        [TestMethod]
        public void New()
        {
            var empty = typeof(BenchClass).New();
            Assert.AreEqual(empty.ToString(), "-10");
        }

        [TestMethod]
        public void New1()
        {
            var empty = typeof(BenchClass).New(5);
            Assert.AreEqual(empty.ToString(), "50");
        }

        [TestMethod]
        public void New2()
        {
            var empty = typeof(BenchClass).New(5,"%");
            Assert.AreEqual(empty.ToString(), "5%0");
        }

        [TestMethod]
        public void New2Args()
        {
            var args = new object[] {5,"%"};
            var empty = typeof(BenchClass).New(args);
            Assert.AreEqual(empty?.ToString(), "5%0");
        }
    }
}
