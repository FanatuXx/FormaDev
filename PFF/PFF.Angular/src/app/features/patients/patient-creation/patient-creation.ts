import { Component, inject, OnInit, signal } from '@angular/core';
import { PatientsService } from '../../../core/services/patients.service';
import { Router, RouterLink } from '@angular/router';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { legalAgeValidator } from '../../../shared/validators/legal-age.validator';
import { Gender } from '../../../shared/enum/gender.enum';
import { DrugType } from '../../../shared/enum/drug-type.enum';
import { ConsumptionFrequency } from '../../../shared/enum/consumption-frequency.enum';
import { ResidenceStatus } from '../../../shared/enum/residence-status.enum';

@Component({
  selector: 'app-patient-creation',
  imports: [RouterLink, ReactiveFormsModule],
  templateUrl: './patient-creation.html',
  styleUrl: './patient-creation.css',
})

export class PatientCreation implements OnInit {

  private readonly patientsService: PatientsService = inject(PatientsService);
  private readonly formBuilder: FormBuilder = inject(FormBuilder);
  private readonly router = inject(Router);

  genderOptions = Object.entries(Gender).map(([value, label]) => ({
  value,
  label
  }));

  statusOptions = Object.entries(ResidenceStatus).map(([value, label]) => ({
  value,
  label
  }));

  drugOptions = Object.entries(DrugType).map(([value, label]) => ({
  value,
  label
  }));

  consumptionFrequencyOptions = Object.entries(ConsumptionFrequency).map(([value, label]) => ({
  value,
  label
  }));

  form!: FormGroup;

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      ssin: ['', [Validators.minLength(11), Validators.maxLength(15)]],
      idNumber: ['', [Validators.minLength(12), Validators.maxLength(14)]],
      firstName: [''],
      lastName: [''],
      alias: [''],
      gender: [''],
      birthDate: ['', legalAgeValidator],
      phoneNumber: ['', [Validators.minLength(9), Validators.maxLength(16)]],
      allergies: [''],
      isInsured: [''],
      insurance: ['', [Validators.minLength(2), Validators.maxLength(50)]],
      hasInsuranceCard: [''],
      insuranceCardEndDate: [''],
      isAtFedasil: [''],
      income: ['', [Validators.min(0)]],
      status: [''],
      isWorking: [''],
      drugType: [''],
      consumptionFrequency: ['']
    });
  };

  get ssin() {
    return this.form.controls['ssin'];
  };
  
  get idNumber() {
    return this.form.controls['idNumber'];
  }
  
  get firstName() {
    return this.form.controls['firstName'];
  }
  
  get lastName() {
    return this.form.controls['lastName'];
  }
  
  get alias() {
    return this.form.controls['alias'];
  }
  
  get gender() {
    return this.form.controls['gender'];
  }
  
  get birthDate() {
    return this.form.controls['birthDate'];
  }
  
  get phoneNumber() {
    return this.form.controls['phoneNumber'];
  }
  
  get allergies() {
    return this.form.controls['allergies'];
  }
  
  get isInsured() {
    if (this.isInsured?.valueOf() == "true") {
      return true;
    }

    else if (this.isInsured?.valueOf() == "false") {
      return false;
    }

    else {
      return null; 
    }
    return this.form.controls['isInsured'];
  }
  
  get insurance() {
    return this.form.controls['insurance'];
  }
  
  get hasInsuranceCard() {
    return this.form.controls['hasInsuranceCard'];
  }
  
  get insuranceCardEndDate() {
    return this.form.controls['insuranceCardEndDate'];
  }
  
  
  get isAtFedasil() {
    return this.form.controls['isAtFedasil'];
  }
  
  get income() {
    return this.form.controls['income'];
  }
  
  get status() {
    return this.form.controls['status'];
  }
  
  get isWorking() {
    return this.form.controls['isWorking'];
  }
  
  get drugType() {
    return this.form.controls['drugType'];
  }

  get consumptionFrequency() {
    return this.form.controls['consumptionFrequency'];
  }

  onSubmit() {
  console.log('Submit appelé');
  console.log('Formulaire valide ?', this.form.valid);
  console.log('Formulaire invalide ?', this.form.invalid);
  console.log('Valeurs :', this.form.getRawValue());
  console.log('Erreurs :', this.form.errors);
  console.log('Erreur naissance :', this.form.controls['birthDate'].errors);

  if (this.form.invalid) {
    this.form.markAllAsTouched();

    Object.keys(this.form.controls).forEach(key => {
      const control = this.form.get(key);

      if (control?.invalid) {
        console.log(`Erreur sur ${key}:`, control.errors);
      }
    });

    return;
  }

  this.patientsService.create(this.form.getRawValue()).subscribe({
    next: () => {
      console.log('Patient créé');
      this.router.navigate(['/dashboard']);
    },
    error: (err) => {
      console.error('Erreur API :', err);
    }
  });
}

  // onSubmit() {
  //   if (this.form.invalid) {
  //     return;
  //   }

  //   this.patientsService.create(this.form.getRawValue()).subscribe({
  //     next: () => this.router.navigate(["dashboard"]),
  //     error: (err) => console.log("Erreur: ", err)
  //   })
  // }
}
