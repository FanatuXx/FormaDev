import { httpResource } from '@angular/common/http';
import { Injectable, signal } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class AppService {
  pokemonName = signal('Pikachu')
  pokemon = httpResource<any>(() => 'https://pokeapi.co/api/v2/pokemon/' + this.pokemonName())
}
