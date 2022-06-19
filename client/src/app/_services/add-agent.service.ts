import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, ReplaySubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Login } from '../_models/login';
import { User } from '../_models/user';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AddAgentService {
  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

  
  addAgent(model:any){
    return this.http.post(this.baseUrl + 'admin/add-agent', model).pipe(
      map(( response: any)=>{
        const xyz= response;
      })
    );
    // subscribe(status=> console.log(JSON.stringify(status)));
        
  }

  addKYC(model:any){
    return this.http.post(this.baseUrl + 'admin/update-kyc', model).pipe(
      map(( response: any)=>{
        const xyz= response;
      })
    );
    // subscribe(status=> console.log(JSON.stringify(status)));
  }

  addAddress(model:any){
    return this.http.post(this.baseUrl + 'admin/update-address', model).pipe(
      map(( response: any)=>{
        const xyz= response;
      })
    );
    // subscribe(status=> console.log(JSON.stringify(status)));
  }
}
