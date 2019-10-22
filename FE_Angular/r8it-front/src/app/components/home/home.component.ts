import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user-service';
import LoginFormModel from 'src/app/models/login-form-model';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  
  private _form : LoginFormModel;
  public get form() : LoginFormModel {
    return this._form;
  }
  public set form(v : LoginFormModel) {
    this._form = v;
  }
  
  private _token : Observable<string>;
  public get token() :  Observable<string> {
    return this._token;
  }
  public set token(v :  Observable<string>) {
    this._token = v;
  }
  
  

  constructor(private userService : UserService) { 
    this.form = new LoginFormModel();
  }
  
  ngOnInit() {
  }
  login(){
    console.log("yolo")
    this.userService.login(this.form).subscribe(data => console.log(data), error => console.log(error))
  }

}
