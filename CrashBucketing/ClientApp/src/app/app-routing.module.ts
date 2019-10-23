import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

import { CrashBucketsComponent } from './crash-buckets/crash-buckets.component';
import { BucketDetailComponent } from './bucket-detail/bucket-detail.component';
import { CrashDetailComponent } from './crash-detail/crash-detail.component';

const routes = [
    { path: 'crashbuckets', component: CrashBucketsComponent, pathMatch: 'full' },
    { path: 'bucketdetail/:id', component: BucketDetailComponent },
    { path: 'crashdetail/:bucketId/crash/:crashId', component: CrashDetailComponent },
    { path: '**', redirectTo: '/crashbuckets' },
];

@NgModule({
    imports: [
        RouterModule.forRoot(routes)
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule {}
