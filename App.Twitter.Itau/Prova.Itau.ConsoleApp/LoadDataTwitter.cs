using System;
using TweetSharp;
using System.Threading.Tasks;

namespace Prova.Itau.ConsoleApp
{
    internal static class LoadDataTwitter
    {
        private static string customer_key = "";
        private static string customer_key_secret = "";
        private static string access_token = "";
        private static string access_token_secret = "";

        private static TwitterService service =
            new TwitterService(customer_key, customer_key_secret, access_token, access_token_secret);

        internal static async Task SearchTweet(string hastag)
        {
            service.AuthenticateWith(access_token, access_token_secret);

            int tweetCount = 1;
            var tweetsSearch = service.Search(new SearchOptions { Q = hastag, Resulttype = TwitterSearchResultType.Recent });

            foreach (var t in tweetsSearch.Statuses)
            {
                try
                {
                    System.Console.WriteLine("Sr. No: " + tweetCount + "\n" + t.User.Name + "\n" + t.User.ScreenName + "\n" + "https://twitter.com/intent/retweet? tweet_id=" + t.Id);
                    tweetCount++;
                    await PostTweet(t);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }

        internal static async Task PostTweet(TwitterStatus t)
        {
            try
            {
                Models.Twitter tweet = new Models.Twitter();
                tweet.Id = Convert.ToInt32(t.Id);
                tweet.ScreenName = t.User.ScreenName;
                tweet.Name = t.User.Name;
                tweet.Text = t.Text;
                tweet.RetweetCount = t.RetweetCount;
                tweet.FavouritesCount = t.User.FavouritesCount;
                tweet.CreatedDate = t.User.CreatedDate.ToString();

                await ConsoleApp.SendingData.RunAsync(tweet);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
