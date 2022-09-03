import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  public loginForm:FormGroup;

  username: string = ''
  password: string = ''

  constructor(private formBuilder: FormBuilder) {
    this.loginForm = this.formBuilder.group({
      username: '',
      password: ''
    });
  }
  handleLogin() {
    this.username = this.loginForm.get('username')?.value;
    console.log(this.username);
    this.password = this.loginForm.get('password')?.value;
    console.log(this.password);
  }

  ngOnInit(): void {
  }

  


}
