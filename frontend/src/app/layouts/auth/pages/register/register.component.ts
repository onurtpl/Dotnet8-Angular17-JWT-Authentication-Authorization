import { AuthService } from './../../services/auth.service';
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MaterialFormSharedModule } from '../../../../common/modules/material-form-shared/material-form-shared.module';
import { RegisterRequest } from '../../interfaces/register-request';
import { AppCommonModule } from '../../../../common/modules/app-common/app-common.module';
import { TogglePasswordDirective } from '../../../../common/directives/toggle-password.directive';
import { ReactiveTextInputComponent } from '../../../../common/components/reactive-text-input/reactive-text-input.component';
import { Router } from '@angular/router';
@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    AppCommonModule,
    MaterialFormSharedModule,
    TogglePasswordDirective,
    ReactiveTextInputComponent
  ],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})

export class RegisterComponent implements OnInit {
  registerForm!: FormGroup;
  private authService = inject(AuthService);
  private router = inject(Router);

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.registerForm = this.fb.group({
      userName: ['', [Validators.required]],
      name: ['', [Validators.required]],
      surName: ['', [Validators.required]],
      phoneNumber: ['', [Validators.required, /*Validators.pattern('^\\+?[1-9]\\d{1,14}$') */]],
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(6)]]
    });
  }

  

  onSubmit(): void {
    
    if (this.registerForm.valid) {
      const request: RegisterRequest = this.registerForm.value;
      this.authService.register(request).subscribe((response) => {
        if(response)
          this.router.navigate(['/auth/login']);
      });
    } 
  }

  get userNameControl(): FormControl {
    return this.registerForm.get('userName') as FormControl;
  }
  get nameControl(): FormControl {
    return this.registerForm.get('name') as FormControl;
  }
  get surNameControl(): FormControl {
    return this.registerForm.get('surName') as FormControl;
  }
  get phoneNumberControl(): FormControl {
    return this.registerForm.get('phoneNumber') as FormControl;
  }
  get emailControl(): FormControl {
    return this.registerForm.get('email') as FormControl;
  }
  get passwordControl(): FormControl {
    return this.registerForm.get('password') as FormControl;
  }

}
