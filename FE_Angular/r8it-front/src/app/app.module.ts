import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NbThemeModule, NbLayoutModule, NbSidebarModule, NbMenuModule, NbButtonModule, NbInputModule, NbListModule, NbCardModule, NbIconModule, NbDialogModule, NbSpinnerModule, NbUserModule, NbPopoverModule, NbAlertModule, NbSelectModule } from '@nebular/theme';
import { NbEvaIconsModule } from '@nebular/eva-icons';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeComponent } from './components/home/home.component';
import { TokenInterceptor } from './interceptors/token-interceptor';
import { LoginComponent } from './components/login/login.component';
import { SideMenuComponent } from './components/side-menu/side-menu.component';
import { LoginService } from './services/login.service';
import { LoggedTopbarComponent } from './components/logged-topbar/logged-topbar.component';
import { UploadComponent } from './components/upload/upload.component';
import { RegisterComponent } from './components/register/register.component';
import { CategoryBrowseComponent } from './components/category-browse/category-browse.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    SideMenuComponent,
    LoggedTopbarComponent,
    UploadComponent,
    RegisterComponent,
    CategoryBrowseComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    NbThemeModule.forRoot({ name: 'dark' }),
    NbLayoutModule,
    NbEvaIconsModule,
    HttpClientModule,
    NbThemeModule.forRoot({ name: 'dark' }),
    NbLayoutModule,
    NbEvaIconsModule,
    NbSidebarModule.forRoot(),
    NbMenuModule.forRoot(),
    NbButtonModule,
    NbInputModule,
    FormsModule,
    NbListModule,
    NbCardModule,
    NbIconModule,
    NbDialogModule.forRoot(),
    NbSpinnerModule,
    NbUserModule,
    NbPopoverModule,
    NbAlertModule,
    ReactiveFormsModule,
    NbSelectModule
  ],
  providers: 
  [
    LoginService,
    {
      provide: HTTP_INTERCEPTORS, 
      useClass : TokenInterceptor, 
      multi : true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
