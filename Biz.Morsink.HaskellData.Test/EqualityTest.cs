using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Biz.Morsink.HaskellData.Test
{
    [TestClass]
    public class EqualityTest
    {
        [TestMethod]
        public void ListEquality()
        {
            var left = new HList(new[] { new HInt(1), new HInt(2), new HInt(3) });
            var right = new HList(new[] { new HInt(1), new HInt(2), new HInt(3) });
            Assert.AreEqual(left, right);
            Assert.AreNotEqual(left, new HList(new[] { new HInt(1), new HInt(2) }));
            Assert.AreNotEqual(left, new HList(new[] { new HInt(1), new HInt(3), new HInt(2) }));
        }
        [TestMethod]
        public void PrimitiveEquality()
        {
            Assert.AreEqual(new HInt(1), new HInt(1));
            Assert.AreNotEqual(new HInt(1), new HInt(2));
            Assert.AreEqual(new HDouble(3.14), new HDouble(3.14));
            Assert.AreNotEqual(new HDouble(3.14), new HDouble(3.1415));
            Assert.AreEqual(new HString("abc"), new HString("abc"));
            Assert.AreNotEqual(new HString("abc"), new HString("def"));
        }
        [TestMethod]
        public void ConstructorEquality()
        {
            var left = new HConstructor("Test", new HValue[] { 1, "Abc", 3.14 });
            var right = new HConstructor("Test", new HValue[] { 1, "Abc", 3.14 });
            Assert.AreEqual(left, right);
            Assert.AreNotEqual(left, new HConstructor("SomethingElse", new HValue[] { 1, "Abc", 3.14 }));
            Assert.AreNotEqual(left, new HConstructor("Test", new HValue[] { 1, "Abc" }));
            Assert.AreNotEqual(left, new HConstructor("Test", new HValue[] { 1, "Def", 3.14 }));
        }
        [TestMethod]
        public void RecordEquality()
        {
            var left = new HRecord("Test", new[] { new HMapping("Abc", 123), new HMapping("Def", 3.14) });
            var right = new HRecord("Test", new[] { new HMapping("Abc", 123), new HMapping("Def", 3.14) });
            Assert.AreEqual(left, right);
            Assert.AreNotEqual(left, new HRecord("SomethingElse", new[] { new HMapping("Abc", 123), new HMapping("Def", 3.14) }));
            Assert.AreNotEqual(left, new HRecord("Test", new[] { new HMapping("Abc", 123), new HMapping("Ghi", 3.14) }));
            Assert.AreNotEqual(left, new HRecord("Test", new[] { new HMapping("Abc", 123), new HMapping("Def", 3.1415) }));
        }
        [TestMethod]
        public void TupleEquality()
        {
            var left = new HTuple(new HValue[] { 1, "abc", 3.14 });
            var right = new HTuple(new HValue[] { 1, "abc", 3.14 });
            Assert.AreEqual(left, right);
            Assert.AreNotEqual(left, new HTuple(new HValue[] { 1, "abc" }));
            Assert.AreNotEqual(left, new HTuple(new HValue[] { 1, "def", 3.14 }));

        }
    }
}
