import { MediaMatcher } from '@angular/cdk/layout';
import { ChangeDetectorRef, Component, OnDestroy, OnInit, 
  NgZone, ViewChild, HostListener, Directive, AfterViewInit} from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
// import { Menu } from 'src/app/_models/menu';
import { Menu, Menuitems } from 'src/app/_models/menuitems';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnInit, OnDestroy {
  currentUser$: Observable<User>;
  mobileQuery: MediaQueryList;
  panelOpenState = false;
  public loginUserName;
  private _mobileQueryListener: () => void;
  public sideMenuItems: Menu[] = [];
  imgProfileUrl: any;

  constructor(changeDetectorRef: ChangeDetectorRef,
    media: MediaMatcher,
    private router: Router,
    public domSanitizer: DomSanitizer,
    private accountService: AccountService,
    private menuitems :Menuitems) {
    this.mobileQuery = media.matchMedia('(min-width: 768px)');
    this._mobileQueryListener = () => changeDetectorRef.detectChanges();
    this.mobileQuery.addListener(this._mobileQueryListener);
  }
  ngOnInit(): void {
    this.currentUser$ = this.accountService.currentUser$;
    let token: string;
    this.accountService.currentUser$.pipe(
      map(user => {
        if (user) {
          token = user.token;
          this.loginUserName = user.username;
          this.sideMenuItems = this.menuitems.getMenuitem();
        }
      })
    )
  }

  public logout() {
    this.accountService.logout();
  }

  ngOnDestroy(): void {
    this.mobileQuery.removeListener(this._mobileQueryListener);
  }
  // shouldRun = /(^|.)(stackblitz|webcontainer).(io|com)$/.test(window.location.host);

}
