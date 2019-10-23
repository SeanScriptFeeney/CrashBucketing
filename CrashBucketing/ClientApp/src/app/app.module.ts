import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CrashBucketsComponent } from './crash-buckets/crash-buckets.component';
import { BucketDetailComponent } from './bucket-detail/bucket-detail.component';
import { CrashDetailComponent } from './crash-detail/crash-detail.component';
import { AppRoutingModule } from './app-routing.module';
import { CrashbucketService } from './services/crashbucket.service';
import { CrashBucketComponent } from './crash-bucket/crash-bucket.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CrashBucketsComponent,
    BucketDetailComponent,
    CrashDetailComponent,
    CrashBucketComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [CrashbucketService],
  bootstrap: [AppComponent]
})
export class AppModule { }
