using System.Collections.Generic;

namespace CrashBucketing.Models.Interfaces {
    
    /// <summary>
    /// Interface to represent a Crash Bucket
    /// </summary>
    public interface IBucket {
        long? BucketID { get; set; }
        List<ICrash> Crashes { get; set; }
        long? CrashLimit { get; set; }
        long? CrashCount { get; set; }
    }
}