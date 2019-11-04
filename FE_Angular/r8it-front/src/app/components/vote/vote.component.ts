import { Component, OnInit, Input, AfterContentChecked, AfterViewInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';
import { UploadModel } from 'src/app/models/upload';
import { VoteService } from 'src/app/services/vote.service';
import { RatingService } from 'src/app/services/rating.service';
import { RatingType } from 'src/app/models/rating-model';
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
  
  public get canVote() : Observable<boolean> {
    console.log(this.canVoteSubject.value)
    return this.canVoteSubject.asObservable();
  }
  
  private _results : Array<VoteModel>;
  public get results() : Array<VoteModel> {
    return this._results;
  }
  public set results(v : Array<VoteModel>) {
    this._results = v;
  }
  get status() {
    if (this.upload.result <= 25) {
      return 'danger';
    } else if (this.upload.result <= 50) {
      return 'warning';
    } else if (this.upload.result <= 75) {
      return 'info';
    } else {
      return 'success';
    }
  }
  

  private canVoteSubject : BehaviorSubject<boolean>
  
  
  
  
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
    
    this.canVoteSubject = new BehaviorSubject<boolean>(false);
    
    //console.log(this.loginService.user)
    
  }

  ngOnInit() {
    this.ratingType = this.ratingService.get(this.upload.ratingTypeId);
    this.form.get('userId').setValue(this.loginService.user.id);
    this.form.get('uploadId').setValue(this.upload.id);
    this.form.get('id').setValue(0);
    this.voteService.canVote(this.loginService.user.id, this.upload.id)
                    .subscribe(data => {this.canVoteSubject.next(data); console.log(data)});
    
    
  }

  submitVote(vote : VoteModel){
    this.canVoteSubject.next(false);
    vote.rateChoiceId = parseInt(vote.rateChoiceId.toString());
    this.voteService.submit(vote).subscribe(data => this.upload.result = data);
  }

}
