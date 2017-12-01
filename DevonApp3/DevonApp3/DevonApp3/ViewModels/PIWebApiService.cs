using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DevonApp3.ViewModels
{
    public class PIWebApiService
    {
        private string baseUrl = "https://pi.dvnhackathon.com/piwebapi/ ";
        private string piDataArchiveName = "OSISOFTPI-001";
        private string username = "hacker";
        private string password = "Pa$$w0rd";


        public async Task<string> DownloadWebData(string url)
        {
            var handler = new HttpClientHandler();
            handler.Credentials = new NetworkCredential(username, password);
            HttpClient httpClient = new HttpClient(handler);
            HttpResponseMessage httpMessage = await httpClient.GetAsync(url);
            if (httpMessage.IsSuccessStatusCode == true)
            {
                using (var stream = await httpMessage.Content.ReadAsStreamAsync())
                {
                    using (var streamReader = new StreamReader(stream))
                    {
                        return await streamReader.ReadToEndAsync();
                    }
                }
            }
            return string.Empty;
        }




        public async Task<double> GetSinusoidValue()
        {
            string url = string.Format(baseUrl + "points?path=\\\\{0}\\sinusoid", piDataArchiveName);
            string response = await DownloadWebData(url);
            JObject data = JsonConvert.DeserializeObject<dynamic>(response);
            string webId = data["WebId"].ToString();
            url = string.Format(baseUrl + "streams/{0}/value", webId);
            response = await DownloadWebData(url);
            JObject dataValue = JsonConvert.DeserializeObject<dynamic>(response);
            double value = Convert.ToDouble(dataValue["Value"].ToString());
            return value;
        }
    }
}
