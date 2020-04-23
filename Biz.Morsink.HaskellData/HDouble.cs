using System.Globalization;

namespace Biz.Morsink.HaskellData
{
    public class HDouble : HValue
    {
        public HDouble(double value)
        {
            Value = value;
        }
        public double Value { get; }
        public override string ToString()
            => Value.ToString(CultureInfo.InvariantCulture);
    }
}
