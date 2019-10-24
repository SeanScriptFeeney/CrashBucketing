import { Component } from '@angular/core';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {

  /**
   * Properties of NavMenuComponent class
   */
  isExpanded = false;
  title = 'CrashBucketing';

  /**
   * Collapses the navbar
   */
  collapse() {
    this.isExpanded = false;
  }

  /**
   * Toggles the nav menu
   */
  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
