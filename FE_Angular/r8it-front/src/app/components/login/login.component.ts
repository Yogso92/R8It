import { Component, OnInit, ViewChild, ViewChildren } from '@angular/core';
import LoginFormModel from 'src/app/models/login-form-model';
import { Observable } from 'rxjs';
import { LoginAnswer } from 'src/app/models/login-answer';
import { LoginService } from 'src/app/services/login.service';
import { NbPopoverDirective } from '@nebular/theme';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  @ViewChildren(NbPopoverDirective) popover: NbPopoverDirective[];

  private _form : LoginFormModel;
  public get form() : LoginFormModel {
    return this._form;
  }
  public set form(v : LoginFormModel) {
    this._form = v;
  }
  
  
  
  

  constructor(private loginService : LoginService) { 
    this.form = new LoginFormModel();
    this.form.Email="";
    this.form.Password="";
  }
  
  ngOnInit() {
    
  }
  login(){
    if(this.form.Email.trim().length<5 || this.form.Password.length<5 ){
      console.log("test")
      for (let pop of this.popover){
        pop.show();
      }
    }
    else{
      this.loginService.login(this.form);
    }
  }

}
