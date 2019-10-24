import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';
import { BaseUserModel } from 'src/app/models/base-user-model';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  
  private _user : BaseUserModel;
  public get user() : BaseUserModel {
    return this._user;
  }
  public set user(v : BaseUserModel) {
    this._user = v;
  }

  
  private _registerError : boolean;
  public get registerError() : boolean {
    return this._registerError;
  }
  public set registerError(v : boolean) {
    this._registerError = v;
  }
  
  
  
  constructor(private loginService : LoginService) { }

  ngOnInit() {
  }
  register(){
    this.loginService.register(this.user).subscribe(data => {
      if(data.ok !== true  && data.body.id !== 0) this.loginService.login({Email : this.user.email, Password : this.user.password})
      else this.registerError = true;
    })
  }

}
