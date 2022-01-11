import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Login } from '../_models/login';
import { User } from '../_models/user';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class AccountService {
  baseUrl = environment.baseUrl;
  private currentSource = new ReplaySubject<User>(1);
  currentUser$ = this.currentSource.asObservable();

  constructor(private http: HttpClient) { }

  login(model: any) {
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if(user) {
          //this.setCurrentUser(user);
          localStorage.setItem('user', JSON.stringify(user));
          this.currentSource.next(user);
        }
      })
    );
  }

  // setCurrentUser(user: User) {
  //   user.role = [];
  //   console.log(`User in setCurrentUserMethod: ${user}`);
  //   const roles = this.getDecodedToken(user.token).role;
  //   Array.isArray(roles) ? user.role = roles : user.role.push(roles);
  //   localStorage.setItem('user', JSON.stringify(user));
  //   this.currentSource.next(user);
  // }

  getDecodedToken(token: any) {
    return JSON.parse(atob(token.split('.')[1]));
  } 
}