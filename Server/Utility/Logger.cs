// Author: Benjamin Applegate
// Creation: 24/12/2024 23:45 PM MST
// Last Updated: 25/12/2024

//This file runs our logger, it helps run different logging levels, and printing helpful debug info
//It also serves as a utility for creating and saving log files

using System.Diagnostics;

namespace Server.Utility;

public class Logger
{
    
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