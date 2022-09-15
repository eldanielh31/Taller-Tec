import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BackendService } from 'src/app/backend.service';
import { StorageService } from 'src/app/storage.service';
import appointmentData from 'API/Database/Tables/appointments.json'

interface Appointment{
  clientName: String;
  plate: Number;
  store: String;
  service: String;
}

@Component({
  selector: 'app-tables',
  templateUrl: './tables.component.html',
  styleUrls: ['./tables.component.scss']
})
export class TablesComponent implements OnInit {

  constructor(private router: Router, private localStorage: StorageService, private backend: BackendService) { }

  ngOnInit() {

  }
  
  handleclick(){
    this.router.navigate(['/appointments'])
  }

  appointments:Appointment[]=appointmentData;
}
