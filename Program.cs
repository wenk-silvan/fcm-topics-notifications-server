using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace TestingNotificationsServer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var defaultApp = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "key.json")),
            });
            Console.WriteLine(defaultApp.Name); // "[DEFAULT]"

            var message = new Message()
            {
                Data = new Dictionary<string, string>()
                {
                    ["FirstName"] = "Silvan",
                    ["LastName"] = "Wenk"
                },
                Notification = new Notification
                {
                    Title = "Test From Server",
                    Body = "Hello World"
                },
                Topic = "project-gamma"
            };

            var messaging = FirebaseMessaging.DefaultInstance;
            var result = await messaging.SendAsync(message);
            Console.WriteLine(result);
        }
    }
}
