using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupReminder.Core.Services
{
    public class MeetupService
    {
        private const string meetupApiKey = "b4924534461444612382b7d11414c41";
        private const string meetSecretKey = "k0b54tfkrhcbj0di0bamdmovgs";

        private static async Task<OAuthToken> authenticate()
        {
            var meetupServiceProvider = new MeetupServiceProvider(meetupApiKey, meetSecretKey)

                //OAuth Dance//

            var oauthToken = meetupServiceProvider.OAuthOperations.
                FetchRequestTokenAsync("oob", null.)Result;
            var authenticateUrl = meetupServiceProvider.OAuthOperations.BuildAuthorizeUrl(oauthToken.Value, null);

            Process.Start(authenticateUrl);


        }
    }


}
