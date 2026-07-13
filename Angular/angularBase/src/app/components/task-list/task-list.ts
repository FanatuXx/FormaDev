import { Component, WritableSignal } from '@angular/core';
import { Task, TaskPriority } from '../../lib/types/task.types.ts/taskType';
import { signal } from '@angular/core';
import { KeyValuePipe, TitleCasePipe } from '@angular/common';
import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-task-list',
  imports: [TitleCasePipe, FormsModule, KeyValuePipe],
  templateUrl: './task-list.html',
  styleUrl: './task-list.css',
})

export class TaskList { //  TaskList = TaskItem chez le prof
  protected readonly TaskPriority = TaskPriority;

  nextId: number = 1;

  titleInput: string = '';
  descInput: string = '';
  priorityInput?: TaskPriority;
  imageUrl?: string;

  myTasks:WritableSignal<Task[]> = signal([  // myTask = taskTab chez le prof
    {id: this.nextId++, 
    title: "Finir l'exercice",
    description: "Le titre en dit déjà assez",
    priority: TaskPriority.HIGH,
    done: true},

    {id: this.nextId++, 
    title: "Je commence à capter",
    description: "Mais je sens que ça va pas durer",
    priority: TaskPriority.MEDIUM,
    done: false},
    
    {id: this.nextId++, 
    title: "La synthaxe est horrible",
    description: "Genre vraiment",
    priority: TaskPriority.LOW,
    done: false},
  ]);

  addTask(): void {
    let newTask: Task = {
      id: this.nextId++,
      title: this.titleInput,
      description: this.descInput,
      priority: this.priorityInput ?? TaskPriority.LOW,
      imageUrl: this.imageUrl,
      done: false,
    };

    this.myTasks.update((t: Task[]) => [...t, newTask]);

    this.titleInput = '';
    this.descInput = '';
    this.priorityInput = undefined;
    this.imageUrl = '';
  }

}
