import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavBar } from './layout/nav-bar/nav-bar';
import { PatientCreation } from './features/patients/patient-creation/patient-creation';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, PatientCreation],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('PFF.Angular');
}
