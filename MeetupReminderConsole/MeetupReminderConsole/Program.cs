using CSharp.Meetup.Connect;
using MeetupReminder.Core.Services;
using MeetupReminderConsole.Core.Services;
using Newtonsoft.Json.Linq;
using Spring.Social.OAuth1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetupReminderConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("What meetup do you want to know about?");
            string x = Console.ReadLine();
            var meetups = MeetupService.GetMeetupsFor(x).Result;
            Console.WriteLine("Please enter your sms number to receive text");
            var toNum = Console.ReadLine();
            var message = "Here are your requested meetups:";
           
            foreach (var oEvent in meetups)
            {
                message += "\nMeetup for you - " + oEvent;
            }

            Console.WriteLine();
            Console.WriteLine(message);
            SmsService.SendSms(toNum, message);
            Console.ReadLine();
        }
    }
}
