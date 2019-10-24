import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { ICrashBucket } from '../crash-buckets/ICrashBucket';
import { CrashbucketService } from '../services/crashbucket.service';
import { CrashBucket } from '../crash-buckets/CrashBucket';

@Component({
  selector: 'app-bucket-detail',
  templateUrl: './bucket-detail.component.html',
  styleUrls: ['./bucket-detail.component.css']
})
export class BucketDetailComponent implements OnInit, OnDestroy {

  /**
   * Properties of the BucketDetailComponent class
   */
  crashBucket: ICrashBucket;
  activatedRoute: ActivatedRoute;
  crashBucketService: CrashbucketService;
  subscription;
  bucketId: number;
  top10 = true;
  loadingText = 'Load More';

  /**
   * Creates an instance of bucket detail component.
   * @param activatedR
   * @param bucketService
   */
  constructor(private activatedR: ActivatedRoute, private bucketService: CrashbucketService) {
    this.activatedRoute = activatedR;
    this.crashBucketService = bucketService;
  }

  /**
   * on init
   */
  ngOnInit() {
    this.getBucketdetail(10);
  }

  /**
   * Loads the top 10 Buckets or loads
   * all buckets depending on user selection.
   */
  loadMore() {

    if (this.loadingText === 'Load More') {
      this.loadingText = 'Show Less';
      this.getBucketdetail(0);
    } else {
      this.loadingText = 'Load More';
      this.getBucketdetail(10);
    }

    this.crashBucket = this.crashBucketService.getCurrentCrashBucket();
    console.log(this.crashBucket);
  }

  /**
   * Deletes crash
   * @param bucketId
   * @param crashId
   */
  deleteCrash(bucketId, crashId) {
    this.crashBucketService.removeCrash(bucketId, crashId);
    this.crashBucket.crashCount--;
  }

  /**
   * Gets bucketdetail
   * @param limitCount
   */
  getBucketdetail(limitCount: number) {

    this.activatedRoute.params.subscribe(
      (params) => {
        this.crashBucket = new CrashBucket();
        this.crashBucket.bucketID = +params.id;
        if (limitCount) {
          this.crashBucket.crashLimit = limitCount;
        }
        this.crashBucketService.fetchBucket(this.crashBucket);
        this.bucketId = params.id;
      }
    );

    this.subscription = this.crashBucketService.crashbucketChanged.subscribe(
      () => {
        this.crashBucket = this.crashBucketService.getCurrentCrashBucket();
      }
    );
  }

  /**
   * This method unsubscribes from the subscription that is listening to crash bucket updates
   */
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
