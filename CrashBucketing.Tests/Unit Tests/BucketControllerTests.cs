using NUnit.Framework;
using CrashBucketing.Models;
using CrashBucketing.Controllers;
using Microsoft.Extensions.Logging;

namespace CrashBucketing.Tests.Unit_Tests
{   
    public class BucketControllerTests
    {
        BucketsController _controller;
        ILogger<BucketsController> _logger;
        public BucketControllerTests() {
            _logger = new LoggerFactory().CreateLogger<BucketsController>();
            _controller = new BucketsController(_logger);
        }

        [Test]
        public void getAllBuckets()
        {
            var buckets = _controller.Get();
            Assert.IsNotNull(buckets);
        }

        [Test]
        public void GetAllBuckets()
        {
            var buckets = _controller.Get();
            Assert.IsNotNull(buckets);
        }

        [Test]
        public void GetBucket()
        {
            var bucket = new Bucket();
            bucket.BucketID = 23423;

            Assert.IsNotNull(_controller.GetBucketDetails(bucket));
        }
        
        [Test]
        public void GetCrash()
        {
            Assert.IsNotNull(_controller.GetCrashById(23423, 1));
        }
    }
}