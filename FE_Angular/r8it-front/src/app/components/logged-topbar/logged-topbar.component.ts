import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-logged-topbar',
  templateUrl: './logged-topbar.component.html',
  styleUrls: ['./logged-topbar.component.scss']
})
export class LoggedTopbarComponent implements OnInit {

  constructor(private loginService : LoginService, private router : Router) { }

  ngOnInit() {
  }
  logout(){
    this.loginService.logout();
  }

}
