import {environment} from 'src/environments/environment';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {Subject, Observable} from "rxjs";
import LoginFormModel from '../models/login-form-model';
import { LoginAnswer } from '../models/login-answer';
import * as moment from 'moment';
import {map} from 'rxjs/operators'


@Injectable({
    providedIn: 'root'
})
export class UserService{
    private _endpoint : string = environment.apiurl;
    constructor(private httpClient : HttpClient){}

    getBaseUser(id:number) : Observable<any>{
        let url : string = this._endpoint + "/user/" +id.toString(); 
        return this.httpClient.get<any>(url);
    }
    login(loginform : LoginFormModel) : Observable<LoginAnswer> {
        
        let url : string = this._endpoint+ "/login"
        console.log("YOLOOOO")
        //this.httpClient.post<LoginAnswer>("https://localhost:44304/api/login", loginform).subscribe(data => console.log(data), error => console.log(error))
        return this.httpClient.post<LoginAnswer>(url, loginform).pipe(map(user => {
            this.setSession(user.token);
            return user;
        }))
    }
    private setSession(authResult : string){
        localStorage.setItem('id_token', authResult);
        console.log(localStorage.getItem("id_token"))
    }
    logout(){
        localStorage.removeItem("id_token");
        localStorage.removeItem("expires_at");
    }
    getExpiration() {
        const expiration = localStorage.getItem("expires_at");
        const expiresAt = JSON.parse(expiration);
        return moment(expiresAt);
    }  
}