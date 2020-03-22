using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DPER_App.Services;
using System.Diagnostics;
using vdivsvirus.Types;
using Newtonsoft.Json.Linq;

namespace DPER_App.Models
{
    public class RestClient : IBackendSymptome, IBackendFinding
    {
        HttpClient _client;
        const string Url = "http://dper.us-east-1.elasticbeanstalk.com/api";

        public RestClient()
        {
            _client = new HttpClient();
        }

        #region symptomeAPI
        public async Task<List<SymptomeIdentData>> GetSymptomesAsync()
        {
            var uri = new Uri(Url+ "/symptome/GetSymptomeTypes");
            var Items = new List<SymptomeIdentData>();

            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Items = JsonConvert.DeserializeObject<List<SymptomeIdentData>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return Items;
        }

        public async Task SendSymptomeDataSetAsync(SymptomeInputDataSet symptomes)
        {
            var uri = new Uri(Url + "/symptome/SendSymptomeDataSet");

            try
            {
                var json = JsonConvert.SerializeObject(symptomes);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);
                
                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }

        public async Task SendDiseaseDataSetAsync(Guid userId, DiseaseDataSet disease)
        {
            var uri = new Uri(Url + "/symptome/SendDiseaseDataSet");

            try
            {
                JArray array = new JArray();
                array.Add(userId);
                array.Add(disease);

                JObject o = new JObject(array);

                string json = o.ToString();
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                response = await _client.PostAsync(uri, content);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"\tTodoItem successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }
        }
        #endregion

        #region findingAPI
        public async Task<bool> NewFindingAvailable(Guid id, DateTime time)
        {
            var uri = new Uri(Url + "/symptome/GetSymptomeTypes");
            var res = false;

            try
            {
                JArray array = new JArray();
                array.Add(id);
                array.Add(time);

                JObject o = new JObject(array);

                string json = o.ToString();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = uri,
                    Content = new StringContent(json, Encoding.UTF8, "application/json"),
                };

                var response = await _client.SendAsync(request).ConfigureAwait(false); ;
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<bool>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return res;
        }

        public async Task<UserResponseDataSet> RequestFinding(Guid id, DateTime time)
        {
            var uri = new Uri(Url + "/symptome/GetSymptomeTypes");
            UserResponseDataSet res = null;

            try
            {
                JArray array = new JArray();
                array.Add(id);
                array.Add(time);

                JObject o = new JObject(array);

                string json = o.ToString();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = uri,
                    Content = new StringContent(json, Encoding.UTF8, "application/json"),
                };

                var response = await _client.SendAsync(request).ConfigureAwait(false); ;
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<UserResponseDataSet>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return res;
        }

        public async Task<UserHistoryDataSet> RequestFindingHistory(Guid id)
        {
            var uri = new Uri(Url + "/symptome/GetSymptomeTypes");
            UserHistoryDataSet res = null;

            try
            {
                JObject o = new JObject(id);

                string json = o.ToString();
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = uri,
                    Content = new StringContent(json, Encoding.UTF8, "application/json"),
                };

                var response = await _client.SendAsync(request).ConfigureAwait(false); ;
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    res = JsonConvert.DeserializeObject<UserHistoryDataSet>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            return res;
        }
        #endregion
    }
}
