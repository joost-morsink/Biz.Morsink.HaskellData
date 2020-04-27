using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace Biz.Morsink.HaskellData
{
    public abstract class HValue : IEquatable<HValue>
    {
        internal HValue() { }

        public static implicit operator HValue(string value) => new HString(value);
        public static implicit operator HValue(int value) => new HInt(value);
        public static implicit operator HValue(double value) => new HDouble(value);
        public static implicit operator HValue(HValue[] values) => new HList(values);
        public static implicit operator HValue(ImmutableList<HValue> values) => new HList(values);

        public abstract override string ToString();
        public abstract override bool Equals(object? obj);
        public abstract override int GetHashCode();

        public bool Equals(HValue other)
            => Equals((object)other);

        public static bool operator ==(HValue left, HValue right)
            => left.Equals(right);
        public static bool operator !=(HValue left, HValue right)
            => left.Equals(right);
    }
}
