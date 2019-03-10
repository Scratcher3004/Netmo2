//using JsonDeserialize;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NetMo.Util
{
    public class Connector
    {
        private string DeviceID { get; set; } =  "";
        public Token CurrentToken { get; private set; }
        private List<KeyValuePair<string, string>> AuthParameter { get; set; } = null;

        public void Update(string _clientid, string _clientsecret, string _username, string _password, string _deviceID)
        {
            DeviceID = _deviceID;
            AuthParameter = new List<KeyValuePair<string, string>>
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
                HttpResponseMessage response = client.PostAsync("https://api.netatmo.com/oauth2/token", new FormUrlEncodedContent(AuthParameter)).Result;
                if (!response.IsSuccessStatusCode)
                {
                    CurrentToken = null;
                    throw new Exception("Ein Fehler ist aufgetreten, der Token konnte nicht abgerufen werden." + response.StatusCode);
                }
                var strtoken = response.Content.ReadAsStringAsync().Result;
                CurrentToken = (Token) JsonConvert.DeserializeObject(strtoken);
            }
        }

        public Connector(string _clientid, string _clientsecret, string _username, string _password, string _deviceID)
        {
            DeviceID = _deviceID;
            AuthParameter = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("client_id", _clientid),
                new KeyValuePair<string, string>("client_secret", _clientsecret),
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", _username),
                new KeyValuePair<string, string>("password", _password)
            };
        }

        public async Task<bool> ReadTokenAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.PostAsync("https://api.netatmo.com/oauth2/token", new FormUrlEncodedContent(AuthParameter));
                if (!response.IsSuccessStatusCode)
                {
                    CurrentToken = null;
                    throw new Exception("Ein Fehler ist aufgetreten, der Token konnte nicht abgerufen werden." + response.StatusCode);
                }
                var strtoken = response.Content.ReadAsStringAsync().Result;
                CurrentToken = JsonConvert.DeserializeObject<Token>(strtoken);
                return CurrentToken != null ? true : false;
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
                    new KeyValuePair<string, string>("device_id", DeviceID) //70:ee:50:36:f0:2a
                };
                var response2 = client.PostAsync("https://api.netatmo.com/api/getstationsdata", new FormUrlEncodedContent(kvp)).Result;
                var datastr = response2.Content.ReadAsStringAsync().Result;
                return Newtonsoft.Json.JsonConvert.DeserializeObject<NetAtmoResponse>(datastr);
            }
        }

        private void RefreshToken()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.PostAsync("https://api.netatmo.com/oauth2/token", new FormUrlEncodedContent(AuthParameter)).Result;
                if (!response.IsSuccessStatusCode)
                {
                    CurrentToken = null;
                    throw new Exception("Ein Fehler ist aufgetreten, der Token konnte nicht abgerufen werden." + response.StatusCode);
                }
                var strtoken = response.Content.ReadAsStringAsync().Result;
                CurrentToken = (Token)JsonConvert.DeserializeObject(strtoken);
            }
        }

        public async Task<NetAtmoResponse> GetNetatmoWeatherDataAsync()
        {
   
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var kvp = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("access_token", CurrentToken.access_token),
                new KeyValuePair<string, string>("device_id", DeviceID) //70:ee:50:36:f0:2a
            };
            HttpResponseMessage response2 = await client.PostAsync("https://api.netatmo.com/api/getstationsdata", new FormUrlEncodedContent(kvp));
            var datastr = response2.Content.ReadAsStringAsync().Result;
            if (!response2.IsSuccessStatusCode)
            {
                RefreshToken();
                var response3 = await client.PostAsync("https://api.netatmo.com/api/getstationsdata", new FormUrlEncodedContent(kvp));
                datastr = response3.Content.ReadAsStringAsync().Result;
            }

            NetAtmoResponse data = JsonConvert.DeserializeObject<NetAtmoResponse>(datastr);
            return data;
        }

    }
}
