import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-category-browse',
  templateUrl: './category-browse.component.html',
  styleUrls: ['./category-browse.component.scss']
})
export class CategoryBrowseComponent implements OnInit {
  private categoryId : number;

  constructor(private router : ActivatedRoute) { }

  ngOnInit() {
    this.router.paramMap.subscribe(data => this.categoryId = parseInt(data.get('categoryId')))
    
  }

}
