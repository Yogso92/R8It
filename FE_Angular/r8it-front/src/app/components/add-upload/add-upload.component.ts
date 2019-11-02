import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { UploadService } from 'src/app/services/upload.service';
import { UploadModel } from 'src/app/models/upload';
import { LoginService } from 'src/app/services/login.service';
import { RatingService } from 'src/app/services/rating.service';
import { RatingType } from 'src/app/models/rating-model';
import { Observable } from 'rxjs';
import { CategoryService } from 'src/app/services/category.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-upload',
  templateUrl: './add-upload.component.html',
  styleUrls: ['./add-upload.component.scss']
})
export class AddUploadComponent implements OnInit {

  
  
  private _firstStep : FormGroup;
  public get firstStep() : FormGroup {
    return this._firstStep;
  }
  public set firstStep(v : FormGroup) {
    this._firstStep = v;
  }

  
  private _secondStep : FormGroup;
  public get secondStep() : FormGroup {
    return this._secondStep;
  }
  public set secondStep(v : FormGroup) {
    this._secondStep = v;
  }
  
  private _thirdStep : FormGroup;
  public get thirdStep() : FormGroup {
    return this._thirdStep;
  }
  public set thirdStep(v : FormGroup) {
    this._thirdStep = v;
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
  
  private _fileUploading : boolean;
  public get fileUploading() : boolean {
    return this._fileUploading;
  }
  public set fileUploading(v : boolean) {
    this._fileUploading = v;
  }

  public sending : boolean;
  
  
  
  
  
  
  constructor(private uploadService : UploadService, 
              private formBuilder : FormBuilder, 
              private ratingService : RatingService,  
              private loginService : LoginService, 
              private categoryService : CategoryService,
              private router : Router) {
    

    this.firstStep = this.formBuilder.group({
      file : ['', Validators.required]
    });

    this.secondStep = this.formBuilder.group({
      context : ['', Validators.minLength(5) ],
      categoryId : ['', Validators.required]
    })

    this.thirdStep = this.formBuilder.group({
      ratingTypeId : ['', Validators.required]
    })

   }
  ngOnInit() {
    this.ratingTypes = this.ratingService.getAll();
    this.categories = this.categoryService.GetAll();
  }
  submit(model : UploadModel){
    this.sending = true;
    model.userId = this.loginService.user.id;
    model.uploadDate = new Date();
    model.anonymous = false;
    model.deleted = false;
    model.id = 0;
    model.active = true;
    model.result = 0;
    model.limitDate = model.uploadDate;
    console.log("sending")
    this.uploadService.insert(model).subscribe(data => this.sending=false, error => console.log(error));
    
    
  }

  firstStepComplete(){
    this.firstStep.markAsDirty();
  }

  secondStepComplete(){
    this.secondStep.markAsDirty();
  }

  thirdStepComplete(){
    this.thirdStep.markAsDirty();
    let model : UploadModel = {
      categoryId : this.secondStep.get('categoryId').value,
      context : this.secondStep.get('context').value,
      fileString : this.firstStep.get('file').value,
      file : null,
      ratingTypeId: this.thirdStep.get('ratingTypeId').value
    }
    console.log("third step ok")
    this.submit(model);
  }


  onFileChange(event) {
    let reader = new FileReader();
    if(event.target.files && event.target.files.length > 0) {
      let file = event.target.files[0];
      reader.readAsDataURL(file);
      reader.onload = () => {
        this.firstStep.get('file').setValue(
          reader.result.toString().split(',')[1]
        );
        
      };
    }
  }
}
