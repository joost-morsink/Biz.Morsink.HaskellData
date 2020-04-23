using System;
namespace Biz.Morsink.HaskellData
{
    internal static class Utils
    {
        public static string ToParenthesizedString(this HValue val)
            => val switch
            {
                HConstructor ctor => $"({ctor})",
                HRecord rec => $"({rec})",
                _ => val.ToString()
            };
    }
}
