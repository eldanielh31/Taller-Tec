import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { BackendService } from 'src/app/backend.service';
import { StorageService } from 'src/app/storage.service';
// import appointmentData from 'API/Database/Tables/appointments.json'

interface Appointment {
  idAppointment: number,
  idService: number,
  idClient: number,
  clientName: string,
  clientLastName: string,
  idEmployee: number,
  employeeName: string,
  employeeLastName: string
}

@Component({
  selector: 'app-lists',
  templateUrl: './lists.component.html',
  styleUrls: ['./lists.component.scss']
})
export class ListsComponent implements OnInit {

  appointments: Appointment[];
  currentUser: Object = {};

  constructor(private router: Router, private localStorage: StorageService, private backend: BackendService) {
    
  }

  ngOnInit() {

  }

  handleclick() {
    this.router.navigate(['/appointments'])
  }
}
