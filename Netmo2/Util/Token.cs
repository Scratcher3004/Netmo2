using JsonDeserialize;
using System;
using System.Collections.Generic;
using System.Text;

namespace Netmo2.Util
{
    public class Token : SerializeableJsonObject
    {
        public string access_token = "";
        public string refresh_token = "";
        public int expires_in = 0;
        public int expire_in = 0;

        public string[] scope = new string[] { "" };

        public override SerializeableJsonObject CreateInstance()
        {
            return new Token();
        }

        public override SerializeableJsonObject GetObjectByJsonKey(string jsonKey)
        {
            return null;
        }

        public override object GetValueByJsonKey(string jsonKey)
        {
            switch (jsonKey)
            {
                case "access_token":
                    return access_token;

                case "refresh_token":
                    return refresh_token;

                case "expires_in":
                    return expires_in;

                case "expire_in":
                    return expire_in;

                case "scope":
                    return scope;
                
                default:
                    break;
            }
            return null;
        }

        public override void SetObjectByJsonKey(string jsonKey, SerializeableJsonObject obj)
        {
            return;
        }

        public override void SetValueByJsonKey(string jsonKey, object obj)
        {
            switch (jsonKey)
            {
                case "access_token":
                    access_token = (string)obj;
                    return;

                case "refresh_token":
                    refresh_token = (string)obj;
                    return;

                case "expires_in":
                    expires_in = (int)obj;
                    return;

                case "expire_in":
                    expire_in = (int)obj;
                    return;

                case "scope":
                    scope = (string[])obj;
                    return;

                default:
                    break;
            }
        }
    }
}