import { ICrashBucket } from './ICrashBucket';
import { ICrash } from '../crash-detail/ICrash';

export class CrashBucket implements ICrashBucket {
    bucketID: number;
    crashes: Array<ICrash>;
    crashLimit: number;
    crashCount: number;
}
