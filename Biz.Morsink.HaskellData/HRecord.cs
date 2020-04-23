using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Biz.Morsink.HaskellData
{
    public class HRecord : HValue, IEnumerable<HMapping>
    {
        public HRecord(string name, IEnumerable<HMapping> mappings)
        {
            Name = name;
            Mappings = mappings.ToImmutableList();
        }

        public string Name { get; }
        public ImmutableList<HMapping> Mappings { get; }
        public override string ToString()
            => $"{Name}{{{string.Join(",", Mappings)}}}";
        public IEnumerator<HMapping> GetEnumerator()
            => Mappings.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
