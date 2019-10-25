import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { Country } from '../models/country';

@Injectable({
  providedIn: 'root'
})
export class CountryService {

  private _endpoint : string = environment.apiurl+"/country"
  
  constructor(private http : HttpClient) { }

  public Get() : Observable<Array<Country>>{
    return this.http.get<Array<Country>>(this._endpoint);
  }
}
