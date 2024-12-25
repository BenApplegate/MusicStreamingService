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
        
        
        //Close logger at end of program
        Logger.Close();
    }
}