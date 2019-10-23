import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  private url : string = environment.apiurl+"/category"
  constructor(private http : HttpClient) { }

  public GetAll() : Observable<Array<Category>>
  {
    return this.http.get<Array<Category>>(this.url).pipe(map(
      data => {console.log(data); 
      return data
    }));
  }
}
