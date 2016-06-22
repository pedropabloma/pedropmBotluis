using System.Collections.Generic;
using System.Linq;
using Tweetinvi;
using Tweetinvi.Core.Interfaces;

namespace BotAndLuisDemo
{
    public static class TwitterService
    {
        static TwitterService()
        {
            const string consumerKey = "pon la tuya"; // The application's consumer key
            const string consumerSecret = "pon la tuya"; // The application's consumer secret
            const string accessToken = "pon la tuya"; // The access token granted after OAuth authorization
            const string accessTokenSecret = "pon la tuya"; // The access token secret granted after OAuth authorization

            Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);
        }

        public static IUser GetUser(string name)
        {
            return User.GetUserFromScreenName(name);
        }

        public static IEnumerable<ITweet> GetKeyword(string keyword)
        {

            return Search.SearchTweets(keyword).Take(30);
            //return Search.SearchTweets(keyword).Take(3);
        }
    }
}
