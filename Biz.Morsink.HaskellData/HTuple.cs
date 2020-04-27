using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Biz.Morsink.HaskellData
{
    public sealed class HTuple : HValue, IEquatable<HTuple>
    {
        public HTuple(IEnumerable<HValue> values)
        {
            Values = values.ToImmutableList();
        }
        public ImmutableList<HValue> Values { get; }
        public override string ToString()
            => $"({string.Join(",", Values)})";

        public bool Equals(HTuple other)
            => Values.SequenceEqual(other.Values);
        public override bool Equals(object? obj)
            => obj is HTuple other && Equals(other);
        public override int GetHashCode()
            => HashCode.Empty.AddRange(Values);

        public static bool operator ==(HTuple left, HTuple right)
            => left.Equals(right);
        public static bool operator !=(HTuple left, HTuple right)
            => !left.Equals(right);
    }
}
