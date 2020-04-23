using System;
using System.Collections.Generic;
using System.Linq;
using Pidgin;
using static Pidgin.Parser;
using static Pidgin.Parser<char>;

namespace Biz.Morsink.HaskellData.Parser
{
    public static class DataParser
    {
        public static Parser<char, string> StringResult<T>(this Parser<char, T> parser)
            where T : IEnumerable<char>
            => parser.Select(chars => new string(chars.ToArray()));
        public static Parser<char, T> DoubleQuoted<T>(this Parser<char, T> parser) => parser.Between(Char('"'));
        public static Parser<char, T> InCurlyBraces<T>(this Parser<char, T> parser) => parser.Between(Char('{'), Char('}'));
        public static Parser<char, T> Parenthesized<T>(this Parser<char, T> parser) => parser.Between(Char('('), Char(')'));
        public static Parser<char, T> InSquareBrackets<T>(this Parser<char, T> parser) => parser.Between(Char('['), Char(']'));
        public static Parser<char, T> Whitespaced<T>(this Parser<char, T> parser) => parser.Between(SkipWhitespaces);
        public static Parser<char, HInt> PInt = Int(10).Select(i => new HInt(i)).Whitespaced();
        public static Parser<char, HDouble> PDouble = Real.Select(r => new HDouble(r)).Whitespaced();
        public static Parser<char, char> EscapedChar(char escape, char production) => Char('\\').Then(Char(escape)).Select(_ => production);
        public static Parser<char, char> PStringNewline = EscapedChar('n', '\n');
        public static Parser<char, char> PStringCarriageReturn = EscapedChar('r', '\r');
        public static Parser<char, char> PStringTab = EscapedChar('t', '\t');
        public static Parser<char, char> PStringSingleQuote = EscapedChar('\'', '\'');
        public static Parser<char, char> PStringDoubleQuote = EscapedChar('"', '\"');
        public static Parser<char, char> PStringSlash = EscapedChar('\\', '\\');
        public static Parser<char, char> PStringEscaped = PStringNewline.Or(PStringCarriageReturn).Or(PStringTab).Or(PStringSingleQuote).Or(PStringDoubleQuote).Or(PStringSlash);
        public static Parser<char, char> PStringChar = Token(x => x != '"' && x != '\\').Or(PStringEscaped);
        public static Parser<char, string> PIdentifier = Map((x, xs) => x + xs, Letter, LetterOrDigit.ManyString()).Whitespaced();
        public static Parser<char, HString> PString = PStringChar.ManyString().DoubleQuoted().Select(s => new HString(s)).Whitespaced();
        public static Parser<char, HValue> PAtom = PInt.Select(i => (HValue)i).Or(PString.Select(s => (HValue)s)).Or(PDouble.Select(d => (HValue)d));
        public static Parser<char, HValue> PValue = null!;

        public static Parser<char, HConstructor> PConstructor = from cname in PIdentifier
                                                                    from args in Rec(() => PValue).Separated(SkipWhitespaces)
                                                                    select new HConstructor(cname, args);
        public static Parser<char, HMapping> PMapping = from id in PIdentifier
                                                        from val in Char('=').Then(Rec(() => PValue))
                                                        select new HMapping(id, val);

        public static Parser<char, HRecord> PRecord = from rname in PIdentifier
                                                      from mappings in PMapping.Separated(Char(',')).InCurlyBraces()
                                                      select new HRecord(rname, mappings);
        public static Parser<char, HList> PList = Rec(() => PValue).Separated(Char(',')).InSquareBrackets().Select(vs => new HList(vs));
        public static Parser<char, HUnit> PUnit = String("()").Select(_ => HUnit.Instance).Whitespaced();
        public static Parser<char, HTuple> PTuple = Rec(() => PValue).Separated(Char(',')).Parenthesized().Select(vs => new HTuple(vs));

        static DataParser()
        {
            PValue = PAtom
                .Or(Try(PConstructor.Select(c => (HValue)c))
                    .Or(PRecord.Select(r => (HValue)r)))
                .Or(PList.Select(l => (HValue)l))
                .Or(Try(PUnit.Select(u => (HValue)u))
                    .Or(PTuple.Select(t => (HValue)t)));
        }
    }
}
