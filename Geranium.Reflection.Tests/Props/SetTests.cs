using Geranium.Reflection.Benchmarks;
using Geranium.Reflection;

namespace Geranium.Reflection.Tests.Props
{
    [TestClass]
    public class SetTests
    {
        [TestMethod]
        public void SetProp()
        {
            var obj = new BenchClass() { };
            obj.SetPropValue(nameof(BenchClass.I),10);
            Assert.AreEqual(obj.I, 10);
        }

        [TestMethod]
        public void SetPropConverted()
        {
            var obj = new BenchClass() { };
            obj.SetPropValue(nameof(BenchClass.WrongType), 10F);
            Assert.AreEqual(obj.WrongType, 10D);
        }

        [TestMethod]
        public void SetPropEnum()
        {
            var obj = new BenchClass() { };
            obj.SetPropValue(nameof(BenchClass.Enum), ConsoleColor.Cyan);
            Assert.AreEqual(obj.Enum, ConsoleColor.Cyan);
        }

        [TestMethod]
        public void SetPropNullable_Null()
        {
            var obj = new BenchClass() { Nullable=5 };
            obj.SetPropValue(nameof(BenchClass.Nullable), null);
            Assert.AreEqual(obj.Nullable, null);
        }

        [TestMethod]
        public void SetPropNullable_Value ()
        {
            var obj = new BenchClass() { Nullable=null };
            obj.SetPropValue(nameof(BenchClass.Nullable), 5);
            Assert.AreEqual(obj.Nullable, 5);
        }
    }
}
