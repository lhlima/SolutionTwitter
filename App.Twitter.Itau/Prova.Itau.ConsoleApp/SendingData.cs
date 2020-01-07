using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using TweetSharp;
using System.Text;

namespace Prova.Itau.ConsoleApp
{
    internal class SendingData
    {
        static HttpClient client = new HttpClient();

        internal static async Task RunAsync(Models.Twitter tweet)
        {
            try
            {
                client.BaseAddress = new Uri("http://localhost:38001/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add( 
                new MediaTypeWithQualityHeaderValue("application/json"));
                
                await ProcessTwitter(tweet);    
            }
            catch (System.Exception)
            {
                throw;
            }
            
        }

        internal static async Task ProcessTwitter(Models.Twitter tweet)
        {
            try
            {
                var serializedTweet = JsonConvert.SerializeObject(tweet);
                var content = new StringContent(serializedTweet, Encoding.UTF8, "application/json");
                var result = await client.PostAsync("http://localhost:38001/api/", content);
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}