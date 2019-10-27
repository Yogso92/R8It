import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { UploadComponent } from './components/upload/upload.component';
import { RegisterComponent } from './components/register/register.component';
import { CategoryBrowseComponent } from './components/category-browse/category-browse.component';


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
    path: "upload",
    component: UploadComponent
  }
  ,
  {
    path: "register",
    component: RegisterComponent
  },
  {
    path: 'browse/category/:categoryId',
    component: CategoryBrowseComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
