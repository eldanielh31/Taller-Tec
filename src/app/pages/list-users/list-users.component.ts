import { Component, OnInit } from '@angular/core';
import { CommonModule } from "@angular/common";


interface User {
  identification: number,
  name: string
}

@Component({
  selector: 'app-list-users',
  templateUrl: './list-users.component.html',
  styleUrls: ['./list-users.component.css']
})
export class ListUsersComponent implements OnInit {

  users:User[];

  constructor() {

    this.users = [
      {
        identification : 2213,
        name : 'DaniGames'
      }
    ]

   }

  ngOnInit(): void {
  }

}
