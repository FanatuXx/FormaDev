import { Routes } from "@angular/router";

export const routes: Routes = [
    {
        path: '',
        loadComponent: () => import("./games-list/games-list")
            .then(f => f.GamesList)
    },

    {
        path: ':id', // :id => permet de dire qu'on doit récupérer une variable DYNAMIQUE (variable)
        loadComponent: () => import("./game-detail/game-detail")
            .then(f => f.GameDetail)        
    }
];