import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators'
import { UploadModel } from '../models/upload';

@Injectable({
  providedIn: 'root'
})
export class UploadService  {
  private url : string = environment.apiurl+"/upload"
  constructor(private http : HttpClient) { }

  public get(id : number) : Observable<UploadModel>
  {
    return this.http.get<UploadModel>(this.url).pipe(map(
      data => {console.log(data); 
      return data
    }));
  }
  public insert(upload : UploadModel){
    console.log(upload);
    
    this.http.post<UploadModel>(this.url, upload).subscribe(data => console.log(data), error => console.log(error))
    
  }
  public getAllFromCategory(categoryId : number) : Observable<Array<UploadModel>>{
    const url : string = this.url + "/bycategory/"+categoryId.toString();
    console.log(url);
    
    return this.http.get<Array<UploadModel>>(url);
  }
}