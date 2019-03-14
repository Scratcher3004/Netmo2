using System;
using System.Collections.Generic;
using System.Text;

namespace NetMo.Util.Translation
{
    public static class Helpers
    {
        public static string GetTrendEng(string trend) { return trend == "stable" ? "Stable" : (trend == "up" ? "Growing" : "Sinking"); }
    }
}
