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
            const string consumerKey = "e037q3on2cD7hF7lKZq8sxGlt"; // The application's consumer key
            const string consumerSecret = "rfDAKEUcjH0J3XQJwMkh8xp1S7J9CUa5b3XKvas29ATfzeO9hJ"; // The application's consumer secret
            const string accessToken = "51491702-L4XExU1N71rZtyfYrXm8jTBUHxtlfYDUmpQ4DY6GB"; // The access token granted after OAuth authorization
            const string accessTokenSecret = "6xtYhJ7y3RjQ2yAIhepVYjdZQjYizOQ58tXwFljaEVIGb"; // The access token secret granted after OAuth authorization

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