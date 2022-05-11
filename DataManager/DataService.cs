using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManager
{
    public class DataService : IDataOparation
    {
        private readonly DataProvider provider;

        public DataService(DataProvider provider)
        {
            this.provider = provider;
        }
        public async Task<string> Proccess()
        {
            var message = await provider.Proccess();

            if (string.IsNullOrWhiteSpace(message))
            {
                throw new Exception("Data is empty");
            }

            SaveData(message);

            return message;
        }

        private void SaveData(string message)
        {
            using (StreamWriter file = new StreamWriter($"{Environment.CurrentDirectory}\\messages.txt ", true))
            {
                file.WriteLine(message);

                file.Close();
            }
        }
    }
}
