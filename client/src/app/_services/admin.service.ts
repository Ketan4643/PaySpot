import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Querydto } from '../_models/querydto';
import { States } from '../_models/states';
import { QueryModel } from '../_models/_admin/query-registration';
import { IAdminService } from './abstract/admin-iservice';
import { IApiManagerService } from './abstract/api-manager-iservice';
import { ApiManagerService } from './api-manager.service';

@Injectable({
  providedIn: 'root'
})
export class AdminService {
  private readonly _baseUrl: string;

  constructor(private apiManager: ApiManagerService, private http: HttpClient) { 
    this._baseUrl = environment.baseUrl;
  }
  getQueries() {
    return this.http.get<Querydto[]>(this._baseUrl + 'admin/getqueries');
  }

  getStates() {
    return this.http.get<States[]>(this._baseUrl + 'admin/getstates');
  }

  register(model: QueryModel) {
    return this.http.post(this._baseUrl + 'admin/register', model);
  }
}
