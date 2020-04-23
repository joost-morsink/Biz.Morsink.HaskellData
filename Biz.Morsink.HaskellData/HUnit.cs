namespace Biz.Morsink.HaskellData
{
    public class HUnit : HValue
    {
        public static HUnit Instance { get; } = new HUnit();
        public HUnit() { }

        public override string ToString()
            => "()";
    }
}
