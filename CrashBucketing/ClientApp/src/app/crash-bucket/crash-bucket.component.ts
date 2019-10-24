import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-crash-bucket',
  templateUrl: './crash-bucket.component.html',
  styleUrls: ['./crash-bucket.component.css']
})
export class CrashBucketComponent {

  /**
   * bucket input that is rendered on the UI
   */
  @Input() bucket;
}
