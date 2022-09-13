import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from 'src/app/backend.service';
import { StorageService } from 'src/app/storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit, OnDestroy {

  constructor(private localStorage: StorageService, private router: Router, private backend: BackendService) { }

  email: string = ''
  password: string = ''

  ngOnInit() {
  }
  ngOnDestroy() {
  }

  handleLogin() {
    // this.localStorage.saveData('user', JSON.stringify(
    //   { 
    //   'email': this.email, 
    //   'password': this.password,
    //   'name': 'Daniel',
    //   'age': 23,
    //   'address' : 'Cartago',
    //   'phone' : '62686940',
    //   'identification' : '305180081',
    //   'role' : 'Enginner',
    //   }
    //   ))

    this.backend.getEmploye(this.email).subscribe(
      (ret: any[]) => {
        console.log(ret);
      }
    )

    // this.router.navigate(['/dashboard'])
  }


}
