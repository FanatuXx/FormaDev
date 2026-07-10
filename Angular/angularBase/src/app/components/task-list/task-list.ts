import { Component } from '@angular/core';
import { Task } from '../../lib/types/task.types.ts/taskType';
import { signal } from '@angular/core';

@Component({
  selector: 'app-task-list',
  imports: [],
  templateUrl: './task-list.html',
  styleUrl: './task-list.css',
})

export class TaskList {

  myTasks = signal([
    {id: 1, 
    title: "Finir l'exercice",
    description: "Le titre en dit déjà assez",
    priority: 10,
    done: true},

    {id: 2,
    title: "Je commence à capter",
    description: "Mais je sens que ça va pas durer",
    priority: 6,
    done: false},
    
    {id: 3,
    title: "La synthaxe est horrible",
    description: "Genre vraiment",
    priority: 3,
    done: false},
  ]);

  

}
