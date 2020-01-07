using System.Threading.Tasks;

namespace Prova.Itau.ConsoleApp
{
    static class Test
    {
        public static async Task SendTest()
        {
            Models.Twitter tweet = new Models.Twitter();
            //tweet.Id = Convert.ToInt32(t.Id);
            tweet.ScreenName = "Luis Lima";
            tweet.Name = "lhlima";
            tweet.Text = "#devops";
            tweet.RetweetCount = 1;
            tweet.FavouritesCount = 1;
            tweet.CreatedDate = "10/10/2019";
        
            await SendingData.ProcessTwitter(tweet);
        }
    }
}