import { Routes } from '@angular/router';
import { Home } from './pages/home/home';
import { About } from './pages/about/about';
import { Stats } from './pages/stats/stats';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', loadComponent: () => Home },
    { path: 'about', loadComponent: () => About },
    { path: 'stats', loadComponent: () => Stats },
];
