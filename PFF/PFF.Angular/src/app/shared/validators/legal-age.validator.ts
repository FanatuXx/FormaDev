import { AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';

export function legalAgeValidator(birthKey: string): ValidatorFn 
{
  return (control: AbstractControl): ValidationErrors | null => {
    const group = control as any;
    const now = new Date();
    const birthDate = group.get(birthKey)?.value;

    if (now.getFullYear() - new Date(birthDate).getFullYear() < 18)
      return { underEighteen: true };
    
    return null;
  };
}