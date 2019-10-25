import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { ICrashBucket } from '../crash-buckets/ICrashBucket';
import { ICrash } from '../crash-detail/ICrash';
import { Subject } from 'rxjs';

@Injectable()
export class CrashbucketService {

    /**
     * Properties of the CrashbucketService
     */
    crashBuckets: Array<ICrashBucket> = [];
    crashBucket: ICrashBucket;
    crash: ICrash;
    httpClient: HttpClient;
    baseUrl: string;
    crashbucketsChanged = new Subject<ICrashBucket[]>();
    crashbucketChanged = new Subject<ICrashBucket>();
    crashChanged = new Subject<ICrash>();


    /**
     * Creates an instance of crashbucket service.
     * @param httpClient
     * @param baseUrl
     */
    constructor(httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.httpClient = httpClient;
        this.baseUrl = baseUrl;
    }

    /**
     * Fetches the buckets from the API
     */
    fetchBuckets() {
        this.httpClient.get<ICrashBucket[]>(this.baseUrl + 'api/buckets').subscribe(result => {
            this.crashBuckets = result;
            this.crashbucketsChanged.next();
        }, error => console.error(error));
    }

    /**
     * Fetches a single bucket
     * @param bucket
     */
    fetchBucket(bucket: ICrashBucket) {
        this.httpClient.post<ICrashBucket>(this.baseUrl + 'api/buckets', bucket).subscribe(result => {
            this.crashBucket = result;
            this.crashbucketChanged.next();
        }, error => console.error(error));
    }

    /**
     * Fetches a single crash
     * @param bucketId
     * @param crashId
     */
    fetchCrash(bucketId: number, crashId: number) {
        this.httpClient.get<ICrash>(this.baseUrl + 'api/buckets/' + bucketId + '/crash/' + crashId).subscribe(result => {
            this.crash = result;
            this.crashChanged.next();
        }, error => console.error(error));
    }

    /**
     * Removes a crash from a Buket
     * @param bucketId
     * @param crashId
     */
    removeCrash(bucketId: number, crashId: number) {
        this.httpClient.delete<ICrashBucket>(this.baseUrl + 'api/buckets/' + bucketId + '/crash/' + crashId).subscribe(result => {

            const pos = this.crashBucket.crashes.findIndex((crash) => {
                return crash.crashID === crashId;
            });
            this.crashBucket.crashes.splice(pos, 1);
            this.crashbucketChanged.next();
        }, error => console.error(error));
    }

    /**
     * Gets crashbuckets and limites then based on the top5 parameter
     * @param top5
     * @returns
     */
    getBuckets(top5: boolean) {

        if (top5) {
            return this.crashBuckets.slice(0, 5);
        }
        return this.crashBuckets.slice();
    }

    /**
     * Gets current crash bucket
     * @returns
     */
    getCurrentCrashBucket() {
        return this.crashBucket;
    }

    /**
     * Gets current crash
     * @returns
     */
    getCurrentCrash() {
        return this.crash;
    }
}
