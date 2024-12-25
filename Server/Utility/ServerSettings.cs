// Author: Benjamin Applegate
// Creation: 25/12/2024 00:41 AM MST
// Last Updated: 25/12/2024

// This file handles the creation and management of server settings loaded from a file

namespace Server.Utility;

public class ServerSettings
{
    private static string[] _settingsDefualts = ["databaseURI", "listenPort"];

    //Holds the key value pair settings loaded in from the file
    private static Dictionary<string, string> _settings = new();

    /// <summary>
    /// Initializes the settings system loading all info from file
    /// </summary>
    /// <returns>TRUE if all required data was found in file, FALSE if file was missing</returns>
    public static bool Init()
    {
        Logger.Info("Initializing settings loader");
        if (!File.Exists("server.settings"))
        {
            Logger.Warning("Failed to find server settings file, creating blank template");
            var file = File.CreateText("server.settings");
            foreach (var settings in _settingsDefualts)
            {
                file.WriteLine(settings + '=');
            }
            file.Flush();
            file.Close();
            return false;
        }
        Logger.Info("Server settings found, loading data");
        
        return true;
    }
}