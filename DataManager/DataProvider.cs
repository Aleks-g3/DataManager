using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public class DataProvider : IDataOparation
    {
        static readonly HttpClient client = new HttpClient();

        public async Task<string> Proccess()
        {
            var response = await client.GetAsync("https://catfact.ninja/fact");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Cannot fetching data");
            }

            return await response.Content.ReadAsStringAsync();
        }
    }
}
