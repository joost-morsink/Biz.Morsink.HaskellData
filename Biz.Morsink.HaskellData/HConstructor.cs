using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Biz.Morsink.HaskellData
{
    public sealed class HConstructor : HValue, IEquatable<HConstructor>
    {
        public HConstructor(string name, IEnumerable<HValue> arguments)
        {
            Name = name;
            Arguments = arguments.ToImmutableList();
        }
        public string Name { get; }
        public ImmutableList<HValue> Arguments { get; }

        public override string ToString()
            => $"{Name} {string.Join(" ", Arguments.Select(Utils.ToParenthesizedString))}";

        public override bool Equals(object? obj)
            => obj is HConstructor other && Equals(other);
        public bool Equals(HConstructor other)
            => Name == other.Name && Arguments.SequenceEqual(other.Arguments);
        public override int GetHashCode()
            => HashCode.Empty.Add(Name).AddRange(Arguments);

        public static bool operator ==(HConstructor left, HConstructor right)
            => left.Equals(right);
        public static bool operator !=(HConstructor left, HConstructor right)
            => !left.Equals(right);
    }
}
