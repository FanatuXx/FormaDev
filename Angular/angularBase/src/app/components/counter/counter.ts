import { Component } from '@angular/core';

@Component({
  selector: 'app-counter',
  imports: [],
  templateUrl: './counter.html',
  styleUrl: './counter.css',
})

export class Counter {
  count: number = 0;

  add1() {
    this.count++;
  };

  subtract1() {
    this.count--;
  };

  reset() {
    this.count = 0;
  };
}
