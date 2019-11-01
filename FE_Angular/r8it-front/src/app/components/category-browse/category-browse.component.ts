import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { UploadModel } from 'src/app/models/upload';
import { UploadService } from 'src/app/services/upload.service';

@Component({
  selector: 'app-category-browse',
  templateUrl: './category-browse.component.html',
  styleUrls: ['./category-browse.component.scss']
})
export class CategoryBrowseComponent implements OnInit {
  public categoryId : number;
  
  private _uploads : Observable<Array<UploadModel>>;
  public get uploads() : Observable<Array<UploadModel>> {
    return this._uploads;
  }
  public set uploads(v : Observable<Array<UploadModel>>) {
    this._uploads = v;
  }
  

  constructor(private router : ActivatedRoute, private uploadService : UploadService) { }

  ngOnInit() {
    this.router.paramMap.subscribe(data => {
      this.categoryId = parseInt(data.get('categoryId'))
      this.uploads = this.uploadService.getAllFromCategory(this.categoryId)
      
    });
    
  }

}
