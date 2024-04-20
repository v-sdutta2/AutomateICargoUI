using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading.Tasks;

namespace iCargoUIAutomation.utilities
{
    public class readDataFromAPI    {

        public async Task<string> GetDataFromApi(string url, string param1, string param2, string headerValue)
        {
            using (HttpClient client = new HttpClient())
            {
                // Add the header to the HttpClient
                client.DefaultRequestHeaders.Add("HeaderName", headerValue);

                // Add the parameters to the URL
                string fullUrl = $"{url}?param1={param1}&param2={param2}";

                HttpResponseMessage response = await client.GetAsync(fullUrl);

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    return data;
                }
                else
                {
                    throw new Exception($"Error: {response.StatusCode}");
                }
            }
        }

    }
}
