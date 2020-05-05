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
                Assert.AreEqual(new HList(1, 2, 3), lst));
        }
        [TestMethod]
        public void Record()
        {
            var str = "Person { name=\"Joost\", age = 40 }";
            DataParser.PValue.Parse(str).AssertSuccess(rec =>
                Assert.AreEqual(new HRecord("Person",
                    ("name", "Joost"),
                    ("age", 40))
                , rec));
        }
        [TestMethod]
        public void Tuple()
        {
            var str = "(1,\"a\",3.14)";
            DataParser.PValue.Parse(str).AssertSuccess(t =>
                Assert.AreEqual(new HTuple(1, "a", 3.14), t));
        }
        [TestMethod]
        public void Constructor()
        {
            var str = "Abc \"abc\" 42";
            DataParser.PValue.Parse(str).AssertSuccess(c =>
                Assert.AreEqual(new HConstructor("Abc", "abc", 42), c));
        }
        [TestMethod]
        public void Unit()
        {
            Assert.IsTrue(DataParser.PValue.Parse("()").Success);
        }

        [TestMethod]
        public void Complex()
        {
            var str = "Abc [Def 12 (1, 3), Ghi { abc=123, def=() }]";
            DataParser.PValue.Parse(str).AssertSuccess(v =>
                Assert.AreEqual(
                    new HConstructor("Abc",
                        new HList(
                            new HConstructor("Def", 12, new HTuple(1, 3)),
                            new HRecord("Ghi",
                                ("abc",123),
                                ("def",HUnit.Instance)))),
                    v));
        }

        [TestMethod]
        public void ConstructorPrecedence()
        {
            var str = "Abc Def Ghi";
            DataParser.PValue.Parse(str).AssertSuccess(val =>
                Assert.AreEqual(
                    new HConstructor("Abc",
                        new HConstructor("Def"),
                        new HConstructor("Ghi")), val));
        }
    }
}
