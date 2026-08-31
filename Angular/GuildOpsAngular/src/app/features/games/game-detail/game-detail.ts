import { Component, inject, input, OnInit, signal } from '@angular/core';
import { GamesService } from '../../../core/services/games.service';
import { ActivatedRoute } from '@angular/router';
import { GameDetails } from '../../../shared/models/game.model';

@Component({
  imports: [],
  selector: 'app-game-details',
  styleUrl: './game-details.css',
  templateUrl: './game-detail.html',
})
export class GameDetail implements OnInit {

  private readonly activatedRoute = inject(ActivatedRoute);
  private readonly gamesService: GamesService = inject(GamesService);

  //Permet de récupérer directement depuis les params
  //grâce à WithComponentInputBinding() dans app.config.ts
  readonly id = input.required<string>();

  readonly game = signal<GameDetails | null>(null);
  readonly error = signal<string | null>(null);
  readonly loading = signal<boolean>(true);

    ngOnInit(): void {
         this.gamesService.getGameDetails(this.id()).subscribe({
           next: (game: GameDetails) => {
           this.game.set(game);
         },
         error: (error) => {
           this.error.set(error.message);
         },
  
         complete: () => {
           this.loading.set(false);
         }
       });
    }
}
