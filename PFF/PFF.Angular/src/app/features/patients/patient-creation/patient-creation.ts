import { Component, inject } from '@angular/core';
import { PatientsService } from '../../../core/services/patients.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { legalAgeValidator } from '../../../shared/validators/legal-age.validator';
import { CreatePatientRequest } from '../../../shared/models/patient.model';

@Component({
  selector: 'app-patient-creation',
  imports: [],
  templateUrl: './patient-creation.html',
  styleUrl: './patient-creation.css',
})
export class PatientCreation {
  private readonly patientsService = inject(PatientsService);
  private readonly router = inject(Router);

  readonly form: FormGroup = inject(FormBuilder).group({
      ssin: ['', [Validators.minLength(11), Validators.maxLength(15)]],
      idNumber: ['', [Validators.minLength(12), Validators.maxLength(14)]],
      firstName: [''],
      lastName: [''],
      alias: [''],
      gender: [''],
      birthDate: ['', legalAgeValidator()],
      phoneNumber: ['', [Validators.minLength(9), Validators.maxLength(16)]],
      allergies: [''],
      isInsured: [''],
      insurance: ['', [Validators.minLength(2), Validators.maxLength(50)]],
      insuranceEndDate: [''],
      hasInsuranceCard: [''],
      insuranceCardEndDate: [''],
      isAtFedasil: [''],
      income: ['', [Validators.min(0)]],
      status: [''],
      isWorking: [''],
      drugType: [''],
      consumptionFrequency: ['']
  });

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
    return this.form.controls['isInsured'];
  }
  
  get insurance() {
    return this.form.controls['insurance'];
  }
  
  get insuranceEndDate() {
    return this.form.controls['insuranceEndDate'];
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
    if (this.form.invalid) {
      return;
    }

    const credentials: CreatePatientRequest = this.form.value;

    this.patientsService.createPatient(credentials).subscribe({
      next: () => {
        this.patientsService
          .createPatient({ 
            ssin: credentials.ssin,
            idNumber: credentials.idNumber,
            firstName: credentials.firstName,
            lastName: credentials.lastName,
            alias: credentials.alias,
            gender: credentials.gender,
            birthDate: credentials.birthDate,
            phoneNumber: credentials.phoneNumber,
            allergies: credentials.allergies,
            isInsured: credentials.isInsured,
            insurance: credentials.insurance,
            insuranceEndDate: credentials.insuranceEndDate,
            hasInsuranceCard: credentials.hasInsuranceCard,
            insuranceCardEndDate: credentials.insuranceCardEndDate,
            isAtFedasil: credentials.isAtFedasil,
            income: credentials.income,
            status: credentials.status,
            isWorking: credentials.isWorking,
            drugType: credentials.drugType,
            consumptionFrequency: credentials.consumptionFrequency })
          .subscribe({
            next: () => this.router.navigate(['patients']),
            error: (err) => console.log('Erreur: ', err),
          });
      },
      error: (err) => {
        console.log('Erreur: ', err);
      },
    });
  }
}
