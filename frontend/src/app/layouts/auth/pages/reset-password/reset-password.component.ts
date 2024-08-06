import { Component, inject, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AppCommonModule } from '../../../../common/modules/app-common/app-common.module';
import { MaterialFormSharedModule } from '../../../../common/modules/material-form-shared/material-form-shared.module';
import { TogglePasswordDirective } from '../../../../common/directives/toggle-password.directive';
import { ResetPasswordRequest } from '../../interfaces/reset-password-request';
import { NotificationService } from '../../../../common/services/notification.service';

@Component({
  selector: 'app-reset-password',
  standalone: true,
  imports: [
    AppCommonModule,
    MaterialFormSharedModule,
    TogglePasswordDirective,
  ],
  templateUrl: './reset-password.component.html',
  styleUrl: './reset-password.component.scss'
})
export class ResetPasswordComponent implements OnInit {

  authService = inject(AuthService);
  router = inject(Router);
  route = inject(ActivatedRoute);
  notificationService = inject(NotificationService);
  private fb = inject(FormBuilder);

  resetPasswordForm!: FormGroup;

  email: string = '';
  token: string = '';

  ngOnInit(): void {
    this.resetPasswordForm = this.fb.group({
      newPassword: ['', Validators.required],
      confirmPassword: ['', Validators.required]
    }, { validator: this.passwordMatchValidator });

    this.route.queryParams.subscribe((params) => {
      this.email = params['email'];
      this.token = params['token'];
    });
    console.log({email: this.email, token: this.token});
  }

  onSubmit(): void {
    if(this.resetPasswordForm.valid) {
      const newPass = this.resetPasswordForm.value.newPassword;
      let data = {
        email: this.email,
        token: this.token,
        newPassword: newPass
      } as ResetPasswordRequest;

      this.authService.resetPassword(data).subscribe((response) => {
        if(response)
        {
          this.notificationService.notify('Password is reset', 'OK', {duration: 3000});
          this.router.navigate(['/auth/login'])
        }

      })
    }
  }

  get passwordControl(): FormControl {
    return this.resetPasswordForm.get('newPassword') as FormControl;
  }
  get confirmPasswordControl(): FormControl {
    return this.resetPasswordForm.get('confirmPassword') as FormControl;
  }


  passwordMatchValidator(form: AbstractControl) {
    const password = form.get('newPassword')?.value;
    const confirmPassword = form.get('confirmPassword')?.value;
    if (password !== confirmPassword) {
      form.get('confirmPassword')?.setErrors({ passwordMismatch: true });
    } else {
      form.get('confirmPassword')?.setErrors(null);
    }
  }


}
