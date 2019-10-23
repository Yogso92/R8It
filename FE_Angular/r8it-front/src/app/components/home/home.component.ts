import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/services/user-service';
import LoginFormModel from 'src/app/models/login-form-model';
import { Observable } from 'rxjs';
import { LoginAnswer } from 'src/app/models/login-answer';
import { CategoryService } from 'src/app/services/category.service';

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
  
  private _answer : Observable<LoginAnswer>;
  public get answer() :  Observable<LoginAnswer> {
    return this._answer;
  }
  public set answer(v :  Observable<LoginAnswer>) {
    this._answer = v;
  }
  
  private _token : string;
  public get token() : string {
    return this._token;
  }
  public set token(v : string) {
    this._token = v;
  }
  
  private _categories : Observable<Array<Category>>;
  public get categories() : Observable<Array<Category>> {
    return this._categories;
  }
  public set categories(v : Observable<Array<Category>>) {
    this._categories = v;
  }
  
  
  

  constructor(private userService : UserService, private categoryService : CategoryService) { 
    this.form = new LoginFormModel();
    this.answer = null;
  }
  
  ngOnInit() {
    
  }
  login(){
    this.answer = this.userService.login(this.form);
    this.answer.subscribe(data => {this.token = data.token; this.categories = this.categoryService.GetAll();})
  }

}
