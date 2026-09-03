import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '', 
        redirectTo: 'games',
        pathMatch: 'full',
    },

    {
        path: 'games',
        loadChildren:   () => import("./features/games/games.routes")
            .then(x => x.routes)
    },

    {
        path: 'games',
        loadChildren:   () => import("./features/games/games.routes")
            .then(x => x.routes)
    },

    {
        path: 'register',
        loadComponent: () => import("./features/auth/register/register").then(f => f.Register),
        title: "Inscription",
    },

    {
        path: 'login',
        loadComponent: () => import("./features/auth/login/login").then(f => f.Login),
        title: "GuildOps | Login",
    }
];
