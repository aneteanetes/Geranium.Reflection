using Geranium.Reflection.Benchmarks;

namespace Geranium.Reflection.Tests.Ctor
{
    [TestClass]
    public class CtorExtensionsTests
    {
        //[TestMethod]
        //public void FindConstructorTest0Args()
        //{
        //    var empty = typeof(BenchClass).Newa();
        //    Assert.AreEqual(empty.ToString(), "");
        //}

        //[TestMethod]
        //public void FindConstructorTest2Args1()
        //{
        //    var empty = typeof(BenchClass).Newa(5,"0");
        //    Assert.AreEqual(empty.ToString(), "50");
        //}

        //[TestMethod]
        //public void FindConstructorTest2Args2()
        //{
        //    var empty = typeof(BenchClass).Newa("0", 5);
        //    Assert.AreEqual(empty.ToString(), "50");
        //}

        //[TestMethod]
        //public void FindConstructorTest3ArgsFailType()
        //{
        //    var empty = typeof(BenchClass).Newa("0", 5, new BenchClass());
        //    Assert.AreNotEqual(empty?.ToString(), "50");
        //}

        //[TestMethod]
        //public void FindConstructorTest3ArgsFailOrder()
        //{
        //    var empty = typeof(BenchClass).Newa("0", 5, new object());
        //    Assert.AreNotEqual(empty?.ToString(), "50");
        //}

        //[TestMethod]
        //public void FindConstructorTest3ArgsSuccess()
        //{
        //    var empty = typeof(BenchClass).Newa(5, "0", new object());
        //    Assert.AreEqual(empty.ToString(), $"50{typeof(object).ToString()}");
        //}
    }
}
