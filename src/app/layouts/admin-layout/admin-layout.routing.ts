import { Routes } from '@angular/router';

import { DashboardComponent } from '../../pages/dashboard/dashboard.component';
import { MapsComponent } from '../../pages/maps/maps.component';
import { UserProfileComponent } from '../../pages/user-profile/user-profile.component';
import { TablesComponent } from '../../pages/tables/tables.component';
import { AuthGuardService } from 'src/app/auth/auth-guard.service';
import { EditUserComponent } from 'src/app/pages/edit-user/edit-user.component';
import { ListUsersComponent } from 'src/app/pages/list-users/list-users.component';

export const AdminLayoutRoutes: Routes = [
    { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuardService]},
    { path: 'user-profile', component: UserProfileComponent, canActivate: [AuthGuardService] },
    { path: 'tables', component: TablesComponent, canActivate: [AuthGuardService] },
    { path: 'appointments', component: MapsComponent, canActivate: [AuthGuardService] },
    { path: 'user/:userType/:userId', component: EditUserComponent, canActivate: [AuthGuardService] },
    { path: 'users/:userType', component: ListUsersComponent, canActivate: [AuthGuardService] },
];
