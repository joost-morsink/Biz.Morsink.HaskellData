namespace Biz.Morsink.HaskellData
{
    public class HMapping
    {
        public HMapping(string name, HValue value)
        {
            Name = name;
            Value = value;
        }

        public string Name { get; }
        public HValue Value { get; }
        public override string ToString()
            => $"{Name}={Value}";
    }
}
