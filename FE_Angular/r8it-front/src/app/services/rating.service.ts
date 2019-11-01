import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators'
import { RatingType } from '../models/rating-model';

@Injectable({
  providedIn: 'root'
})
export class RatingService  {
  private _endpoint : string = environment.apiurl+"/Rating"
  constructor(private http : HttpClient) { }

  public getAll() : Observable<any>
  {
    return this.http.get<Array<RatingType>>(this._endpoint).pipe(map(
      data => {console.log(data); 
      return data
    }));
  }
  public get(id : number) : Observable<RatingType>{
    const url : string = this._endpoint+"/"+id.toString()
    return this.http.get<RatingType>(url)
  }
}
