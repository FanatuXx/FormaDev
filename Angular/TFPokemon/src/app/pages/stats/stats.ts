import { Component, computed, inject } from '@angular/core';
import { Loader } from '../../components/loader/loader';
import { AppService } from '../../services/app-service';
import { BaseChartDirective } from 'ng2-charts';
import { ChartConfiguration, ChartData, ChartEvent, ChartType } from 'chart.js';

@Component({
  selector: 'app-stats',
  standalone: true,
  imports: [Loader, BaseChartDirective],
  templateUrl: './stats.html',
  styleUrl: './stats.css',
})

export class Stats {
  appService = inject(AppService);


  pokemon = this.appService.selectedPokemon


  protected barChartData = computed(() => {
    const pokemon = this.pokemon();
    return {
        labels: ['HP', 'Attaque', 'Defense', 'Attaque Spe.', 'Defense Spe.', 'Vitesse'],
      datasets: [
        { 
          // data: [
          //   pokemon!.stats[0].base_stat, 
          //   pokemon!.stats[1].base_stat,
          //   pokemon!.stats[2].base_stat,
          //   pokemon!.stats[3].base_stat,
          //   pokemon!.stats[4].base_stat,
          //   pokemon!.stats[5].base_stat
          // ],
          data: pokemon.stats.slice(0,5).map((it: any) => it.base_stat),
          label : (pokemon!.name).toUpperCase()
        },
      ]
    }
  })

  
  public barChartType: ChartType = 'radar';
  
 
  public barChartOptions: ChartConfiguration['options'] = {
    responsive: true,
  };
}

  // barChartData = computed<ChartData>(() => ({
  //   labels: this.appService.pokemon.value()?.stats.map(s => s.stat.name),
  //   datasets: [{ 
  //     label: this.appService.pokemonName(),
  //     data: this.appService.pokemon.value()?.stats.map(s => s.base_stat) ?? []
  //   }] 
  // }));