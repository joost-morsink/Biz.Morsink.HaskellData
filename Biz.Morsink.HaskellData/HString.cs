namespace Biz.Morsink.HaskellData
{
    public class HString : HValue
    {
        public HString(string value)
        {
            Value = value;
        }
        public string Value { get; }

        public override string ToString()
        {
            var input = Value;
            char[] res = new char[Value.Length * 2];
            int outp = 0;
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
                    default:
                        res[outp++] = input[inp];
                        break;
                }
            }
            return new string(res, 0, outp);
        }
    }
}
