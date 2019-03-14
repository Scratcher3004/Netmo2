using System;
using System.Collections.Generic;
using System.Text;

namespace NetMo.Util
{
    public static class TimeHelpers
    {
        public static DateTime TimestampToDateTime(long timeStamp)
        {
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dt = dt.AddSeconds(timeStamp).ToLocalTime();
            return dt;
        }
    }
}
