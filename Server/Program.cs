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
        Thread.CurrentThread.Name = "Main Thread";
        
        Logger.Info("Test logger");
        Logger.Warning("This is a warning");
        Logger.Error("This is a test error");
        Logger.Debug("This is a test debug message");
    }
}