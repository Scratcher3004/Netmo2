//using JsonDeserialize;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetMo.Util
{
    public class Token
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public List<string> scope { get; set; }
        public int expires_in { get; set; }
        public int expire_in { get; set; }
    }

}