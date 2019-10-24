/**
 * This interface represents the attributes of a crash
 */
export interface ICrash {
    crashID: number;
    stacktrace: string;
    appName: string;
    platformname: string;
    crashTime: Date;
}
