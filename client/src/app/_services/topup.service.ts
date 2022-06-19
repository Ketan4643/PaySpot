import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class TopupService {
  baseUrl = environment.baseUrl;
  constructor(private http: HttpClient) { }

  topup(model:any){
    return this.http.post(this.baseUrl + 'admin/topup-wallet', model).pipe(
      map(( response: any)=>{
        const xyz= response;
      })
    );
  }
}
