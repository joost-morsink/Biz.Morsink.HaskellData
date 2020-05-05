using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Biz.Morsink.HaskellData
{
    public sealed class HRecord : HValue, IEnumerable<HMapping>, IEquatable<HRecord>
    {
        public HRecord(string name, IEnumerable<HMapping> mappings)
        {
            Name = name;
            Mappings = mappings.ToImmutableSortedDictionary(m => m.Name, m => m);
        }
        public HRecord(string name, params (string, HValue)[] mappings)
            : this(name, mappings.Select(m => new HMapping(m.Item1, m.Item2)))
        { }
        public HRecord(string name, params HMapping[] mappings)
            : this(name, (IEnumerable<HMapping>) mappings)
        { }

        public string Name { get; }
        public ImmutableSortedDictionary<string,HMapping> Mappings { get; }
        public override string ToString()
            => $"{Name}{{{string.Join(",", Mappings.Values)}}}";
        public IEnumerator<HMapping> GetEnumerator()
            => Mappings.Values.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();

        public bool Equals(HRecord other)
            => Name == other.Name && Mappings.Count == other.Mappings.Count && Mappings.Values.SequenceEqual(other.Mappings.Values);
        public override bool Equals(object? obj)
            => obj is HRecord other && Equals(other);
        public override int GetHashCode()
            => HashCode.Empty.Add(Name).AddRange(Mappings.Values);

        public static bool operator ==(HRecord left, HRecord right)
            => left.Equals(right);
        public static bool operator !=(HRecord left, HRecord right)
            => !left.Equals(right);
    }
}
