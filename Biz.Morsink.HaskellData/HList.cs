using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Biz.Morsink.HaskellData
{
    public class HList : HValue, IEnumerable<HValue>
    {
        public HList(IEnumerable<HValue> elements)
        {
            Elements = elements.ToImmutableList();
        }
        public ImmutableList<HValue> Elements { get; }

        public IEnumerator<HValue> GetEnumerator()
            => Elements.GetEnumerator();

        public override string ToString()
            => $"[{string.Join(",", Elements)}]";

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
