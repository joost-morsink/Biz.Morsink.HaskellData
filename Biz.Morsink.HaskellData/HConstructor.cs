using System.Collections.Generic;
using System.Collections.Immutable;

namespace Biz.Morsink.HaskellData
{
    public class HConstructor : HValue
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
    }
}
