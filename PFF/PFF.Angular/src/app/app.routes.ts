import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: 'patients',
        loadChildren: () => import('./features/patients/patients.routes').then((x) => x.routes),
        title: "Dune Intranet | Ajout d'un usager",
    },
    {
        path: 'dashboard',
        loadComponent: () => import('./features/dashboard/dashboard').then((f) => f.Dashboard),
        title: 'DUNE Intranet | Dashboard',
    },
];
