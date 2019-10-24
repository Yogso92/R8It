import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class UploadService  {
  private url : string = environment.apiurl+"/upload"
  constructor(private http : HttpClient) { }

  public get(id : number) : Observable<any>
  {
    return this.http.get<any>(this.url).pipe(map(
      data => {console.log(data); 
      return data
    }));
  }
  public insert(upload : any){
    return this.http.post<any>(this.url, upload)
  }
}