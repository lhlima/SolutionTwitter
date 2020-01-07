using System;
using System.Collections.Generic;
using TweetSharp;

namespace App.Console.Twitter.Itau
{
    class Program
    {
        private static string customer_key = "";
        private static string customer_key_secret = "";
        private static string access_token = "";
        private static string access_token_secret = "";

        private static TwitterService service = 
            new TwitterService(customer_key, customer_key_secret, access_token, access_token_secret);

        private static List<string> hastags = 
            new List<string>(new string[] { 
                "#openbanking", "#apifirst", "#devops","cloudfirst", 
                "#microservices", "#apigateway", 
                "#oauth", "#swagger", "#raml", "#openapis" 
            });

        static void Main(string[] args)
        {
            foreach (var item in hastags)
            {
                SearchTweet(item);
            }
            System.Console.WriteLine("Processo finalizado!");
        }

        private static void SearchTweet(string hastag)
        {
            service.AuthenticateWith(access_token, access_token_secret);

            int tweetCount = 1;
            var tweetsSearch = service.Search(new SearchOptions { Q = hastag, Resulttype = TwitterSearchResultType.Recent });

            foreach (var tweet in tweetsSearch.Statuses)
            {
                try
                {
                    //tweet.User.ScreenName;  
                    //tweet.User.Name;   
                    //tweet.Text; // Tweet text  
                    //tweet.RetweetCount; //No of retweet on twitter  
                    //tweet.User.FavouritesCount; //No of Fav mark on twitter  
                    //tweet.User.ProfileImageUrl; //Profile Image of Tweet  
                    //tweet.CreatedDate; //For Tweet posted time  
                    //"https://twitter.com/intent/retweet?tweet_id=" + tweet.Id;  //For Retweet  
                    //"https://twitter.com/intent/tweet?in_reply_to=" + tweet.Id; //For Reply  
                    //"https://twitter.com/intent/favorite?tweet_id=" + tweet.Id; //For Favorite  
                    
                    System.Console.WriteLine("Sr. No: " + tweetCount + "\n" + tweet.User.Name + "\n" + tweet.User.ScreenName + "\n" + "https://twitter.com/intent/retweet? tweet_id=" + tweet.Id);
                    tweetCount++;
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }

        private static void SendTweet(string _status)
        {
            service.SendTweet(new SendTweetOptions { Status = _status }, (tweet, response) =>
            {
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    System.Console.ForegroundColor = ConsoleColor.Green;
                    System.Console.WriteLine($"<{DateTime.Now}> - Tweet Sent!");
                    System.Console.ResetColor();
                }
                else
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine($"<ERROR> " + response.Error.Message);
                    System.Console.ResetColor();
                }
            });
        }
    }
}
