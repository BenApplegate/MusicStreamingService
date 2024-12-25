// Author: Benjamin Applegate
// Creation: 24/12/2024 22:36 PM MST
// Last Updated: 25/12/2024

//This file serves as the main entrypoint to the server,
//it sets up logging, and setting up other initial systems essential for running the server

using Server.Utility;

namespace Server;

class Program
{

    public static void Main(string[] args)
    {
        //Set main thread name and initialize system logging
        Thread.CurrentThread.Name = "Main Thread";
        Logger.Init();
        Logger.Info("Logger system initialized");
        
        //Load server settings
        if (!ServerSettings.Init())
        {
            Logger.Warning("Please fill out server settings and then relaunch server");
            Logger.Close();
            Environment.Exit(1);
        }
        
        Logger.Debug(ServerSettings.GetSetting("listenPort") ?? "Failed to get listenPort");
        Logger.Debug(ServerSettings.GetSetting("testFail") ?? "Failed to get testFail");
        
        //Close logger at end of program
        Logger.Close();
    }
}