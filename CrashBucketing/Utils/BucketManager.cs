using System;
using System.Collections.Generic;
using System.Linq;
using CrashBucketing.Models;
using CrashBucketing.Models.Exceptions;
using CrashBucketing.Models.Interfaces;
using Microsoft.Extensions.Logging;

namespace CrashBucketing.Utils {

    /// <summary>
    /// This class manages and carries out operations related to Buckets and 
    /// their crashes.
    /// </summary>
    public class BucketManager : IBucketManager {

        /// <summary>
        /// Property to store a list of all the buckets
        /// </summary>
        /// <value></value>
        public List<IBucket> Buckets { get; set; }

        public BucketManager () {
            this.Buckets = GetHardcodedBuckets ();
        }

        /// <summary>
        /// Gets all the Buckets
        /// </summary>
        /// <returns></returns>
        public List<IBucket> GetAllBuckets () {

            try {
                return this.Buckets.OrderByDescending (b => b.Crashes.Count ()).ToList ();
            } catch (Exception ex) {
                throw new BucketManagerException ("An issue occured when trying to call GetAllBuckets()", ex);
            }
        }

        /// <summary>
        /// Gets a buckets and sorts crashes based on a sort order
        /// </summary>
        /// <param name="bucket"></param>
        /// <returns></returns>
        public IBucket GetBucket (IBucket bucket) {

            if (bucket == null) {
                throw new BucketManagerException ("Param bucket cannot be null");
            }

            if (this.Buckets.Find (x => x.BucketID == bucket.BucketID) != null) {

                var foundbucket = this.Buckets.Single (x => x.BucketID == bucket.BucketID);
                foundbucket.Crashes = foundbucket.Crashes.OrderByDescending (x => x.CrashTime).ToList ();
                foundbucket.CrashCount = foundbucket.Crashes.Count;

                if (bucket.CrashLimit > 0 && bucket.CrashLimit <= foundbucket.Crashes.Count) {
                    var limitedCrashes = foundbucket.Crashes.GetRange (0, (int) bucket.CrashLimit);
                    foundbucket.Crashes = limitedCrashes;
                    return foundbucket;
                }

                return foundbucket;
            }

            return new Bucket ();
        }

        /// <summary>
        /// Gets a single crash
        /// </summary>
        /// <returns></returns>
        public ICrash GetCrash (long? bucketId, long? crashId) {

            if (bucketId == null || crashId == null) {
                throw new BucketManagerException ("bucketId and crashId cannot be null");
            }

            var bucket = this.Buckets.Single (x => x.BucketID == bucketId);

            if (bucket.Crashes.Find (x => x.CrashID == crashId) != null) {
                return bucket.Crashes.Single(x => x.CrashID == crashId);
            }

            return new Crash ();
        }

        /// <summary>
        /// Hard coded data to the API
        /// </summary>
        /// <returns></returns>
        private static List<IBucket> GetHardcodedBuckets () {

            var bucketList = new List<IBucket> ();

            //HARDCODED DATA
            var crashList = new List<ICrash> ();

            for (int i = 0; i < 30; i++) {
                var crash = new Crash {
                    CrashID = i + 1,
                        Stacktrace = @"Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) }
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) }
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) }
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };",
                        AppName = "FIFA 2019",
                        PlatformName = "Linux",
                        CrashTime = new DateTime (2019, 1, 1 + i, 10, 30, 50)
                };
                crashList.Add (crash);
            }

            bucketList.Add (new Bucket { BucketID = 23423, Crashes = crashList });

            //HARDCODED DATA
            var crashList1 = new List<ICrash> ();

            for (int i = 0; i < 29; i++) {
                var crash = new Crash {
                    CrashID = i + 1,
                    Stacktrace = @"ConsoleApplication1.MyCustomException: some message .... ---> System.Exception: Oh noes!
                    at ConsoleApplication1.SomeObject.OtherMethod() in C:\ConsoleApplication1\SomeObject.cs:line 24
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 14
                    --- End of inner exception stack trace ---
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 18
                    at ConsoleApplication1.Program.DoSomething() in C:\ConsoleApplication1\Program.cs:line 23
                    at ConsoleApplication1.Program.Main(String[] args) in C:\ConsoleApplication1\Program.cs:line 13
                    ConsoleApplication1.MyCustomException: some message .... ---> System.Exception: Oh noes!
                    at ConsoleApplication1.SomeObject.OtherMethod() in C:\ConsoleApplication1\SomeObject.cs:line 24
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 14
                    --- End of inner exception stack trace ---
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 18
                    at ConsoleApplication1.Program.DoSomething() in C:\ConsoleApplication1\Program.cs:line 23
                    at ConsoleApplication1.Program.Main(String[] args) in C:\ConsoleApplication1\Program.cs:line 13
                    ConsoleApplication1.MyCustomException: some message .... ---> System.Exception: Oh noes!
                    at ConsoleApplication1.SomeObject.OtherMethod() in C:\ConsoleApplication1\SomeObject.cs:line 24
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 14
                    --- End of inner exception stack trace ---
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 18
                    at ConsoleApplication1.Program.DoSomething() in C:\ConsoleApplication1\Program.cs:line 23
                    at ConsoleApplication1.Program.Main(String[] args) in C:\ConsoleApplication1\Program.cs:line 13
                    ConsoleApplication1.MyCustomException: some message .... ---> System.Exception: Oh noes!
                    at ConsoleApplication1.SomeObject.OtherMethod() in C:\ConsoleApplication1\SomeObject.cs:line 24
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 14
                    --- End of inner exception stack trace ---
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 18
                    at ConsoleApplication1.Program.DoSomething() in C:\ConsoleApplication1\Program.cs:line 23
                    at ConsoleApplication1.Program.Main(String[] args) in C:\ConsoleApplication1\Program.cs:line 13
                    ConsoleApplication1.MyCustomException: some message .... ---> System.Exception: Oh noes!
                    at ConsoleApplication1.SomeObject.OtherMethod() in C:\ConsoleApplication1\SomeObject.cs:line 24
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 14
                    --- End of inner exception stack trace ---
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 18
                    at ConsoleApplication1.Program.DoSomething() in C:\ConsoleApplication1\Program.cs:line 23
                    at ConsoleApplication1.Program.Main(String[] args) in C:\ConsoleApplication1\Program.cs:line 13
                    ConsoleApplication1.MyCustomException: some message .... ---> System.Exception: Oh noes!
                    at ConsoleApplication1.SomeObject.OtherMethod() in C:\ConsoleApplication1\SomeObject.cs:line 24
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 14
                    --- End of inner exception stack trace ---
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 18
                    at ConsoleApplication1.Program.DoSomething() in C:\ConsoleApplication1\Program.cs:line 23
                    at ConsoleApplication1.Program.Main(String[] args) in C:\ConsoleApplication1\Program.cs:line 13
                    ConsoleApplication1.MyCustomException: some message .... ---> System.Exception: Oh noes!
                    at ConsoleApplication1.SomeObject.OtherMethod() in C:\ConsoleApplication1\SomeObject.cs:line 24
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 14
                    --- End of inner exception stack trace ---
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 18
                    at ConsoleApplication1.Program.DoSomething() in C:\ConsoleApplication1\Program.cs:line 23
                    at ConsoleApplication1.Program.Main(String[] args) in C:\ConsoleApplication1\Program.cs:line 13
                    ConsoleApplication1.MyCustomException: some message .... ---> System.Exception: Oh noes!
                    at ConsoleApplication1.SomeObject.OtherMethod() in C:\ConsoleApplication1\SomeObject.cs:line 24
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 14
                    --- End of inner exception stack trace ---
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 18
                    at ConsoleApplication1.Program.DoSomething() in C:\ConsoleApplication1\Program.cs:line 23
                    at ConsoleApplication1.Program.Main(String[] args) in C:\ConsoleApplication1\Program.cs:line 13
                    ConsoleApplication1.MyCustomException: some message .... ---> System.Exception: Oh noes!
                    at ConsoleApplication1.SomeObject.OtherMethod() in C:\ConsoleApplication1\SomeObject.cs:line 24
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 14
                    --- End of inner exception stack trace ---
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 18
                    at ConsoleApplication1.Program.DoSomething() in C:\ConsoleApplication1\Program.cs:line 23
                    at ConsoleApplication1.Program.Main(String[] args) in C:\ConsoleApplication1\Program.cs:line 13
                    ConsoleApplication1.MyCustomException: some message .... ---> System.Exception: Oh noes!
                    at ConsoleApplication1.SomeObject.OtherMethod() in C:\ConsoleApplication1\SomeObject.cs:line 24
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 14
                    --- End of inner exception stack trace ---
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 18
                    at ConsoleApplication1.Program.DoSomething() in C:\ConsoleApplication1\Program.cs:line 23
                    at ConsoleApplication1.Program.Main(String[] args) in C:\ConsoleApplication1\Program.cs:line 13
                    ConsoleApplication1.MyCustomException: some message .... ---> System.Exception: Oh noes!
                    at ConsoleApplication1.SomeObject.OtherMethod() in C:\ConsoleApplication1\SomeObject.cs:line 24
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 14
                    --- End of inner exception stack trace ---
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 18
                    at ConsoleApplication1.Program.DoSomething() in C:\ConsoleApplication1\Program.cs:line 23
                    at ConsoleApplication1.Program.Main(String[] args) in C:\ConsoleApplication1\Program.cs:line 13
                    ConsoleApplication1.MyCustomException: some message .... ---> System.Exception: Oh noes!
                    at ConsoleApplication1.SomeObject.OtherMethod() in C:\ConsoleApplication1\SomeObject.cs:line 24
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 14
                    --- End of inner exception stack trace ---
                    at ConsoleApplication1.SomeObject..ctor() in C:\ConsoleApplication1\SomeObject.cs:line 18
                    at ConsoleApplication1.Program.DoSomething() in C:\ConsoleApplication1\Program.cs:line 23
                    at ConsoleApplication1.Program.Main(String[] args) in C:\ConsoleApplication1\Program.cs:line 13",
                    AppName = "Apex Ledgends",
                    PlatformName = "Windows",
                    CrashTime = new DateTime (2017, 1, 1 + i, 10, 40, 52)
                };
                crashList1.Add (crash);
            }

            bucketList.Add (new Bucket { BucketID = 32423, Crashes = crashList1 });

            //HARDCODED DATA
            var crashList2 = new List<ICrash> ();

            for (int i = 0; i < 25; i++) {
                var crash = new Crash {
                    CrashID = i + 1,
                    Stacktrace = @"DBX.Utils.stackTrace@http://localhost:49573/assets/js/scripts.js:44
                    DBX.Console.Debug@http://localhost:49573/assets/js/scripts.js:9
                    .success@http://localhost:49573/:462
                    x.Callbacks/c@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    x.Callbacks/p.fireWith@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    k@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    .send/r@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    DBX.Utils.stackTrace@http://localhost:49573/assets/js/scripts.js:44
                    DBX.Console.Debug@http://localhost:49573/assets/js/scripts.js:9
                    .success@http://localhost:49573/:462
                    x.Callbacks/c@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    x.Callbacks/p.fireWith@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    k@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    .send/r@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    DBX.Utils.stackTrace@http://localhost:49573/assets/js/scripts.js:44
                    DBX.Console.Debug@http://localhost:49573/assets/js/scripts.js:9
                    .success@http://localhost:49573/:462
                    x.Callbacks/c@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    x.Callbacks/p.fireWith@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    k@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    .send/r@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    DBX.Utils.stackTrace@http://localhost:49573/assets/js/scripts.js:44
                    DBX.Console.Debug@http://localhost:49573/assets/js/scripts.js:9
                    .success@http://localhost:49573/:462
                    x.Callbacks/c@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    x.Callbacks/p.fireWith@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    k@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    .send/r@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    DBX.Utils.stackTrace@http://localhost:49573/assets/js/scripts.js:44
                    DBX.Console.Debug@http://localhost:49573/assets/js/scripts.js:9
                    .success@http://localhost:49573/:462
                    x.Callbacks/c@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    x.Callbacks/p.fireWith@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    k@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    .send/r@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    DBX.Utils.stackTrace@http://localhost:49573/assets/js/scripts.js:44
                    DBX.Console.Debug@http://localhost:49573/assets/js/scripts.js:9
                    .success@http://localhost:49573/:462
                    x.Callbacks/c@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    x.Callbacks/p.fireWith@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    k@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    .send/r@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    DBX.Utils.stackTrace@http://localhost:49573/assets/js/scripts.js:44
                    DBX.Console.Debug@http://localhost:49573/assets/js/scripts.js:9
                    .success@http://localhost:49573/:462
                    x.Callbacks/c@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    x.Callbacks/p.fireWith@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    k@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    .send/r@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    DBX.Utils.stackTrace@http://localhost:49573/assets/js/scripts.js:44
                    DBX.Console.Debug@http://localhost:49573/assets/js/scripts.js:9
                    .success@http://localhost:49573/:462
                    x.Callbacks/c@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    x.Callbacks/p.fireWith@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    k@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    .send/r@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    DBX.Utils.stackTrace@http://localhost:49573/assets/js/scripts.js:44
                    DBX.Console.Debug@http://localhost:49573/assets/js/scripts.js:9
                    .success@http://localhost:49573/:462
                    x.Callbacks/c@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    x.Callbacks/p.fireWith@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    k@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    .send/r@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    DBX.Utils.stackTrace@http://localhost:49573/assets/js/scripts.js:44
                    DBX.Console.Debug@http://localhost:49573/assets/js/scripts.js:9
                    .success@http://localhost:49573/:462
                    x.Callbacks/c@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    x.Callbacks/p.fireWith@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    k@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    .send/r@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    DBX.Utils.stackTrace@http://localhost:49573/assets/js/scripts.js:44
                    DBX.Console.Debug@http://localhost:49573/assets/js/scripts.js:9
                    .success@http://localhost:49573/:462
                    x.Callbacks/c@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    x.Callbacks/p.fireWith@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    k@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    .send/r@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    DBX.Utils.stackTrace@http://localhost:49573/assets/js/scripts.js:44
                    DBX.Console.Debug@http://localhost:49573/assets/js/scripts.js:9
                    .success@http://localhost:49573/:462
                    x.Callbacks/c@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    x.Callbacks/p.fireWith@http://localhost:49573/assets/js/jquery-1.10.2.min.js:4
                    k@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6
                    .send/r@http://localhost:49573/assets/js/jquery-1.10.2.min.js:6",
                    AppName = "Battlefield",
                    PlatformName = "Mac OSX",
                    CrashTime = new DateTime (2019, 3, 1 + i, 10, 30, 50)
                };
                crashList2.Add (crash);
            }

            bucketList.Add (new Bucket { BucketID = 78673, Crashes = crashList2 });

            //HARDCODED DATA
            var crashList3 = new List<ICrash> ();

            for (int i = 0; i < 24; i++) {
                var crash = new Crash {
                    CrashID = i + 1,
                    Stacktrace = @"tweedleburg:~ # sleep 3600 &
                    [2] 2621
                    tweedleburg:~ # gdb
                    (gdb) attach 2621
                    (gdb) bt
                    #0  0x00007feda374e6b0 in __nanosleep_nocancel () from /lib64/libc.so.6
                    #1  0x0000000000403ee7 in ?? ()
                    #2  0x0000000000403d70 in ?? ()
                    #3  0x000000000040185d in ?? ()
                    #4  0x00007feda36b8b05 in __libc_start_main () from /lib64/libc.so.6
                    #5  0x0000000000401969 in ?? ()
                    (gdb)
                    tweedleburg:~ # sleep 3600 &
                    [2] 2621
                    tweedleburg:~ # gdb
                    (gdb) attach 2621
                    (gdb) bt
                    #0  0x00007feda374e6b0 in __nanosleep_nocancel () from /lib64/libc.so.6
                    #1  0x0000000000403ee7 in ?? ()
                    #2  0x0000000000403d70 in ?? ()
                    #3  0x000000000040185d in ?? ()
                    #4  0x00007feda36b8b05 in __libc_start_main () from /lib64/libc.so.6
                    #5  0x0000000000401969 in ?? ()
                    (gdb)
                    tweedleburg:~ # sleep 3600 &
                    [2] 2621
                    tweedleburg:~ # gdb
                    (gdb) attach 2621
                    (gdb) bt
                    #0  0x00007feda374e6b0 in __nanosleep_nocancel () from /lib64/libc.so.6
                    #1  0x0000000000403ee7 in ?? ()
                    #2  0x0000000000403d70 in ?? ()
                    #3  0x000000000040185d in ?? ()
                    #4  0x00007feda36b8b05 in __libc_start_main () from /lib64/libc.so.6
                    #5  0x0000000000401969 in ?? ()
                    (gdb)
                    tweedleburg:~ # sleep 3600 &
                    [2] 2621
                    tweedleburg:~ # gdb
                    (gdb) attach 2621
                    (gdb) bt
                    #0  0x00007feda374e6b0 in __nanosleep_nocancel () from /lib64/libc.so.6
                    #1  0x0000000000403ee7 in ?? ()
                    #2  0x0000000000403d70 in ?? ()
                    #3  0x000000000040185d in ?? ()
                    #4  0x00007feda36b8b05 in __libc_start_main () from /lib64/libc.so.6
                    #5  0x0000000000401969 in ?? ()
                    (gdb)
                    tweedleburg:~ # sleep 3600 &
                    [2] 2621
                    tweedleburg:~ # gdb
                    (gdb) attach 2621
                    (gdb) bt
                    #0  0x00007feda374e6b0 in __nanosleep_nocancel () from /lib64/libc.so.6
                    #1  0x0000000000403ee7 in ?? ()
                    #2  0x0000000000403d70 in ?? ()
                    #3  0x000000000040185d in ?? ()
                    #4  0x00007feda36b8b05 in __libc_start_main () from /lib64/libc.so.6
                    #5  0x0000000000401969 in ?? ()
                    (gdb)
                    tweedleburg:~ # sleep 3600 &
                    [2] 2621
                    tweedleburg:~ # gdb
                    (gdb) attach 2621
                    (gdb) bt
                    #0  0x00007feda374e6b0 in __nanosleep_nocancel () from /lib64/libc.so.6
                    #1  0x0000000000403ee7 in ?? ()
                    #2  0x0000000000403d70 in ?? ()
                    #3  0x000000000040185d in ?? ()
                    #4  0x00007feda36b8b05 in __libc_start_main () from /lib64/libc.so.6
                    #5  0x0000000000401969 in ?? ()
                    (gdb)
                    tweedleburg:~ # sleep 3600 &
                    [2] 2621
                    tweedleburg:~ # gdb
                    (gdb) attach 2621
                    (gdb) bt
                    #0  0x00007feda374e6b0 in __nanosleep_nocancel () from /lib64/libc.so.6
                    #1  0x0000000000403ee7 in ?? ()
                    #2  0x0000000000403d70 in ?? ()
                    #3  0x000000000040185d in ?? ()
                    #4  0x00007feda36b8b05 in __libc_start_main () from /lib64/libc.so.6
                    #5  0x0000000000401969 in ?? ()
                    (gdb)
                    tweedleburg:~ # sleep 3600 &
                    [2] 2621
                    tweedleburg:~ # gdb
                    (gdb) attach 2621
                    (gdb) bt
                    #0  0x00007feda374e6b0 in __nanosleep_nocancel () from /lib64/libc.so.6
                    #1  0x0000000000403ee7 in ?? ()
                    #2  0x0000000000403d70 in ?? ()
                    #3  0x000000000040185d in ?? ()
                    #4  0x00007feda36b8b05 in __libc_start_main () from /lib64/libc.so.6
                    #5  0x0000000000401969 in ?? ()
                    (gdb)
                    tweedleburg:~ # sleep 3600 &
                    [2] 2621
                    tweedleburg:~ # gdb
                    (gdb) attach 2621
                    (gdb) bt
                    #0  0x00007feda374e6b0 in __nanosleep_nocancel () from /lib64/libc.so.6
                    #1  0x0000000000403ee7 in ?? ()
                    #2  0x0000000000403d70 in ?? ()
                    #3  0x000000000040185d in ?? ()
                    #4  0x00007feda36b8b05 in __libc_start_main () from /lib64/libc.so.6
                    #5  0x0000000000401969 in ?? ()
                    (gdb)",
                    AppName = "The Sims",
                    PlatformName = "Linux",
                    CrashTime = new DateTime (2019, 1, 1 + i, 10, 30, 50)
                };
                crashList3.Add (crash);
            }

            bucketList.Add (new Bucket { BucketID = 56756, Crashes = crashList3 });

            //HARDCODED DATA
            var crashList4 = new List<ICrash> ();

            for (int i = 0; i < 20; i++) {
                var crash = new Crash {
                    CrashID = i + 1,
                        Stacktrace = @"Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.NFS.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.NFS.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.NFS.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.NFS.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.NFS.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.NFS.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.NFS.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.NFS.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.NFS.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.NFS.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.NFS.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.NFS.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };",
                        AppName = "Need for Speed",
                        PlatformName = "Windows",
                        CrashTime = new DateTime (2018, 05, 1 + i, 10, 30, 50)
                };
                crashList4.Add (crash);
            }

            bucketList.Add (new Bucket { BucketID = 45672, Crashes = crashList4 });

            //HARDCODED DATA
            var crashList5 = new List<ICrash> ();

            for (int i = 0; i < 18; i++) {
                var crash = new Crash {
                    CrashID = i + 1,
                        Stacktrace = @"Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };
                                    Exception in thread 'main' java.lang.NullPointerException
                                    at com.example.myproject.FIFA.getGame(Book.java:16)
                                    at com.example.myproject.Author.getGameTitles(Author.java:25)
                                    at com.example.myproject.Bootstrap.main(Bootstrap.java:14) };",
                        AppName = "FIFA 2019",
                        PlatformName = "Linux",
                        CrashTime = new DateTime (2018, 08, 1 + i, 10, 30, 50)
                };
                crashList5.Add (crash);
            }

            bucketList.Add (new Bucket { BucketID = 29879, Crashes = crashList5 });

            //HARDCODED DATA
            var crashList6 = new List<ICrash> ();

            for (int i = 0; i < 10; i++) {
                var crash = new Crash {
                    CrashID = i + 1,
                    Stacktrace = @"StudentException: Error finding students
                    at StudentManager.findStudents(StudentManager.java:13)
                    at StudentProgram.main(StudentProgram.java:9)
                    Caused by: DAOException: Error querying students from database
                    at StudentDAO.list(StudentDAO.java:11)
                    at StudentManager.findStudents(StudentManager.java:11)
                    ... 1 more
                    Caused by: java.sql.SQLException: Syntax Error
                    at DatabaseUtils.executeQuery(DatabaseUtils.java:5)
                    at StudentDAO.list(StudentDAO.java:8)
                    ... 2 more
                    StudentException: Error finding students
                    at StudentManager.findStudents(StudentManager.java:13)
                    at StudentProgram.main(StudentProgram.java:9)
                    Caused by: DAOException: Error querying students from database
                    at StudentDAO.list(StudentDAO.java:11)
                    at StudentManager.findStudents(StudentManager.java:11)
                    ... 1 more
                    Caused by: java.sql.SQLException: Syntax Error
                    at DatabaseUtils.executeQuery(DatabaseUtils.java:5)
                    at StudentDAO.list(StudentDAO.java:8)
                    ... 2 more
                    StudentException: Error finding students
                    at StudentManager.findStudents(StudentManager.java:13)
                    at StudentProgram.main(StudentProgram.java:9)
                    Caused by: DAOException: Error querying students from database
                    at StudentDAO.list(StudentDAO.java:11)
                    at StudentManager.findStudents(StudentManager.java:11)
                    ... 1 more
                    Caused by: java.sql.SQLException: Syntax Error
                    at DatabaseUtils.executeQuery(DatabaseUtils.java:5)
                    at StudentDAO.list(StudentDAO.java:8)
                    ... 2 more
                    StudentException: Error finding students
                    at StudentManager.findStudents(StudentManager.java:13)
                    at StudentProgram.main(StudentProgram.java:9)
                    Caused by: DAOException: Error querying students from database
                    at StudentDAO.list(StudentDAO.java:11)
                    at StudentManager.findStudents(StudentManager.java:11)
                    ... 1 more
                    Caused by: java.sql.SQLException: Syntax Error
                    at DatabaseUtils.executeQuery(DatabaseUtils.java:5)
                    at StudentDAO.list(StudentDAO.java:8)
                    ... 2 more
                    StudentException: Error finding students
                    at StudentManager.findStudents(StudentManager.java:13)
                    at StudentProgram.main(StudentProgram.java:9)
                    Caused by: DAOException: Error querying students from database
                    at StudentDAO.list(StudentDAO.java:11)
                    at StudentManager.findStudents(StudentManager.java:11)
                    ... 1 more
                    Caused by: java.sql.SQLException: Syntax Error
                    at DatabaseUtils.executeQuery(DatabaseUtils.java:5)
                    at StudentDAO.list(StudentDAO.java:8)
                    ... 2 more",
                    AppName = "FIFA 2019",
                    PlatformName = "Windows",
                    CrashTime = new DateTime (2019, 2, 1 + i, 10, 30, 50)
                };
                crashList6.Add (crash);
            }

            bucketList.Add (new Bucket { BucketID = 12313, Crashes = crashList6 });

            //HARDCODED DATA
            var crashList7 = new List<ICrash> ();

            for (int i = 0; i < 8; i++) {
                var crash = new Crash {
                    CrashID = i + 1,
                    Stacktrace = @"java.lang.NullPointerException
                    at twoten.TwoTenB.<init>(TwoTenB.java:29)
                    at javapractice.JavaPractice.main(JavaPractice.java:32)
                    java.lang.NullPointerException
                    at twoten.TwoTenB.<init>(TwoTenB.java:29)
                    at javapractice.JavaPractice.main(JavaPractice.java:32)
                    java.lang.NullPointerException
                    at twoten.TwoTenB.<init>(TwoTenB.java:29)
                    at javapractice.JavaPractice.main(JavaPractice.java:32)java.lang.NullPointerException
                    at twoten.TwoTenB.<init>(TwoTenB.java:29)
                    at javapractice.JavaPractice.main(JavaPractice.java:32)
                    java.lang.NullPointerException
                    at twoten.TwoTenB.<init>(TwoTenB.java:29)
                    at javapractice.JavaPractice.main(JavaPractice.java:32)",
                    AppName = "Street Figther",
                    PlatformName = "Windows",
                    CrashTime = new DateTime (2019, 8, 1 + i, 10, 30, 50)
                };
                crashList7.Add (crash);
            }

            bucketList.Add (new Bucket { BucketID = 65732, Crashes = crashList7 });

            //HARDCODED DATA
            var crashList8 = new List<ICrash> ();

            for (int i = 0; i < 7; i++) {
                var crash = new Crash {
                    CrashID = i + 1,
                    Stacktrace = @"==> Satisfying dependencies
                    ==> Downloading https://dl.google.com/android/repository/sdk-tools-darwin-3859397.zip
                    Already downloaded: /Users/tomasnovella/Library/Caches/Homebrew/Cask/android-sdk--3859397,26.0.1.zip
                    ==> Verifying checksum for Cask android-sdk
                    ==> Installing Cask android-sdk
                    ==> Exception in thread 'main'
                    ==> java.lang.NoClassDefFoundError: javax/xml/bind/annotation/XmlSchema",
                    AppName = "Star Wars",
                    PlatformName = "Linux",
                    CrashTime = new DateTime (2019, 9, 1 + i, 10, 30, 50)
                };
                crashList8.Add (crash);
            }

            bucketList.Add (new Bucket { BucketID = 97855, Crashes = crashList8 });

            //HARDCODED DATA
            var crashList9 = new List<ICrash> ();

            for (int i = 0; i < 5; i++) {
                var crash = new Crash {
                    CrashID = i + 1,
                        Stacktrace = @"Error: Main method not found in class MyClass, please define the main method as:
                                    public static void main(String[] args)
                                    or a JavaFX application class must extend javafx.application.Application
                                    Error: Main method not found in class MyClass, please define the main method as:
                                    public static void main(String[] args)
                                    or a JavaFX application class must extend javafx.application.Application
                                    Error: Main method not found in class MyClass, please define the main method as:
                                    public static void main(String[] args)
                                    or a JavaFX application class must extend javafx.application.Application
                                    Error: Main method not found in class MyClass, please define the main method as:
                                    public static void main(String[] args)
                                    or a JavaFX application class must extend javafx.application.Application",
                        AppName = "Titan Falls",
                        PlatformName = "Windows",
                        CrashTime = new DateTime (2019, 10, 1 + i, 10, 30, 50)
                };
                crashList9.Add (crash);
            }

            bucketList.Add (new Bucket { BucketID = 94765, Crashes = crashList9 });

            return bucketList;

        }
    }
}