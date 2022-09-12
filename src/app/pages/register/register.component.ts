import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  public checkWorker: Boolean

  first: String;
  last: String;
  phone: String;
  identification: String;
  address: String;
  email: String;
  password: String;
  entered: String;
  birth: String;
  role: String;

  constructor() {}

  ngOnInit() {
  }

  handleRegister(){
    console.log(this.first, this.last, this.phone, this.identification,
      this.address, this.email, this.password, this.entered, this.birth, this.role)
  }
  
}
