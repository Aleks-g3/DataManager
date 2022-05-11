using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DataManager
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DataService service = new DataService(new DataProvider());
            var result = await service.Proccess();

            Console.WriteLine(result);
        }
    }
}
