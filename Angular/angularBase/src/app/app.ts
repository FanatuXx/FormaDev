import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavBar } from './components/nav-bar/nav-bar';
import { TaskList } from './components/task-list/task-list';



@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavBar, TaskList],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected readonly title = signal('angularBase');
}
