import { Component } from '@angular/core';
import { UserService } from './services/user-service';
import { LoginService } from './services/login.service';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'r8it-front';
  
  
  private _isLogged : Observable<boolean>;
  public get isLogged() : Observable<boolean> {
    return this._isLogged;
  }
  public set isLogged(v : Observable<boolean>) {
    this._isLogged = v;
  }
  
  
  constructor(private loginService : LoginService){
    this.isLogged = this.loginService.isLogged;
  }

}
