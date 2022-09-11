import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { StorageService } from 'src/app/storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {

  constructor(private localStorage: StorageService, private router: Router) {}

  email: string = ''
  password: string = ''

  ngOnInit() {
  }
  ngOnDestroy() {
  }

  handleLogin(){
    this.localStorage.saveData('email', this.email)
    this.localStorage.saveData('password', this.password)

    this.router.navigate(['/dashboard'])
  }


}
