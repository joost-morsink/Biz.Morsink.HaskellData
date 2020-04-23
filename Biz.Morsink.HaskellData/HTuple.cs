using System.Collections.Generic;
using System.Collections.Immutable;

namespace Biz.Morsink.HaskellData
{
    public class HTuple : HValue
    {
        public HTuple(IEnumerable<HValue> values)
        {
            Values = values.ToImmutableList();
        }
        public ImmutableList<HValue> Values { get; }
        public override string ToString()
            => $"({string.Join(",", Values)})";
    }
}
