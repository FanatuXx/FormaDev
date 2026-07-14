import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'convert_to'
})

export class ConvertToPipe implements PipeTransform {
    transform(value: number, multiplicateur: number, unit: string) {
        return (value * multiplicateur).toFixed(2) + unit;
    }
}