import { Routes } from '@angular/router';
import { Dashboard } from './features/dashboard/dashboard';

export const routes: Routes = [
    {
        path: '',
        redirectTo: 'dashboard',
        pathMatch: 'full'
    },
    {
        path: 'dashboard',
        loadComponent: () => import('./features/dashboard/dashboard').then((f) => f.Dashboard),
        title: 'DUNE Intranet | Dashboard',
    },
    {
        path: 'patients',
        loadChildren: () => import('./features/patients/patients.routes').then((x) => x.routes),
        title: "Dune Intranet | Ajout d'un usager",
    }

];
