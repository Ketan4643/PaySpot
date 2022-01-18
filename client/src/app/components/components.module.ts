import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from './material.module';
import { NavbarComponent } from './navbar/navbar.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { LayoutComponent } from './layout/layout.component';
import { RouterModule } from '@angular/router';
import { SidenavComponent } from './layout/sidenav/sidenav.component';
import { DashboardComponent } from './layout/dashboard/dashboard.component';
import { LeadsComponent } from './leads/leads.component';
import { UserProfileComponent } from './user-profile/user-profile.component';

@NgModule({
  declarations: [
    NavbarComponent,
    LoginComponent,
    DashboardComponent,
    LayoutComponent,
    SidenavComponent,
    LeadsComponent,
    UserProfileComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    BsDropdownModule,
    RouterModule,
  ],
  exports: [
    NavbarComponent,
    LoginComponent,
    FormsModule,
    ReactiveFormsModule,
    BsDropdownModule,
    DashboardComponent,
    LayoutComponent,
    SidenavComponent,
    LeadsComponent,
    UserProfileComponent
  ]
})
export class ComponentsModule { }
