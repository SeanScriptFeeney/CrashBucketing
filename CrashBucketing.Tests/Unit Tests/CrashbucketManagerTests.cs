using NUnit.Framework;
using CrashBucketing.Utils;
using CrashBucketing.Models;
using CrashBucketing.Models.Exceptions;

namespace CrashBucketing.Unit_Tests.CrashbucketManagerTests
{
    [TestFixture]
    public class CrashbucketManagerTests
    {
        public IBucketManager bucketManager { get; set; }

        [OneTimeSetUp]
        public void Init()
        { 
            bucketManager = new BucketManager();
        }

        [Test]
        public void BucketsAreNotEmpty()
        {
            Assert.IsTrue(bucketManager.GetAllBuckets().Count > 0);
        }

        [Test]
        public void GetBucket()
        {
            var bucket = new Bucket();
            bucket.BucketID = 23423;

            Assert.IsNotNull(bucketManager.GetBucket(bucket));
        }

        [Test]
        public void BucketDoesNotExist()
        {
            var bucket = new Bucket();

            Assert.IsNull(bucketManager.GetBucket(bucket).BucketID);
        }
        
        [Test]
        public void GetCrash()
        {
            Assert.IsNotNull(bucketManager.GetCrash(23423, 1));
        }

        [Test]
        public void GetCrashDoesNotExist()
        {
            Assert.IsNull(bucketManager.GetCrash(23423, 100).CrashID);
        }

        [Test]
        public void BucketIdAndCrashIdNullException() {
            Assert.Throws(Is.TypeOf<BucketManagerException>().And.Message.EqualTo("bucketId and crashId cannot be null"), 
                () => bucketManager.GetCrash(null, null));
        }

        [Test]
        public void BucketIdNullException() {            
                Assert.Throws(Is.TypeOf<BucketManagerException>().And.Message.EqualTo("Paramater bucket cannot be null"), 
                () => bucketManager.GetBucket(null));
        }
    }
}