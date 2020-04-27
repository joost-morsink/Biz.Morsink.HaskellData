using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Biz.Morsink.HaskellData
{
    public struct HashCode
    {
        public static HashCode Empty => default;
        public uint _hash;
        private HashCode(uint hash)
        {
            _hash = hash;
        }
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public HashCode Add<T>(T o)
            where T : notnull
        {
            unchecked
            {
                return new HashCode(Rotate(_hash * 668265263, 13) + (uint)o.GetHashCode());
            }
        }
        public HashCode AddRange<T>(IEnumerable<T> elements)
            where T : notnull
        {
            var res = this;
            foreach (var e in elements)
                res = res.Add(e);
            return res;
        }

        private static uint Rotate(uint value, int by)
            => value << by | (value >> (32 - by));

        public static implicit operator int(HashCode hc)
            => (int)hc._hash;
    }
}
