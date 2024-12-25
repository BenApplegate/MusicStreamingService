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
            StreamWriter file = File.CreateText("server.settings");
            foreach (var settings in _settingsDefualts)
            {
                file.WriteLine(settings + '=');
            }
            file.Flush();
            file.Close();
            return false;
        }
        Logger.Info("Server settings found, loading data");

        //Read file line by line to parse settings
        string[] settingsContents = File.ReadAllLines("server.settings");
        Logger.Info($"Found {settingsContents.Length} settings:");
        foreach (var setting in settingsContents)
        {
            var split = setting.Split('=');
            _settings[split[0]] = split[1];
            Logger.Info($"Setting {split[0]} = {split[1]}");
        }
        
        return true;
    }

    /// <summary>
    /// Gets a setting from the stored setting values
    /// </summary>
    /// <param name="setting">The setting key to request</param>
    /// <returns>Returns the found value, or null if key was not found in settings file</returns>
    public static string? GetSetting(string setting)
    {
        if (!_settings.ContainsKey(setting))
        {
            Logger.Warning($"Requested setting key {setting} was not found in the logfile");
            return null;
        }

        return _settings[setting];
    }
}