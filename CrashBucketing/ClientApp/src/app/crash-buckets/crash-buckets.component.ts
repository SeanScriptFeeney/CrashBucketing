import { Component, OnInit, OnDestroy } from '@angular/core';
import { ICrashBucket } from './ICrashBucket';
import { CrashbucketService } from '../services/crashbucket.service';

@Component({
  selector: 'app-crash-buckets',
  templateUrl: './crash-buckets.component.html',
  styleUrls: ['./crash-buckets.component.css']
})
export class CrashBucketsComponent implements OnInit, OnDestroy {

  crashBuckets: Array<ICrashBucket> = [];
  crashBucketService: CrashbucketService;
  subscription;
  top5 = true;
  loadingText = 'Load More';
  pageHeader = 'Top 5 Crash Buckets';

  constructor(private crashBucketServ: CrashbucketService) {
    this.crashBucketService = crashBucketServ;
  }

  ngOnInit() {
    this.crashBucketService.fetchBuckets();

    this.subscription = this.crashBucketService.crashbucketsChanged.subscribe(
      () => {
        this.crashBuckets = this.crashBucketService.getBuckets(this.top5);
        console.log(this.crashBuckets);
      }
    );
  }

  loadMore() {

    if (this.loadingText === 'Load More') {
      this.loadingText = 'Show Less';
      this.top5 = false;
      this.pageHeader = 'All Crash Buckets';
    } else {
      this.loadingText = 'Load More';
      this.pageHeader = 'Top 5 Crash Buckets';
      this.top5 = true;
    }

    this.crashBuckets = this.crashBucketService.getBuckets(this.top5);
    console.log(this.crashBuckets);
  }

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
