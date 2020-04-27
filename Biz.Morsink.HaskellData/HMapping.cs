using System;

namespace Biz.Morsink.HaskellData
{
    public sealed class HMapping : IEquatable<HMapping>
    {
        public HMapping(string name, HValue value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public HValue Value { get; }
        public override string ToString()
            => $"{Name}={Value}";

        public bool Equals(HMapping other)
            => Name == other.Name && Value == other.Value;
        public override bool Equals(object? obj)
            => obj is HMapping other && Equals(other);
        public override int GetHashCode()
            => HashCode.Empty.Add(Name).Add(Value);

        public static bool operator ==(HMapping left, HMapping right)
            => left.Equals(right);
        public static bool operator !=(HMapping left, HMapping right)
            => !left.Equals(right);
    }
}
