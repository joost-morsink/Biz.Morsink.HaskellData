using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace Biz.Morsink.HaskellData
{
    public sealed class HDouble : HValue, IEquatable<HDouble>, IComparable<HDouble>
    {
        public HDouble(double value)
        {
            Value = value;
        }
        public double Value { get; }
        public override string ToString()
            => Value.ToString(CultureInfo.InvariantCulture);

        public int CompareTo(HDouble other)
            => Value.CompareTo(other.Value);
        public bool Equals(HDouble other)
            => Value == other.Value;
        public override bool Equals(object? obj)
            => obj is HDouble other && Equals(other);
        public override int GetHashCode()
            => Value.GetHashCode();

        public static bool operator ==(HDouble left, HDouble right)
            => left.Value == right.Value;
        public static bool operator !=(HDouble left, HDouble right)
            => left.Value != right.Value;
        public static implicit operator HDouble(double value)
            => new HDouble(value);
        public static implicit operator double(HDouble value)
            => value.Value;
    }
}
