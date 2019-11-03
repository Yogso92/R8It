import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { UploadComponent } from './components/upload/upload.component';
import { RegisterComponent } from './components/register/register.component';
import { CategoryBrowseComponent } from './components/category-browse/category-browse.component';
import { AddUploadComponent } from './components/add-upload/add-upload.component';
import { UserBrowseComponent } from './components/user-browse/user-browse.component';


const routes: Routes = [
  {
    path: "", 
    redirectTo: "home", 
    pathMatch: "full"
  },
  {
    path: "home",
    component: HomeComponent
  },
  {
    path: 'upload/new',
    component : AddUploadComponent
  },
  {
    path: "uploads",
    component: UploadComponent,
    pathMatch : 'full'
  }
  ,
  {
    path: "register",
    component: RegisterComponent
  },
  {
    path: 'browse/category/:categoryId',
    component: CategoryBrowseComponent
  },
  {
    path : 'self', 
    component : UserBrowseComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
