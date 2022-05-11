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
        public async Task<string> Proccess()
        {
            using(HttpClient client = new HttpClient())
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
}
