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
  eGender = Gender;

  form!: FormGroup;

  // readonly genders = signal<Gender[]>([]);
  // readonly drugs = signal<DrugType[]>([]);
  // readonly consumptionFrequencies = signal<ConsumptionFrequency[]>([]);
  // readonly residenceStatus = signal<ResidenceStatus[]>([]);

  genderList = Object.values(Gender);
  drugList = Object.values(DrugType);
  consumptionFrequenciesList = Object.values(ConsumptionFrequency);
  statusList = Object.values(ResidenceStatus);

  selectedGender: any = null;
  selectedDrug: any = null;
  selectedFrequency: any = null;
  selectedStatus: any = null;

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

    this.patientsService.create(this.form.getRawValue()).subscribe({
      next: () => this.router.navigate(["dashboard"]),
      error: (err) => console.log("Erreur: ", err)
    })
  }
}
