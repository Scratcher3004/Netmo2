using JsonDeserialize;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Netmo2.Util
{
    class Connector
    {
        private string deviceID;
        private Token CurrentToken;

        public Connector(string _clientid, string _clientsecret, string _username, string _password, string _deviceID)
        {
            deviceID = _deviceID;
            var nvc = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("client_id", _clientid),
                new KeyValuePair<string, string>("client_secret", _clientsecret),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", _username),
                new KeyValuePair<string, string>("password", _password)
            };

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsync("https://api.netatmo.com/oauth2/token", new FormUrlEncodedContent(nvc)).Result;
                if (!response.IsSuccessStatusCode)
                {
                    CurrentToken = null;
                    throw new Exception("Ein Fehler ist aufgetreten, der Token konnte nicht abgerufen werden." + response.StatusCode);
                }
                var strtoken = response.Content.ReadAsStringAsync().Result;
                CurrentToken = (Token)JsonDeserializer.TryDeserialze(strtoken, new Token());
            }
        }

        public NetAtmoResponse GetNetatmoWeatherData()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var kvp = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("access_token", CurrentToken.access_token),
                    new KeyValuePair<string, string>("device_id", deviceID) //70:ee:50:36:f0:2a
                };
                var response2 = client.PostAsync("https://api.netatmo.com/api/getstationsdata", new FormUrlEncodedContent(kvp));
                var datastr = response2.Result.Content.ReadAsStringAsync().Result;
                return (NetAtmoResponse)JsonDeserializer.TryDeserialze(datastr, new NetAtmoResponse());
            }
        }
    }
}
