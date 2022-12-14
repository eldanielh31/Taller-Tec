import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StorageService } from 'src/app/storage.service';

declare interface RouteInfo {
    path: string;
    title: string;
    icon: string;
    class: string;
}
export const ROUTES: RouteInfo[] = [
    { path: '/dashboard', title: 'Dashboard',  icon: 'ni-tv-2 text-primary', class: '' },
    { path: '/tables', title: 'Appointments',  icon:'ni-calendar-grid-58 text-green', class: '' },
    { path: '/user-profile', title: 'User profile',  icon:'ni-single-02 text-yellow', class: '' },
    { path: '/users/clients', title: 'Clients lists', icon: 'ni-bullet-list-67 text-red', class: '' },
    { path: '/users/workers', title: 'Workers lists', icon: 'ni-bullet-list-67 text-red', class: '' }
];

export const NORMALROUTES: RouteInfo[] = [
  { path: '/dashboard', title: 'Dashboard', icon: 'ni-tv-2 text-primary', class: '' },
  { path: '/tables', title: 'Appointments', icon: 'ni-calendar-grid-58 text-green', class: '' },
  { path: '/user-profile', title: 'User profile', icon: 'ni-single-02 text-yellow', class: '' },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  public menuItems: any[];
  public isCollapsed = true;
  currentUser: Object = {};

  constructor(private localStorage:StorageService, private router: Router) { }

  ngOnInit() {

    this.currentUser = JSON.parse(this.localStorage.getData('user'));

    this.menuItems = this.currentUser['admin'] ? ROUTES.filter(menuItem => menuItem) : NORMALROUTES.filter(menuItem => menuItem) ;
    this.router.events.subscribe((event) => {
      this.isCollapsed = true;
   });
  }

  handleLogout() {
    this.localStorage.removeData('user')
  }
}
