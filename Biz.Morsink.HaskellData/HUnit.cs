using System;

namespace Biz.Morsink.HaskellData
{
    public sealed class HUnit : HValue, IEquatable<HUnit>
    {
        public static HUnit Instance { get; } = new HUnit();
        public HUnit() { }

        public override string ToString()
            => "()";

        public bool Equals(HUnit other)
            => true;
        public override bool Equals(object? obj)
            => obj is HUnit;
        public override int GetHashCode()
            => 0;

        public static bool operator ==(HUnit left, HUnit right)
            => true;
        public static bool operator !=(HUnit left, HUnit right)
            => false;
    }
}
