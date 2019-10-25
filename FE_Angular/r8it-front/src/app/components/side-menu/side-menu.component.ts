import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/services/category.service';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { MenuItem } from 'src/app/models/menu-items';

@Component({
  selector: 'app-side-menu',
  templateUrl: './side-menu.component.html',
  styleUrls: ['./side-menu.component.scss']
})
export class SideMenuComponent implements OnInit {
  
  
  
  private _items : Array<MenuItem>;
  public get items() : Array<MenuItem> {
    return this._items;
  }
  public set items(v : Array<MenuItem>) {
    this._items = v;
  }
  
  
  constructor(private categoryService : CategoryService) {
    this.items = []
   }

  ngOnInit() {
    this.categoryService.GetAll().subscribe(data => data.forEach(item => this.items.push(this.mapCatToMenuItem(item))));
  }

  private mapCatToMenuItem(cat : Category){
    return {title: cat.name, link: 'browse/'+cat.name, icon : cat.icon}
  }

}
