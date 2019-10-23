using System.Collections.Generic;
using CrashBucketing.Models.Interfaces;
namespace CrashBucketing.Models {

    /// <summary>
    /// Bucket that implements the IBucket Interface
    /// </summary>
    public class Bucket : IBucket {
        public long? BucketID { get; set; }
        public List<ICrash> Crashes { get; set; }
        public long? CrashLimit { get; set; }

        public long? CrashCount { get; set; }
    }
}