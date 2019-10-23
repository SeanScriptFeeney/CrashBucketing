using System;

namespace CrashBucketing.Models.Interfaces 
{
    /// <summary>
    /// An interface to reference a Crash
    /// </summary>
    public interface ICrash
    {
        long? CrashID { get; set; }
        string Stacktrace  { get; set; }
        string AppName  { get; set; }
        string PlatformName  { get; set; }
        DateTime CrashTime { get; set; }
    }
}