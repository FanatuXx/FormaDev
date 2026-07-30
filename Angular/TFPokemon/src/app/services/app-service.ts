import { httpResource } from '@angular/common/http';
import { effect, Injectable, Signal, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AppService {
  pokemonName = signal('Pikachu')
  selectedPokemon = signal<any | undefined>(undefined)
  
  findPokemon(name: Signal<string>) {
    effect(() => {
      this.pokemonName.set(name())
    })
    return httpResource<any>(() => ({
    url: 'https://pokeapi.co/api/v2/pokemon/' + name()
  }))
  }
}
