import { Route, } from '@angular/router';

export const authRoutes: Route[] = [
    {
        path: 'login',
        loadComponent: () => import('./pages/login/login.component').then(mod => mod.LoginComponent)
    },
    {
        path: 'register',
        loadComponent: () => import('./pages/register/register.component').then(mod => mod.RegisterComponent)
    },
    {
        path: 'forgot-password',
        loadComponent: () => 
            import('./pages/forgot-password/forgot-password.component').then(mod => mod.ForgotPasswordComponent)
    },
    {
        path: 'reset-password',
        loadComponent: () => 
            import('./pages/reset-password/reset-password.component').then(mod => mod.ResetPasswordComponent)
    },
]
   