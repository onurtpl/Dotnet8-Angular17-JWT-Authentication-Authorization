import { Route, } from '@angular/router';

export const homeRoutes: Route[] = [
    {
        path: '',
        loadComponent: () => import('./pages/home-main/home-main.component').then(mod => mod.HomeMainComponent)
    },
    {
        path: 'detail',
        loadComponent: () => import('./pages/home-detail/home-detail.component').then(mod => mod.HomeDetailComponent)
    },
]
   