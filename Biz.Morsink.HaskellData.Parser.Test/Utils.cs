using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pidgin;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biz.Morsink.HaskellData.Parser.Test
{
    public static class Utils
    {
        public static void AssertSuccess<S,T>(this Result<S,T> result, Action<T> test)
        {
            Assert.IsTrue(result.Success);
            test(result.Value);
        }
    }
}
