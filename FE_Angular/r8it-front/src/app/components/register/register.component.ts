import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';
import { BaseUserModel } from 'src/app/models/base-user-model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Country } from 'src/app/models/country';
import { Observable } from 'rxjs';
import { CountryService } from 'src/app/services/country.service';
import { map } from 'rxjs/operators';

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
  
  private _form : FormGroup;
  public get form() : FormGroup {
    return this._form;
  }
  public set form(v : FormGroup) {
    this._form = v;
  }
  
  private _countries : Observable<Array<Country>>;
  public get countries() : Observable<Array<Country>> {
    
    return this._countries;
  }
  public set countries(v : Observable<Array<Country>>) {
    this._countries = v;
  }
  

  
  private _registerError : boolean;
  public get registerError() : boolean {
    return this._registerError;
  }
  public set registerError(v : boolean) {
    this._registerError = v;
  }
  
  
  
  constructor(private loginService : LoginService, private formBuilder : FormBuilder, private countryService : CountryService) {
    this.form = this.formBuilder.group({
      nickname : ['', Validators.minLength(7)],
      birthdate: ['', Validators.required],
      email: ['', Validators.required], 
      country : [ Validators.required],
      password : ['', Validators.minLength(5)],
      confirmPassword : ['', Validators.required]
    }, 
    {validator : this.checkPasswords})
    this.countries = this.countryService.Get().pipe(map(data => {
      
      return data;
    }));
   }

  ngOnInit() {
  }
  register(){
    this.user = {
      birthdate: this.form.get('birthdate').value,
      nickname: this.form.get('nickname').value,
      email: this.form.get('email').value,
      password: this.form.get('password').value,
      country:  this.form.get('country').value
    };
    this.user.birthdate= this.form.get('birthdate').value;
    this.user.nickname= this.form.get('nickname').value;
    this.user.email= this.form.get('email').value;
    this.user.password= this.form.get('password').value;
    this.user.country= this.form.get('country').value;
    this.loginService.register(this.user).subscribe(data => {
      console.log(data)
      if(data.id !== 0) this.loginService.login({Email : this.user.email, Password : this.user.password})
      else this.registerError = true;
    })
  }
  checkPasswords(group : FormGroup){
    const pass = group.get('password').value;
    const verif = group.get('confirmPassword').value;
    return pass ===verif ? null : {notSame : true}
  }
  

}
