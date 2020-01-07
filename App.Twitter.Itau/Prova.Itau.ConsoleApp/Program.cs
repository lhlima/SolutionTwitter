using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prova.Itau.ConsoleApp
{
    internal static class Program
    {
        private static List<string> hastags = new List<string>(new string[] {
                "#openbanking", "#apifirst", "#devops","cloudfirst",
                "#microservices", "#apigateway",
                "#oauth", "#swagger", "#raml", "#openapis"});

        static async Task Main(string[] args)
        {
            await Test.SendTest(); 

            foreach (var item in hastags)
            {
                await LoadDataTwitter.SearchTweet(item);
            }
            System.Console.WriteLine("Processo finalizado!");
        }  
    }
}
