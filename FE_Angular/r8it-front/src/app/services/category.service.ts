import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators'
import { UploadModel } from '../models/upload';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private _endpoint : string = environment.apiurl+"/category"
  constructor(private http : HttpClient) { }

  public GetAll() : Observable<Array<Category>>
  {
    return this.http.get<Array<Category>>(this._endpoint).pipe(map(
      data => { 
      return data
    }));
  }
  public getAllFromCategory(categoryId : number) : Observable<Array<UploadModel>>{
    const url : string = this._endpoint + "/"+categoryId.toString();
    return this.http.get<Array<UploadModel>>(url);
  }
  
}
