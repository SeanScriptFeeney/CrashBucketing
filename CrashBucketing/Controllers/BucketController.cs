using System.Collections.Generic;
using CrashBucketing.Models;
using CrashBucketing.Models.Interfaces;
using CrashBucketing.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CrashBucketing.Controllers {
    [ApiController]
    [Route ("api/[controller]")]
    public class BucketsController : ControllerBase {
        private readonly ILogger<BucketsController> _logger;
        private IBucketManager _bucketManager;

        public BucketsController (ILogger<BucketsController> logger) {
            _logger = logger;
            _bucketManager = new BucketManager ();
        }
        
        // GET: api/buckets
        [HttpGet]
        public IEnumerable<IBucket> Get () {
            _logger.LogInformation ("Getting All Buckets");
            return _bucketManager.GetAllBuckets ();
        }

        // POST: api/buckets
        [HttpPost]
        public IActionResult GetBucketDetails ([FromBody] Bucket bucket) {
            _logger.LogInformation (string.Format ("Getting Bucket : {0}", bucket.BucketID));
            return new ObjectResult (_bucketManager.GetBucket (bucket));
        }

        // GET: api/buckets/1234/crash/1
        [HttpGet ("{bucketId}/crash/{crashId}")]
        public IActionResult GetCrashById (long bucketId, long crashId) {
            _logger.LogInformation (string.Format ("Getting Crash crash: Bucket : {0}, Crash Number : {1} ", bucketId, crashId));
            return new ObjectResult (_bucketManager.GetCrash (bucketId, crashId));
        }

        //DELETE: api/buckets/1234/crash/1243
        [HttpDelete ("{bucketId}/crash/{crashId}")]
        public IActionResult DeleteTodoItem (long bucketId, long crashId) {
            _logger.LogInformation (string.Format ("Deleted crash: Bucket : {0}, Crash Number : {1} ", bucketId, crashId));
            return new NoContentResult ();
        }
    }
}