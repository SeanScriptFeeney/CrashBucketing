import { Component, OnInit, OnDestroy } from '@angular/core';
import { ICrashBucket } from './ICrashBucket';
import { CrashbucketService } from '../services/crashbucket.service';

@Component({
  selector: 'app-crash-buckets',
  templateUrl: './crash-buckets.component.html',
  styleUrls: ['./crash-buckets.component.css']
})
export class CrashBucketsComponent implements OnInit, OnDestroy {

  /**
   * Properties of the CrashBucketsComponent class
   */
  crashBuckets: Array<ICrashBucket> = [];
  crashBucketService: CrashbucketService;
  subscription;
  top5 = true;
  loadingText = 'Load More';
  pageHeader = 'Top 5 Crash Buckets';

  /**
   * Creates an instance of crash buckets component.
   * @param crashBucketServ
   */
  constructor(private crashBucketServ: CrashbucketService) {
    this.crashBucketService = crashBucketServ;
  }

  /**
   * Invoked upon initialisation
   */
  ngOnInit() {
    this.crashBucketService.fetchBuckets();

    this.subscription = this.crashBucketService.crashbucketsChanged.subscribe(
      () => {
        this.crashBuckets = this.crashBucketService.getBuckets(this.top5);
        console.log(this.crashBuckets);
      }
    );
  }

  /**
   * This function is used by the crash loading toggle on the UI.
   * It is used to toggle between crash counts.
   */
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

  /**
   * This method unsubscribes from the subscription that is listening to crash updates
   */
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
