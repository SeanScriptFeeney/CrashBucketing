import { ICrashBucket } from './ICrashBucket';
import { ICrash } from '../crash-detail/ICrash';

/**
 * this class is used to hold the attributes of a Crash Bucket.
 */
export class CrashBucket implements ICrashBucket {
    bucketID: number;
    crashes: Array<ICrash>;
    crashLimit: number;
    crashCount: number;
}
