import { Component, OnInit, OnDestroy } from '@angular/core';
import { ICrashBucket } from '../crash-buckets/ICrashBucket';
import { ActivatedRoute } from '@angular/router';
import { CrashbucketService } from '../services/crashbucket.service';
import { CrashBucket } from '../crash-buckets/CrashBucket';

@Component({
  selector: 'app-bucket-detail',
  templateUrl: './bucket-detail.component.html',
  styleUrls: ['./bucket-detail.component.css']
})
export class BucketDetailComponent implements OnInit, OnDestroy {

  crashBucket: ICrashBucket;
  activatedRoute: ActivatedRoute;
  crashBucketService: CrashbucketService;
  subscription;
  bucketId: number;
  top10 = true;
  loadingText = 'Load More';

  constructor(private activatedR: ActivatedRoute, private bucketService: CrashbucketService) {
    this.activatedRoute = activatedR;
    this.crashBucketService = bucketService;
  }

  ngOnInit() {
    this.getBucketdetail(10);
  }

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

  deleteCrash(bucketId, crashId) {
    this.crashBucketService.removeCrash(bucketId, crashId);
    this.crashBucket.crashCount--;
  }

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

  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
