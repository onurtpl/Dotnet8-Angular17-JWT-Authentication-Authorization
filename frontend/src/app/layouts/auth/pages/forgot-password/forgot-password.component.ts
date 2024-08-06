import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MaterialFormSharedModule } from '../../../../common/modules/material-form-shared/material-form-shared.module';
import { ForgotPasswordRequest } from '../../interfaces/forgot-password-request';
import { AuthService } from '../../services/auth.service';
import { AppCommonModule } from '../../../../common/modules/app-common/app-common.module';
import { NotificationService } from '../../../../common/services/notification.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-forgot-password',
  standalone: true,
  imports: [
    MaterialFormSharedModule,
    AppCommonModule
  ],
  templateUrl: './forgot-password.component.html',
  styleUrl: './forgot-password.component.scss'
})
export class ForgotPasswordComponent {
  forgotPasswordForm!: FormGroup;
  private authService = inject(AuthService);
  private notifyService = inject(NotificationService);
  private router = inject(Router);

  constructor(private fb: FormBuilder) { }

  ngOnInit(): void {
    this.forgotPasswordForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]]
    });
  }

  onSubmit(): void {
    if (this.forgotPasswordForm.valid) {
      const data: ForgotPasswordRequest = this.forgotPasswordForm.value;
      // console.log('Reset password email sent to:', data.email);
      // Implement actual password reset logic here
      this.authService.forgotPassword(data).subscribe((response) => {
        if(response) {
          this.notifyService.notify('The reset-password link has been sent to your e-mail address. Please check your e-mails.');
          this.router.navigate(['/']);
        }
      });
    }
  }
}
