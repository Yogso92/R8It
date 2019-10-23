import {environment} from 'src/environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Subject, Observable} from "rxjs";
import LoginFormModel from '../models/login-form-model';
import { LoginAnswer } from '../models/login-answer';
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
    login(loginform : LoginFormModel) : Observable<LoginAnswer> {
        
        let url : string = this._endpoint+ "/login"
        console.log("YOLOOOO")
        //this.httpClient.post<LoginAnswer>("https://localhost:44304/api/login", loginform).subscribe(data => console.log(data), error => console.log(error))
        return this.httpClient.post<LoginAnswer>("https://localhost:44304/api/login", loginform)
    }
}