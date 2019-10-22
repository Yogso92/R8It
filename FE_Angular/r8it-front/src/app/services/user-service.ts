import {environment} from 'src/environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Subject, Observable} from "rxjs";
import LoginFormModel from '../models/login-form-model';
@Injectable({
    providedIn: 'root'
})
export class UserService{
    private _endpoint : string = environment.apiurl;
    constructor(private httpClient : HttpClient){}

    getBaseUser(id:number) : Observable<any>{
        let url : string = this._endpoint + "/" +id.toString(); 
        return this.httpClient.get<any>(url);
    }
    login(loginform : LoginFormModel) : Observable<any> {
        let headerDict = {
            'Content-Type': 'application/json',
            'Accept': 'application/json'
        }
        let requestOptions  = {                                                                                                                                                                                 
            headers: new HttpHeaders(headerDict), 
          };
        let url : string = this._endpoint+ "/login"
        console.log("YOLOOOO")
        
        return this.httpClient.post<any>("https://localhost:44304/api/login", loginform)
    }
}