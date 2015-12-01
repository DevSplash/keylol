﻿using System;
using System.ServiceProcess;

namespace Keylol.SteamBot
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                var service = new SteamBotService();
                service.ConsoleStartup(args);
            }
            else
            {
                var servicesToRun = new ServiceBase[]
                {
                    new SteamBotService()
                };
                ServiceBase.Run(servicesToRun);
            }
        }
    }
}