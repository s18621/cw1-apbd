using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Cw1
{
    public class Student
    {
        public string Imie { get; set; }

        private string _nazwisko;

        public string Nazwisko
        {
            get { return _nazwisko; }
            set
            {
                if (value == null) throw new ArgumentException();
                _nazwisko = value;
            }
        }

    }

    public class Program
    {
        public static async Task Main(string[] args)
        {
            string url = args.Length > 0 ? args[0] : "http://www.pja.edu.pl";

            try {
            var client = new HttpClient();
            var result = await client.GetAsync(url);
            //Task<HttpResponseMessage>
            //ThreadPool()

            if (!result.IsSuccessStatusCode) return;

            //Kolekcje
            var zbiory = new HashSet<string>();
            var list = new List<string>();
            var slownik = new Dictionary<string, int>();

                var znalezione = from e in list where e.StartsWith("A") select e;

                var znalezione2 = list.Where(s => s.StartsWith("A"));


            string html = await result.Content.ReadAsStringAsync();
            var regex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+", RegexOptions.IgnoreCase);
            var matches = regex.Matches(html);

            foreach (var m in matches)
            {
                Console.WriteLine(m);

            }
             

        }catch(Exception exc)
            {
                //string s = string.Format("Wystapil blad {0}", exc.ToString());
                Console.WriteLine($"Wystapol blad {exc.ToString()}");
            }


            Console.WriteLine("Hello World!");
        }
    }
}
