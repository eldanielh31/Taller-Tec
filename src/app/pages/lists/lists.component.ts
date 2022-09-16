import { Component, OnInit } from '@angular/core';
import workerData from 'API/Database/Tables/employees.json';

interface Worker{
  idNumber: Number;
  identification: Number;
  name: String,
  lastName: String;
  cellphoneNumber: Number;
  joiningDate: String;
  birthDate: String;
  age: Number;
  role: String;
  branch: String;
  email: String;
  address: String;
  username: String;
  password: String;
}

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.css']
})



export class ListsComponent implements OnInit {
  data: Array<any>;
  constructor() { 
    this.data = [
      { firstName: 'John', lastName: 'Doe', age: '35' },
      { firstName: 'Michael', lastName: 'Smith', age: '39' },
      { firstName: 'Michael', lastName: 'Jordan', age: '45' },
      { firstName: 'Tanya', lastName: 'Blake', age: '47' }
  ];
    
  }

  ngOnInit(): void {
  }

  
  workers: Worker[] = workerData; 
  handleclick(){
    
  }

  
}
