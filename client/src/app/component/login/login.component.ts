import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { Login } from 'src/app/_models/login';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: Login = {} as Login;
  currentUser$: Observable<User>;
  userDto!: User;
  hide: boolean = true;
  enabled: boolean = false;

  constructor(private toastr: ToastrService, 
              private accountService: AccountService, 
              private router: Router) { }
  
  ngOnInit(): void {  
    this.currentUser$ = this.accountService.currentUser$;
  }

  // login(f: NgForm) {
  //   console.log(this.model);
  //   f.valid ? this.toastr.success(JSON.stringify(this.model)) : this.toastr.error('invalid Username and Password');
  // }

  login() {
    this.accountService.login(this.model).subscribe(response => {
      this.router.navigateByUrl('/adminDashboard');
      // this.currentUser$.subscribe(user => {
      //   if(user) {
      //     console.log(user);
      //     this.userDto = user;
      //   }
      // })
      this.userDto = JSON.parse(localStorage.getItem('user') || '{}');
      console.log(this.userDto.username);
      // this.userDto = JSON.parse(localStorage.getItem('user') || '{}');
      this.toastr.success('Welcome ' + this.userDto.username);
    })
  }
}