// Author: Benjamin Applegate
// Creation: 24/12/2024 23:45 PM MST
// Last Updated: 25/12/2024

//This file runs our logger, it helps run different logging levels, and printing helpful debug info
//It also serves as a utility for creating and saving log files

using System.Diagnostics;

namespace Server.Utility;

public class Logger
{
    private static StreamWriter? _logFile;
    private static bool _logFailWarning = false;
    private static bool _closed = false;
    
    /// <summary>
    /// Initializes the logger including the logfile functionality
    /// </summary>
    public static void Init()
    {
        //Check if log directory exists, create it if not
        if (!Directory.Exists("logs"))
        {
            Warning("It looks like this may be the first boot of the server as the logger has not been initialized before, creating logs directory");
            Directory.CreateDirectory("logs");
        }

        string logfileName = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.log";
        _logFile = File.CreateText($"logs/{logfileName}");
        Info($"Log file created at logs/{logfileName}, logs from now on will appear in log files");
    }

    /// <summary>
    /// Closes logger functionality and shuts down log file creation
    /// </summary>
    public static void Close()
    {
        Info("Logger shutdown initiated, future logs will not be able to make use of logfile functionality");
        if (_logFile is not null)
        {
            _logFile.Flush();
            _logFile.Close();
            _logFile = null;
            _closed = true;
        }
        Info("Log file has been flushed and close");
    }

    private static void SendMessageToLogFile(string message)
    {
        if (_logFile is null && !_logFailWarning && !_closed)
        {
            _logFailWarning = true;
            Warning("The log file is not open and no logs will be in the log file");
            return;
        }
        _logFile?.WriteLine(message);
    }
    
    /// <summary>
    /// Prints an info log to the console and log file
    /// </summary>
    /// <param name="message">The message to log</param>
    public static void Info(string message)
    {
        DateTime now = DateTime.Now;
        //Get stack trace to print helpful info
        var stackTrace = new StackTrace();
        var frame = stackTrace.GetFrame(1);
        var method = frame?.GetMethod();
        var className = method?.DeclaringType?.Name ?? "<unknown_class>";
        var methodName = method?.Name ?? "<unknown_method>";
        
        SendMessageToLogFile($"[INFO] [{Thread.CurrentThread.Name}] [{className}.{methodName}()] ({now}): {message}");
        
        //Print info to console
        var oldColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"[INFO] [{Thread.CurrentThread.Name}] [{className}.{methodName}()] ({now}): {message}");
        Console.ForegroundColor = oldColor;
    }
    
    /// <summary>
    /// Prints a warning to the console and log file
    /// </summary>
    /// <param name="message">The warning to log</param>
    public static void Warning(string message)
    {
        DateTime now = DateTime.Now;
        //Get stack trace to print helpful info
        var stackTrace = new StackTrace();
        var frame = stackTrace.GetFrame(1);
        var method = frame?.GetMethod();
        var className = method?.DeclaringType?.Name ?? "<unknown_class>";
        var methodName = method?.Name ?? "<unknown_method>";
        
        SendMessageToLogFile($"[WARN] [{Thread.CurrentThread.Name}] [{className}.{methodName}()] ({now}): {message}");
        
        //Print info to console
        var oldColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"[WARN] [{Thread.CurrentThread.Name}] [{className}.{methodName}()] ({now}): {message}");
        Console.ForegroundColor = oldColor;
    }
    
    /// <summary>
    /// Prints an error to the console and log file
    /// </summary>
    /// <param name="message">The error to log</param>
    public static void Error(string message)
    {
        DateTime now = DateTime.Now;
        //Get stack trace to print helpful info
        var stackTrace = new StackTrace();
        var frame = stackTrace.GetFrame(1);
        var method = frame?.GetMethod();
        var className = method?.DeclaringType?.Name ?? "<unknown_class>";
        var methodName = method?.Name ?? "<unknown_method>";
        
        SendMessageToLogFile($"[ERROR] [{Thread.CurrentThread.Name}] [{className}.{methodName}()] ({now}): {message}");
        
        //Print info to console
        var oldColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"[ERR] [{Thread.CurrentThread.Name}] [{className}.{methodName}()] ({now}): {message}");
        Console.ForegroundColor = oldColor;
    }
    
    /// <summary>
    /// Prints a debug message to the console and log file
    /// </summary>
    /// <param name="message">The debug message to log</param>
    public static void Debug(string message)
    {
        DateTime now = DateTime.Now;
        //Get stack trace to print helpful info
        var stackTrace = new StackTrace();
        var frame = stackTrace.GetFrame(1);
        var method = frame?.GetMethod();
        var className = method?.DeclaringType?.Name ?? "<unknown_class>";
        var methodName = method?.Name ?? "<unknown_method>";
        
        SendMessageToLogFile($"[DEBUG] [{Thread.CurrentThread.Name}] [{className}.{methodName}()] ({now}): {message}");
        
        //Print info to console
        var oldColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"[DEBUG] ");
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"[{Thread.CurrentThread.Name}] ");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write($"[{className}.{methodName}()] ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"({now}): {message}");
        Console.ForegroundColor = oldColor;
    }
}