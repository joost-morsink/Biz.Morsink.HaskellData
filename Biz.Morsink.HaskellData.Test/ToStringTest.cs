using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biz.Morsink.HaskellData.Test
{
    [TestClass]
    public class ToStringTest
    {
        [TestMethod]
        public void String()
        {
            Assert.AreEqual(@"""Abc""", new HString("Abc").ToString());
            Assert.AreEqual(@"""\\A\tb\nc\\""", new HString("\\A\tb\nc\\").ToString());
        }
    }
}
