using System;
using System.Buffers;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwait
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string url1 = "https://codeavecjonathan.com/res/pizzas1.json";
            string url2 = "https://codeavecjonathan.com/res/dummy.txt";
            
            Console.WriteLine("Téléchargement...");

            var displayTask = DisplayProgress();
            var downloadTask1 = DownloadData(url1);
            var downloadTask2 = DownloadData(url2);

            await downloadTask1;
            await downloadTask2;


            Console.WriteLine("FIN DU PROGRAMME");
            
           
        }

        static async Task DownloadData(string url)
        {
            var httpClient = new HttpClient();
            // string url = "https://codeavecjonathan.com/res/dummy.txt";
            var result = await httpClient.GetStringAsync(url);


            Console.WriteLine("Ok ->" + url);
        }


        static async Task DisplayProgress()
        {
            while (true)
            {
                await Task.Delay(500);
                Console.Write(".");
            }
        }
    }
}
