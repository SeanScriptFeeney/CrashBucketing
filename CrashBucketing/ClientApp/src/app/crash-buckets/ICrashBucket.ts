import { ICrash } from '../crash-detail/ICrash';

/**
 * This interface represents the attributes of a Crash Bucket
 */
export interface ICrashBucket {
    bucketID: number;
    crashes: Array<ICrash>;
    crashLimit: number;
    crashCount: number;
}
