﻿using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Net.Http;
using System.Net.Http.Json; //Requires nuget package System.Net.Http.Json
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Text.Json;

//using Hello_World_Flyout.Models;
//using Hello_World_Flyout.Services;

namespace Hello_World_Flyout.Consoles
{
    //Your can move your Console application Main here. Rename Main to myMain and make it NOT static and async
    class Program
    {
        #region used by the Console
        Views.ConsolePage theConsole;
        StringBuilder theConsoleString;
        public Program(Views.ConsolePage myConsole)
        {
            //used for the Console
            theConsole = myConsole;
            theConsoleString = new StringBuilder();
        }
        #endregion
 
        #region Console Demo program
        //This is the method you replace with your async method renamed and NON static Main
        public async Task myMain()
        {
            theConsole.WriteLine("Demo program output");

            theConsole.WriteLine();
            theConsole.WriteLine("Application State variables:");
            theConsole.WriteLine($"Using Lazy<Globals>: Message: {Globals.Data.Message}   Time: {Globals.Data.Time}");
            theConsole.WriteLine($"Using static properties in App: Message: {App.Message}   Time: {App.Time}");
            theConsole.WriteLine($"Using Application Properties Dictionary: Message: {App.Current.Properties["Message"]}   " +
                $"Time: {App.Current.Properties["Time"]}");
            theConsole.WriteLine();

            theConsole.WriteLine("My State variables:");
            theConsole.WriteLine($"Citylist has {Globals.Data.Citylist.Count} elements");
            theConsole.WriteLine($"The first city is {Globals.Data.Citylist[0].Name}");
            theConsole.WriteLine();


            //Write an output to the Console
            theConsole.Write("One ");
            theConsole.Write("Two ");
            theConsole.WriteLine("Three and end the line");

            //As theConsole.WriteLine return trips are quite slow in UWP, use instead of myConsoleString to build the the more complex output
            //string using several myConsoleString.AppendLine instead of several theConsole.WriteLine. 
            foreach (char c in "Hello World from my Console program")
            {
                theConsoleString.Append(c);
            }

            //Once the string is complete Write it to the Console
            theConsole.WriteLine(theConsoleString.ToString());

            theConsole.WriteLine("Wait for 2 seconds...");
            await Task.Delay(2000);

            //Finally, demonstrating getting some data async
            theConsole.WriteLine("Download from https://dotnet.microsoft.com/...");
            theConsoleString.Clear();
            using (var w = new WebClient())
            {
                string str = await w.DownloadStringTaskAsync("https://dotnet.microsoft.com/");
                theConsoleString.Append($"Nr of characters downloaded: {str.Length}");
            }
            theConsole.WriteLine(theConsoleString.ToString());
        }

        //If you have any event handlers, they could be placed here
        void myEventHandler(object sender, string message)
        {
            theConsole.WriteLine($"Event message: {message}"); //theConsole is a Captured Variable, don't use myConsoleString here
        }
        #endregion
    }
}
