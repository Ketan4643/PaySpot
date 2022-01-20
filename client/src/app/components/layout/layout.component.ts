import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent implements OnInit {
  events: string[] = [];
  opened: boolean = true;
  showFiller = false;
  showSideNav: boolean;
  
  constructor() {}

  ngOnInit(): void {
    // this.showSideNav = true;
  }

  sideNavToggle() {
    this.showSideNav = !this.showSideNav;
  }

  shouldRun = /(^|.)(stackblitz|webcontainer).(io|com)$/.test(window.location.host);
}
