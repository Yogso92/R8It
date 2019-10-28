import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { UploadModel } from 'src/app/models/upload';
import { CategoryService } from 'src/app/services/category.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-category-browse',
  templateUrl: './category-browse.component.html',
  styleUrls: ['./category-browse.component.scss']
})
export class CategoryBrowseComponent implements OnInit {
  private categoryId : number;
  
  private _uploads : Observable<Array<UploadModel>>;
  public get uploads() : Observable<Array<UploadModel>> {
    return this._uploads;
  }
  public set uploads(v : Observable<Array<UploadModel>>) {
    this._uploads = v;
  }
  

  constructor(private router : ActivatedRoute, private categoryService : CategoryService) { }

  ngOnInit() {
    this.router.paramMap.subscribe(data => {
      this.categoryId = parseInt(data.get('categoryId'))
      this.uploads = this.categoryService.getAllFromCategory(this.categoryId).pipe(map(item => {console.log(item); return item}))
    });
    
  }

}