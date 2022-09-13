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
  isError: boolean = false

  ngOnInit() {
  }
  ngOnDestroy() {
  }

  handleLogin() {
    this.backend.getEmploye(this.email).subscribe(
      (data : Object) => {
        data['admin'] = true;
        console.log(data);
        
        this.localStorage.saveData('user', JSON.stringify(data))
        this.router.navigate(['/dashboard'])
        return
      }, (error => {
        console.log(error['status'])
      })
    )
    this.backend.getClient(this.email).subscribe(
      (data: Object) => {
        data['admin'] = false;
        console.log(data);
        
        this.localStorage.saveData('user', JSON.stringify(data))
        this.router.navigate(['/dashboard'])
        return
      }, (error => {
        console.log(error['status'])
      })

    )

    this.isError = true
    
    return
  }


}
