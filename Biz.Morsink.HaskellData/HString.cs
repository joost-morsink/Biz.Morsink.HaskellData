using System;

namespace Biz.Morsink.HaskellData
{
    public sealed class HString : HValue, IEquatable<HString>, IComparable<HString>
    {
        public HString(string value)
        {
            Value = value;
        }
        public string Value { get; }

        public override string ToString()
        {
            var input = Value;
            char[] res = new char[Value.Length * 2+2];
            
            int outp = 0;
            res[outp++] = '"';
            for (int inp = 0; inp < input.Length; inp++)
            {
                switch (input[inp])
                {
                    case '\n':
                        res[outp++] = '\\';
                        res[outp++] = 'n';
                        break;
                    case '\r':
                        res[outp++] = '\\';
                        res[outp++] = 'r';
                        break;
                    case '\'':
                        res[outp++] = '\\';
                        res[outp++] = '\'';
                        break;
                    case '\t':
                        res[outp++] = '\\';
                        res[outp++] = 't';
                        break;
                    case '\"':
                        res[outp++] = '\\';
                        res[outp++] = '"';
                        break;
                    case '\\':
                        res[outp++] = '\\';
                        res[outp++] = '\\';
                        break;
                    default:
                        res[outp++] = input[inp];
                        break;
                }
            }
            res[outp++] = '"';
            return new string(res, 0, outp);
        }
        public int CompareTo(HString other)
            => Value.CompareTo(other.Value);
        public bool Equals(HString other)
            => Value == other.Value;
        public override bool Equals(object? obj)
            => obj is HString other && Equals(other);
        public override int GetHashCode()
            => Value.GetHashCode();

        public static bool operator ==(HString left, HString right)
            => left.Value == right.Value;
        public static bool operator !=(HString left, HString right)
            => left.Value != right.Value;
        public static implicit operator HString(string value)
            => new HString(value);
        public static implicit operator string(HString value)
            => value.Value;
    }
}
