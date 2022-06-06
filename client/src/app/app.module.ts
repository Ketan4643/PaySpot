import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgxMatFileInputModule } from '@angular-material-components/file-input';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ComponentModule } from './component/component.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HasRoleDirective } from './_directives/has-role.directive';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorInterceptor } from './_interceptoprs/error.interceptor';
import { JwtInterceptor } from "./_interceptoprs/JwtInterceptor";
import { LoadingInterceptor } from './_interceptoprs/loading.interceptor';
import { Menuitems } from './_models/menuitems';
import { ComponentsModule } from './components/components.module';
import { UtilitiesComponent } from './components/utilities/utilities.component';
import { TopUpComponent } from './components/top-up/top-up.component';
import { RechargeComponent } from './components/recharge/recharge.component';
import { UploadSlipComponent } from './components/upload-slip/upload-slip.component';

@NgModule({
  declarations: [
    AppComponent,
    HasRoleDirective,
    UtilitiesComponent,
    TopUpComponent,
    RechargeComponent,
    UploadSlipComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ComponentModule,
    BrowserAnimationsModule,
    ComponentsModule,
    NgxMatFileInputModule
  ],
  providers: [
    Menuitems,
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
