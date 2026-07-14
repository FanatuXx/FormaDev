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

  barChartData = computed<ChartData>(() => ({
    labels: this.appService.pokemon.value()?.stats.map(s => s.stat.name),
    datasets: [{ 
      label: this.appService.pokemonName(),
      data: this.appService.pokemon.value()?.stats.map(s => s.base_stat) ?? []
    }] 
  }));

  // public barChartType: ChartType = 'radar';

  // public barChartData: ChartData<'radar'> = {
  //   labels: ['HP', 'Attaque', 'Defense', 'Attaque Spe.', 'Defense Spe.', 'Vitesse'],
  //   datasets: [
  //     { data: [this.appService.pokemon.value()!.stats[0].base_stat, 
  //       this.appService.pokemon.value()!.stats[1].base_stat,
  //       this.appService.pokemon.value()!.stats[2].base_stat,
  //       this.appService.pokemon.value()!.stats[3].base_stat,
  //       this.appService.pokemon.value()!.stats[4].base_stat,
  //       this.appService.pokemon.value()!.stats[5].base_stat],
  //       label : (this.appService.pokemon.value()!.name).toUpperCase()},
  //   ]
  // };

  // public barChartOptions: ChartConfiguration['options'] = {
  //   responsive: true,
  // };
}
