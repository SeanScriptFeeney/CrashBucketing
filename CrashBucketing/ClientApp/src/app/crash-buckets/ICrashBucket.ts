import { ICrash } from '../crash-detail/ICrash';

export interface ICrashBucket {
    bucketID: number;
    crashes: Array<ICrash>;
    crashLimit: number;
    crashCount: number;
}
