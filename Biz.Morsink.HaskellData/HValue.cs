using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;

namespace Biz.Morsink.HaskellData
{
    public abstract class HValue
    {
        internal HValue() { }

        public static implicit operator HValue(string value) => new HString(value);
        public static implicit operator HValue(int value) => new HInt(value);
        public static implicit operator HValue(double value) => new HDouble(value);
        public static implicit operator HValue(HValue[] values) => new HList(values);
        public static implicit operator HValue(ImmutableList<HValue> values) => new HList(values);

        public abstract override string ToString();
    }
}
