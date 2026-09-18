import { Routes } from "@angular/router";

export const routes: Routes = [
    {
        path: 'new',
        loadComponent: () => import('./patient-creation/patient-creation')
            .then(f => f.PatientCreation),
        title: "Dune Intranet | Ajout d'un usager"
    },
    // {
    //     path: ':id',
    //     loadComponent: () => import("./patient-detail/patient-detail")
    //         .then(f => f.PatientDetail)
    // },


]