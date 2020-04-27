using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Biz.Morsink.HaskellData
{
    public sealed class HInt : HValue, IComparable<HInt>
    {
        public HInt(int value)
        {
            Value = value;
        }
        public int Value { get; }

        public int CompareTo(HInt other)
            => Value.CompareTo(other.Value);

        public bool Equals(HInt other)
            => Value == other.Value;
        public override bool Equals(object? obj)
            => obj is HInt @int
            && Equals(@int);
        public override int GetHashCode()
            => Value.GetHashCode();

        public override string ToString()
            => Value.ToString(CultureInfo.InvariantCulture);

        public static bool operator ==(HInt left, HInt right)
            => left.Value == right.Value;
        public static bool operator !=(HInt left, HInt right)
            => left.Value != right.Value;
        public static implicit operator HInt(int value)
            => new HInt(value);
        public static implicit operator int(HInt value)
            => value.Value;
    }
}
