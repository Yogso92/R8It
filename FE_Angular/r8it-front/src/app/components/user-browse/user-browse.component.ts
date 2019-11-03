import { Component, OnInit, Input } from '@angular/core';
import { Observable } from 'rxjs';
import { UploadModel } from 'src/app/models/upload';
import { LoginService } from 'src/app/services/login.service';
import { UploadService } from 'src/app/services/upload.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user-browse',
  templateUrl: './user-browse.component.html',
  styleUrls: ['./user-browse.component.scss']
})
export class UserBrowseComponent implements OnInit {
  @Input() userId : number;
  
  private _uploads : Observable<Array<UploadModel>>;
  public get uploads() : Observable<Array<UploadModel>> {
    return this._uploads;
  }
  public set uploads(v : Observable<Array<UploadModel>>) {
    this._uploads = v;
  }
  
  constructor(private loginService : LoginService, private uploadService : UploadService, private route : ActivatedRoute) { 
    
  }

  ngOnInit() {
    if(this.route.snapshot.paramMap.get('userId') == null){
      this.userId = this.loginService.user.id;
    }
    else{
      this.userId = parseInt(this.route.snapshot.paramMap.get('userId'));
    }

    this.uploads = this.uploadService.getAllFromUser(this.userId);
  }

}
