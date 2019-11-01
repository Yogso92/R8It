import { Component, OnInit, Input, AfterContentChecked, AfterViewInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';
import { UploadModel } from 'src/app/models/upload';
import { VoteService } from 'src/app/services/vote.service';
import { RatingService } from 'src/app/services/rating.service';
import { RatingType } from 'src/app/models/rating-type';
import { Observable, BehaviorSubject } from 'rxjs';
import { VoteModel } from 'src/app/models/vote.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-vote',
  templateUrl: './vote.component.html',
  styleUrls: ['./vote.component.scss']
})
export class VoteComponent implements OnInit {

  @Input() upload : UploadModel;
  
  
  private _ratingType : Observable<RatingType>;
  public get ratingType() : Observable<RatingType> {
    return this._ratingType;
  }
  public set ratingType(v : Observable<RatingType>) {
    this._ratingType = v;
  }
  
  private _form : FormGroup;
  public get form() : FormGroup {
    return this._form;
  }
  public set form(v : FormGroup) {
    this._form = v;
  }
  
  public get hasVoted() : Observable<boolean> {
    console.log(this.hasVotedSubject.value)
    return this.hasVotedSubject.asObservable();
  }

  private hasVotedSubject : BehaviorSubject<boolean>
  
  
  
  
  constructor(private loginService : LoginService, 
              private voteService : VoteService, 
              private ratingService : RatingService,
              private formBuilder : FormBuilder) { 
    this.form = this.formBuilder.group({
      userId : ['', Validators.required],
      uploadId : ['', Validators.required],
      comment : '',
      rateChoiceId : ['', Validators.required],
      id: ''
    });
    
    this.hasVotedSubject = new BehaviorSubject<boolean>(false);
    
    //console.log(this.loginService.user)
    
  }

  ngOnInit() {
    this.ratingType = this.ratingService.get(this.upload.ratingTypeId);
    this.form.get('userId').setValue(this.loginService.user.id);
    this.form.get('uploadId').setValue(this.upload.id);
    this.form.get('id').setValue(0);
    this.voteService.hasVoted(this.loginService.user.id, this.upload.id)
                    .subscribe(data => {this.hasVotedSubject.next(data); console.log(data)});
    
    
  }

  submitVote(vote : VoteModel) : Observable<Array<VoteModel>>{
    return this.voteService.submit(vote);
  }

}
