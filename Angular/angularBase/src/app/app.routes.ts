import { Routes } from '@angular/router';
import { Counter } from './components/counter/counter';
import { CounterSignal } from './components/counter-signal/counter-signal';
import { TaskList } from './components/task-list/task-list';
import { ProductComponent } from './components/product/product';

export const routes: Routes = [
    {
        path: 'counter',
        component: Counter,
    },
    {
        path: 'counters',
        loadComponent: (): typeof CounterSignal => CounterSignal
    },
    {
        path: 'task',
        loadComponent: (): typeof TaskList => TaskList
    },
    {
        path: 'product',
        loadComponent: (): typeof ProductComponent => ProductComponent
    },
];
