import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from '../_services/account.service';

@Injectable({
  providedIn: 'root'
})
export class DistributorGuard implements CanActivate {
  constructor(private accountService: AccountService, private toastr: ToastrService) {}
  canActivate(): Observable<boolean> {
    return this.accountService.currentUser$.pipe(
      map(user => {
        if(user.role.includes("SuperDistributor") || user.role.includes('Distributor')) {
          return true;
        }

        this.toastr.error("You are not authorized for this section");
      })
    )
  }
  
}