using System.Collections.Generic;
using CrashBucketing.Models;
using CrashBucketing.Models.Interfaces;

namespace CrashBucketing.Utils
{
    public interface IBucketManager
    {
         List<IBucket> GetAllBuckets();
         IBucket GetBucket(IBucket bucket);
         ICrash GetCrash(long? bucketId, long? crashId);
    }
}