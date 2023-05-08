using Geranium.Reflection.Benchmarks;
using Geranium.Reflection;

namespace Geranium.Reflection.Tests.Props
{
    [TestClass]
    public class GetTests
    {
        [TestMethod]
        public void GetPropTypes()
        {
            var obj = new BenchClass() { I=5 };
            var value = obj.GetPropValue<BenchClass,int>(nameof(BenchClass.I));
            Assert.AreEqual(value, 5);
        }

        [TestMethod]
        public void GetPropResultType()
        {
            var obj = new BenchClass() { I=5 };
            var value = obj.GetPropValue<int>(nameof(BenchClass.I));
            Assert.AreEqual(value, 5);
        }

        [TestMethod]
        public void GetPropObjects()
        {
            var obj = new BenchClass() { I=5 };
            var value = obj.GetPropValue(nameof(BenchClass.I));
            Assert.AreEqual(value, 5);
        }
    }
}
