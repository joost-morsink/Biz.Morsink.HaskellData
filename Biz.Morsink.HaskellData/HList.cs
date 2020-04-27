using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Biz.Morsink.HaskellData
{
    public sealed class HList : HValue, IEnumerable<HValue>, IEquatable<HList>
    {
        public HList(IEnumerable<HValue> elements)
        {
            Elements = elements.ToImmutableList();
        }
        public ImmutableList<HValue> Elements { get; }
#pragma warning disable 168
        public bool Equals(HList other)
            => Elements.SequenceEqual(other.Elements);
            
        public override bool Equals(object? obj)
            => obj is HList other && Equals(other);
        public override int GetHashCode()
            => HashCode.Empty.AddRange(Elements);

        public static bool operator ==(HList left, HList right)
            => left.Equals(right);
        public static bool operator !=(HList left, HList right)
            => !left.Equals(right);

        public IEnumerator<HValue> GetEnumerator()
            => Elements.GetEnumerator();

        public override string ToString()
            => $"[{string.Join(",", Elements)}]";

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
