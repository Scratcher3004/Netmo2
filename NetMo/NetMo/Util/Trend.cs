using System;
using System.Collections.Generic;
using System.Text;

namespace NetMo.Util
{
    static class Trend
    {
        public static readonly string TRENDGLEICHICON = "trend_gleich.png";
        public static readonly string TRENDDOWNICON = "trend_runter.png";
        public static readonly string TRENDUPICON = "trend_rauf.png";

        public static string GetTrend(string trend) { return trend == "stable" ? TRENDGLEICHICON : (trend == "up" ? TRENDUPICON : TRENDDOWNICON); }

    }
}
