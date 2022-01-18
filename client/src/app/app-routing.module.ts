import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './component/about/about.component';
import { DashboardComponent } from './component/backend/dashboard/dashboard.component';
import { LayoutComponent } from './component/backend/layout/layout.component';
import { ContactComponent } from './component/contact/contact.component';
import { HomeComponent } from './component/home/home.component';
import { LoginComponent } from './component/login/login.component';
import { AuthGuard } from './_guards/auth.guard';

const routes: Routes = [
  // { path: '', component: HomeComponent, pathMatch: 'full' },
  // {
  //   path: '',
  //   runGuardsAndResolvers: 'always',
  //   canActivate: [AuthGuard],
  //   children: [
  //     { path: 'dashboard', component: LayoutComponent },
  //   ]
  // },
  // { path: 'about', component: AboutComponent },
  { path: 'contact', component: ContactComponent },
  // // otherwise redirect to home
  // { path: '**', redirectTo: '' }
  // // { path: 'dashboard', runGuardsAndResolvers: 'always', component: DashboardComponent,canActivate: [AuthGuard] }



 
  {
    path: '', component: LayoutComponent,canActivate: [AuthGuard],
    children: [
      { path: 'dashboard', component: DashboardComponent },
      { path: 'about', component: AboutComponent },
    ]
  },
  //  { path: '', component: DashboardComponent, canActivate: [AuthGuard] },
  { path: 'login', component: LoginComponent },
    // otherwise redirect to home
  { path: '**', redirectTo: '' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
