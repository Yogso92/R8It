import { Component, OnInit } from '@angular/core';
import { UploadService } from 'src/app/services/upload.service';
import { RatingService } from 'src/app/services/rating.service';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.scss']
})
export class UploadComponent implements OnInit {

  
  private _ratings : Array<any>;
  public get ratings() : Array<any> {
    return this._ratings;
  }
  public set ratings(v : Array<any>) {
    this._ratings = v;
  }
  
  constructor(private uploadService : UploadService, private ratingService : RatingService) { }

  ngOnInit() {
    this.ratingService.getAll().subscribe(data => this.ratings = data)
  }

}
