using CSharp.Meetup.Connect;
using Newtonsoft.Json.Linq;
using Spring.Social.OAuth1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupReminderConsole.Core.Services
{
    public class MeetupService
    {
        private const string MeetupApiKey = "jm07k5us9pkkb36dciq9bemf69";
        private const string MeetupSecretKey = "k0b54tfkrhcbj0di0bamdmovgs";

        private static async Task<OAuthToken> authenticate()
        {
            var meetupServiceProvider = new MeetupServiceProvider(MeetupApiKey, MeetupSecretKey);
            //OAuth Dance//
            var oauthToken = await meetupServiceProvider.OAuthOperations.FetchRequestTokenAsync("oob", null);
            var authenticateUrl = meetupServiceProvider.OAuthOperations.BuildAuthorizeUrl(oauthToken.Value, null);
            Process.Start(authenticateUrl);

            Console.WriteLine("Enter the pin from meetup.com");
            string pin = Console.ReadLine();

            var requestToken = new AuthorizedRequestToken(oauthToken, pin);
            var oathAccessToken = meetupServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;

            return oathAccessToken;

        }

        public static async Task<List<string>> GetMeetupsFor(string meetupGroupName)
        {
            var token = await authenticate();
            var meetupServiceProvider = new MeetupServiceProvider(MeetupApiKey, MeetupSecretKey);
            var meetup = meetupServiceProvider.GetApi(token.Value, token.Secret);
            string json = await meetup.RestOperations.GetForObjectAsync<string>($"https://api.meetup.com/2/events?group_urlname={meetupGroupName}");
            var oEvents = JObject.Parse(json)["results"];
            List<string> MEvents = new List<string>();
            foreach (var oEvent in oEvents)
            {
                MEvents.Add(oEvent["name"].ToString());
            }

            return MEvents;
        }
    }
}