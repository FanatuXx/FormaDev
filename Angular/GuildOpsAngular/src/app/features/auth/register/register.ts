import { Component, inject } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { passwordStrength } from '../../../shared/validators/password-strength.validator';

@Component({
  imports: [RouterLink, ReactiveFormsModule],
  selector: 'app-register',
  styleUrl: './register.css',
  templateUrl: './register.html',
})
export class Register {

  readonly form: FormGroup = inject(FormBuilder).nonNullable.group({
    accountName: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(256)]],
    email: ['', [Validators.required, Validators.email, Validators.maxLength(256), passwordStrength]],
    password: ['null', [Validators.required, Validators.minLength(8), Validators.maxLength(128)]],
  });


  get accountName() {
    return this.form.controls['accountName'];
  }

    get password() {
    return this.form.controls['password'];
  }

}
