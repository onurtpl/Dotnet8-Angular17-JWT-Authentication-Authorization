import { Route, } from '@angular/router';
import { roleGuard } from '../../common/guards/role.guard';

export const adminRoutes: Route[] = [
    {
        path: 'user-list',
        loadComponent: () => 
            import('./pages/user-list/user-list.component').then(mod => mod.UserListComponent)
    },
    {
        path: 'user-detail',
        loadComponent: () => 
            import('./pages/user-detail/user-detail.component').then(mod => mod.UserDetailComponent),
        canActivate: [roleGuard],
        data: {
            roles: ['Admin']
        }
    },
    
]
   