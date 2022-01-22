import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginUser } from 'src/app/_models/_admin/loginUser';
import { AccountService } from 'src/app/_services/account.service';

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
  currentUser: LoginUser;
  
  constructor(private accountService: AccountService,private router: Router) {}

  ngOnInit(): void {
    // this.showSideNav = true;
    this.currentUser = JSON.parse(localStorage.getItem('user'));
  }

  sideNavToggle() {
    this.showSideNav = !this.showSideNav;
    
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/login');
  }

  shouldRun = /(^|.)(stackblitz|webcontainer).(io|com)$/.test(window.location.host);
}
