import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './component/about/about.component';
import { LayoutComponent } from './components/layout/layout.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './_guards/auth.guard';
import { DashboardComponent } from './components/layout/dashboard/dashboard.component';
import { LeadsComponent } from './components/admin/leads/leads.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { UsersComponent } from './components/admin/users/users.component';
import { ContactComponent } from './components/contact/contact.component';
import { AddUserComponent } from './components/admin/users/add-user/add-user.component';
import { UtilitiesComponent } from './components/utilities/utilities.component';
import { TopUpComponent } from './components/top-up/top-up.component';
import { UploadSlipComponent } from './components/upload-slip/upload-slip.component';
import { RechargeComponent} from './components/recharge/recharge.component';
import { HomeComponent } from './component/home/home.component';


const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full'},
  { path: 'login', component: LoginComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'util', component: UtilitiesComponent },
  { path: 'topup', component: TopUpComponent },
  { path: 'slipupload', component: UploadSlipComponent },
  { path: 'recharge', component: RechargeComponent },
  { path: 'home', component: HomeComponent },



  {
    path: '', component: LayoutComponent, canActivate: [AuthGuard],
    children: [
      { path: 'dashboard', component: DashboardComponent },
      { path: 'leads', component: LeadsComponent },
      { path: 'profile', component: UserProfileComponent },
      { path: 'users', component: UsersComponent },
      { path: 'add-user', component: AddUserComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {useHash: true})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
