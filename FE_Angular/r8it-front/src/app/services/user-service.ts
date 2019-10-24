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
    
    
}