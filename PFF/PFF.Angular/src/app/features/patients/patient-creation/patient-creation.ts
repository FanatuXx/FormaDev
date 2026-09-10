import { Component, inject } from '@angular/core';
import { PatientsService } from '../../../core/services/patients.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

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
      birthDate: [''],
      phoneNumber: [''],
      allergies: [''],
      isInsured: [''],
      insurance: [''],
      insuranceEndDate: [''],
      hasInsuranceCard: [''],
      insuranceCardEndDate: [''],
      isAtFedasil: [''],
      income: [''],
      status: [''],
      isWorking: [''],
      drugType: [''],
      consumptionFrequency: ['']
  })
}
