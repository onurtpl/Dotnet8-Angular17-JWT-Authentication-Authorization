import { Routes } from '@angular/router';
import { authGuard } from './common/guards/auth.guard';

export const routes: Routes = [
    {
        path: '',
        loadComponent: () => 
            import('./layouts/home/home.component').then(mod => mod.HomeComponent),
        loadChildren: () => import('./layouts//home/home.routes').then(mod => mod.homeRoutes)
    },
    {
        path: 'auth',
        loadComponent: () => 
            import('./layouts/auth/auth.component').then(mod => mod.AuthComponent),
        loadChildren: () => import('./layouts/auth/auth.routes').then(mod => mod.authRoutes)

    },
    {
        path: 'web-admin',
        loadComponent: () => 
            import('./layouts/admin/admin.component').then(mod => mod.AdminComponent),
        canActivate: [authGuard],
        loadChildren: () => import('./layouts/admin/admin.routes').then(mod => mod.adminRoutes)
    }
];
