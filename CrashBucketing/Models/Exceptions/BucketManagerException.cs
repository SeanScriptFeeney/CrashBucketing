using System;
using System.Runtime.Serialization;

namespace CrashBucketing.Models.Exceptions
{
    /// <summary>
    /// Custom Exception used in the Bucket Manager for
    /// error handling. 
    /// </summary>
    public class BucketManagerException : Exception
    {
        public BucketManagerException()
        {
        }

        public BucketManagerException(string message) : base(message)
        {
        }

        public BucketManagerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected BucketManagerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}