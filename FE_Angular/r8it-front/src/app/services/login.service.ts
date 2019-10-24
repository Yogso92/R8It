import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import LoginFormModel from '../models/login-form-model';
import { Observable, BehaviorSubject } from 'rxjs';
import { LoginAnswer } from '../models/login-answer';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private logged : BehaviorSubject<boolean>;
  
  public get isLogged() : Observable<boolean> {
    return this.logged.asObservable();
  }
  
  private _endpoint : string = environment.apiurl;


  constructor(private httpClient : HttpClient) {this.logged= new BehaviorSubject(false)}


  login(loginform : LoginFormModel) {
        
    let url : string = this._endpoint+ "/login"
    console.log(loginform)
    console.log(url)
    //this.httpClient.post<LoginAnswer>("https://localhost:44304/api/login", loginform).subscribe(data => console.log(data), error => console.log(error))
    this.httpClient.post<LoginAnswer>(url, loginform).subscribe(data => this.setSession(data.token))
    // return this.httpClient.post<LoginAnswer>(url, loginform)
    //   .pipe(map(user => {
    //     this.setSession(user.token);
    //     return user;
    // }))
  }
  private setSession(authResult : string){
    localStorage.setItem('id_token', authResult);
    console.log(localStorage.getItem("id_token"))
    this.logged.next(true);
    console.log("next true")
  }
  logout(){
    this.logged.next(false);
    console.log(this.logged.value)
    localStorage.removeItem("id_token");
  }
}
