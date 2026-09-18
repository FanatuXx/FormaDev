import { Routes } from '@angular/router';

export const routes: Routes = [
    // {
    //     path: 'patient',
    //     loadComponent: (): typeof 
    // },

    {
        path: 'dashboard',
        loadComponent: () => import('./features/dashboard/dashboard').then((f) => f.Dashboard),
        title: 'DUNE Intranet | Dashboard',
    },
];
