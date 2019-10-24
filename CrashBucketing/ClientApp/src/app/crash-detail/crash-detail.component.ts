import { Component, OnInit, OnDestroy } from '@angular/core';
import { ICrash } from './ICrash';
import { ActivatedRoute } from '@angular/router';
import { CrashbucketService } from '../services/crashbucket.service';

@Component({
  selector: 'app-crash-detail',
  templateUrl: './crash-detail.component.html',
  styleUrls: ['./crash-detail.component.css']
})
export class CrashDetailComponent implements OnInit, OnDestroy {

  /**
   * Properties of the CrashDetailComponent class
   */
  crash: ICrash;
  activatedRoute: ActivatedRoute;
  crashBucketService: CrashbucketService;
  subscription;
  crashId: number;
  bucketId: number;

  /**
   * Creates an instance of crash detail component.
   * @param activatedR
   * @param bucketService
   */
  constructor(private activatedR: ActivatedRoute, private bucketService: CrashbucketService) {
    this.activatedRoute = activatedR;
    this.crashBucketService = bucketService;
  }

  /**
   * Invoked upon initialisation
   */
  ngOnInit() {
    this.activatedRoute.params.subscribe(
      (params) => {
        this.crashBucketService.fetchCrash(params.bucketId, params.crashId);
        this.bucketId = params.bucketId;
        this.crashId = params.crashId;
      }
    );

    this.subscription = this.crashBucketService.crashChanged.subscribe(
      () => {
        this.crash = this.crashBucketService.getCurrentCrash();
      }
    );
  }

  /**
   * This method unsubscribes from the subscription that is listening to crash detail updates
   */
  ngOnDestroy() {
    this.subscription.unsubscribe();
  }
}
