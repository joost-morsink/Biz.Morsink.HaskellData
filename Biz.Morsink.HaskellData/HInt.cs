using System.Globalization;

namespace Biz.Morsink.HaskellData
{
    public class HInt : HValue
    {
        public HInt(int value)
        {
            Value = value;
        }
        public int Value { get; }
        public override string ToString()
            => Value.ToString(CultureInfo.InvariantCulture);
    }
}
