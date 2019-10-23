export interface ICrash {
    crashID: number;
    stacktrace: string;
    appName: string;
    platformname: string;
    crashTime: Date;
}
