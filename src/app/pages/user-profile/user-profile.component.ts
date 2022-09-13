import { Component, OnInit } from '@angular/core';
import { StorageService } from 'src/app/storage.service';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.scss']
})
export class UserProfileComponent implements OnInit {

  currentUser : Object = {};
  isWorker : Boolean = true;
  identification: String;
  password: String;
  firstName: String;
  lastName: String;
  dateEntered: String;
  dateBirth: String;
  role: String;
  address: String;
  phone: String;
  email: String;

  constructor(private localStorage: StorageService) { 

    this.currentUser = JSON.parse(this.localStorage.getData('user'));
    // this.isWorker = this.currentUser['isWorker']

  }

  ngOnInit() {
  }

  handleUpdate(){

    let listData = ['identification', 'password', 'firstName', 'lastName',
      'dateBirth', 'dateEntered', 'role', 'address', 'phone', 'email']
    let dataToUpdate = [this.identification ,this.password, this.firstName, this.lastName,
      this.dateBirth, this.dateEntered, this.role, this.address, this.phone, this.email]
    
    let con = 0;
    dataToUpdate.forEach(element => {
      if (element !== null || element !== ''){
        this.currentUser[listData[con]] = element
      }
    });

    this.localStorage.saveData('user', JSON.stringify(this.currentUser))
    window.location.reload()

  }

}
