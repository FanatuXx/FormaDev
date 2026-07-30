import { Component, effect, inject, signal } from '@angular/core';
import { AppService } from '../../services/app-service';
import { Loader } from '../../components/loader/loader';

@Component({
  imports: [Loader],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  
  appService = inject(AppService)

  pokemonName = signal('pikachu');
  private pokemonResource = this.appService.findPokemon(this.pokemonName);
  pokemon = this.pokemonResource.value;
  pokemonIsLoading = this.pokemonResource.isLoading;

  private pokemonEffect = effect(() => {
    this.appService.selectedPokemon.set(this.pokemon())
  })
}
