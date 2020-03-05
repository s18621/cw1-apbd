using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Cw1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            
            var client = new HttpClient();
            var result = await client.GetAsync("http://www.pja.edu.pl");
            //Task<HttpResponseMessage>
            //ThreadPool()

            if (!result.IsSuccessStatusCode) return;

            string html = await result.Content.ReadAsStringAsync();
            var regex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+",RegexOptions.IgnoreCase);
            var matches = regex.Matches(html);

            foreach(var m in matches)
            {
                Console.WriteLine(m);
             
            }


            Console.WriteLine("Hello World!");
        }
    }
}
