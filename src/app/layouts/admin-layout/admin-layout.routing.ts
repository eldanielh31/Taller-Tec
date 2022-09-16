import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { MapsComponent } from '../../pages/maps/maps.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { AuthGuardService } from 'src/app/auth/auth-guard.service';
import { ListsComponent } from 'src/app/pages/lists/lists.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuardService]},
    { path: 'user-profile', component: UserProfileComponent, canActivate: [AuthGuardService] },
    { path: 'tables', component: TablesComponent, canActivate: [AuthGuardService] },
    { path: 'appointments', component: MapsComponent, canActivate: [AuthGuardService] },
    { path: 'lists', component: ListsComponent, canActivate: [AuthGuardService] }
];
