using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio;

namespace MeetupReminder.Core.Services
{
    public class SmsService
    {
        private const string TwilioAccountSid = "AC46bd059d0e358e91f6a9b3cecfb8d565";
        private const string TwilioAuthToken = "f2b6ddef295dee3622cbc150d7b263a0";
        private const string FromNumber = "+17639511107";

        public static void SendSms(string to, string message)
        {
            var twilio = new TwilioRestClient(TwilioAccountSid, TwilioAuthToken);

            twilio.SendMessage(FromNumber, to, message);
        }
        public static void MakeACall(string to, string message)
        {
            var twilio = new TwilioRestClient(TwilioAccountSid, TwilioAuthToken);

            var co = new CallOptions();

            co.To = to;

            twilio.InitiateOutboundCall(co);
                {

            }
        }
    }

}
