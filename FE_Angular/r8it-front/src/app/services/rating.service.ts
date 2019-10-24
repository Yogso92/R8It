import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators'

@Injectable({
  providedIn: 'root'
})
export class RatingService  {
  private url : string = environment.apiurl+"/Rating"
  constructor(private http : HttpClient) { }

  public getAll() : Observable<any>
  {
    return this.http.get<any>(this.url).pipe(map(
      data => {console.log(data); 
      return data
    }));
  }
}
