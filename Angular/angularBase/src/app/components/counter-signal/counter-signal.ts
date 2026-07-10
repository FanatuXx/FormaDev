import { Component, signal } from '@angular/core';

@Component({
  selector: 'app-counter-signal',
  imports: [],
  templateUrl: './counter-signal.html',
  styleUrl: './counter-signal.css',
})
export class CounterSignal {

  countSignal = signal(50);

  resetSignal() {
    this.countSignal.set(0);
  }

  incrementSignal() {
    this.countSignal.update(old => old + 1);
  }

  decrementSignal() {
    this.countSignal.update(old => old - 1);
  }
}
