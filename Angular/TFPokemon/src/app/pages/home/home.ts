import { Component, inject, signal } from '@angular/core';
import { AppService } from '../../services/app-service';
import { Loader } from '../../components/loader/loader';

@Component({
  imports: [Loader],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  
  appService = inject(AppService)
}
