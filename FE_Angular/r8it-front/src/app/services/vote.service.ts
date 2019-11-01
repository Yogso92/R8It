import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { VoteModel } from '../models/vote.model';

@Injectable({
  providedIn: 'root'
})
export class VoteService {

  private _endpoint : string = environment.apiurl+"/vote"
  constructor(private http : HttpClient) { }

  public submit(vote : VoteModel) : Observable<Array<VoteModel>>{
    return this.http.post<Array<VoteModel>>(this._endpoint, vote)
  }
  public hasVoted(userId : number, uploadId : number) : Observable<boolean>{
    const url : string = this._endpoint + "/hasvoted/"+userId.toString()+"/"+uploadId.toString();
    return this.http.get<boolean>(url);
  }

}
