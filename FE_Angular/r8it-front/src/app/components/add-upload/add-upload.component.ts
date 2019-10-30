import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { UploadService } from 'src/app/services/upload.service';
import { UploadModel } from 'src/app/models/upload';
import { LoginService } from 'src/app/services/login.service';
import { RatingService } from 'src/app/services/rating.service';
import { RatingType } from 'src/app/models/rating-type';
import { Observable } from 'rxjs';
import { CategoryService } from 'src/app/services/category.service';

@Component({
  selector: 'app-add-upload',
  templateUrl: './add-upload.component.html',
  styleUrls: ['./add-upload.component.scss']
})
export class AddUploadComponent implements OnInit {

  
  private _form : FormGroup;
  public get form() : FormGroup {
    return this._form;
  }
  public set form(v : FormGroup) {
    this._form = v;
  }
  
  private _ratingTypes : Observable<Array<RatingType>>;
  public get ratingTypes() : Observable<Array<RatingType>> {
    return this._ratingTypes;
  }
  public set ratingTypes(v : Observable<Array<RatingType>>) {
    this._ratingTypes = v;
  }
  
  private _categories : Observable<Array<Category>>;
  public get categories() : Observable<Array<Category>> {
    return this._categories;
  }
  public set categories(v : Observable<Array<Category>>) {
    this._categories = v;
  }
  
  
  
  constructor(private uploadService : UploadService, private formBuilder : FormBuilder, private ratingService : RatingService,  private loginService : LoginService, private categoryService : CategoryService) {
    this.form = this.formBuilder.group({
      Context : ['', Validators.minLength(7)],
      CategoryId: ['', Validators.required],
      File: ['', Validators.required], 
      RatingTypeId : [ Validators.required]
    });

   }
  ngOnInit() {
    this.ratingTypes = this.ratingService.getAll();
    this.categories = this.categoryService.GetAll();
  }
  submit(model : UploadModel){
    model.UserId = this.loginService.user.id;
    model.UploadDate = new Date();
    model.Anonymous = false;
    model.Deleted = false;
    model.Id = 0;
    model.Active = true;
    this.uploadService.insert(model).subscribe(data => console.log(data), error => console.log(error));
    
    
  }
  onFileChange(event) {
    let reader = new FileReader();
    if(event.target.files && event.target.files.length > 0) {
      let file = event.target.files[0];
      reader.readAsDataURL(file);
      reader.onload = () => {
        this.form.get('File').setValue(
          reader.result.toString().split(',')[1]
        );
        console.log(this.form.get('File').value);
        
      };
    }
    
    
  }
}
