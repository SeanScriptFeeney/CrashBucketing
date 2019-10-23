using System;
using CrashBucketing.Models.Interfaces;

namespace CrashBucketing.Models {
    
    /// <summary>
    /// Crash implements the ICrash interface
    /// </summary>
    public class Crash : ICrash {
        public long? CrashID { get; set; }
        public string Stacktrace { get; set; }
        public string AppName { get; set; }
        public string PlatformName { get; set; }
        public DateTime CrashTime { get; set; }
    }
}