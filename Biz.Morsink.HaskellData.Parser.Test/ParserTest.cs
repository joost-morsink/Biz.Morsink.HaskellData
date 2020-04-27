using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pidgin;

namespace Biz.Morsink.HaskellData.Parser.Test
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void Primitive()
        {
            var res = DataParser.PValue.Parse("42");
            Assert.IsTrue(res.Success);
            Assert.AreEqual(new HInt(42), res.Value);
            res = DataParser.PValue.Parse("3.14");
            Assert.IsTrue(res.Success);
            Assert.AreEqual(new HDouble(3.14), res.Value);
            res = DataParser.PValue.Parse("\"\\\\A\\tb\\nc\\\\\"");
            Assert.IsTrue(res.Success);
            Assert.AreEqual(new HString("\\A\tb\nc\\"), res.Value);
        }
        [TestMethod]
        public void List()
        {
            var str = "[1, 2, 3]";
            DataParser.PValue.Parse(str).AssertSuccess(lst => 
                Assert.AreEqual(new HList(new HValue[] { 1, 2, 3 }), lst));
        }
        [TestMethod]
        public void Record()
        {
            var str = "Person { name=\"Joost\", age = 40 }";
            DataParser.PValue.Parse(str).AssertSuccess(rec => 
                Assert.AreEqual(new HRecord("Person", new[]
                {
                    new HMapping("name","Joost"),
                    new HMapping("age",40)
                }), rec));
        }
        [TestMethod]
        public void Tuple()
        {
            var str = "(1,\"a\",3.14)";
            DataParser.PValue.Parse(str).AssertSuccess(t =>
                Assert.AreEqual(new HTuple(new HValue[] { 1, "a", 3.14 }), t));
        }
        [TestMethod]
        public void Constructor()
        {
            var str = "Abc \"abc\" 42";
            DataParser.PValue.Parse(str).AssertSuccess(c =>
                Assert.AreEqual(new HConstructor("Abc", new HValue[]
                {
                    "abc",
                    42
                }), c));
        }
        [TestMethod]
        public void Unit()
        {
            Assert.IsTrue(DataParser.PValue.Parse("()").Success);
        }
    }
}
