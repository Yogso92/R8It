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

  public submit(vote : VoteModel) : Observable<number>{
    return this.http.post<number>(this._endpoint, vote)
  }
  public canVote(userId : number, uploadId : number) : Observable<boolean>{
    const url : string = this._endpoint + "/canvote/"+userId.toString()+"/"+uploadId.toString();
    return this.http.get<boolean>(url);
  }

}
