import {  Router } from '@angular/router';
import { AuthService } from './../../services/auth.service';
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';

import { MaterialFormSharedModule } from '../../../../common/modules/material-form-shared/material-form-shared.module';
import { LoginRequest } from '../../interfaces/login-request';
import { AppCommonModule } from '../../../../common/modules/app-common/app-common.module';
import { TogglePasswordDirective } from '../../../../common/directives/toggle-password.directive';
import { JwtPayload } from '../../../../common/interfaces/jwt-payload';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [
    AppCommonModule,
    MaterialFormSharedModule,
    TogglePasswordDirective,
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements OnInit {
  private router = inject(Router);
  private authService: AuthService = inject(AuthService);
  private fb = inject(FormBuilder);

  loginForm!: FormGroup;
  
  ngOnInit(): void {
   this.loginForm = this.fb.group({
      user: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit(): void {
    // this.notifyService.notify('Action successful', 'Undo');
    if (this.loginForm.valid) {
      const credentials: LoginRequest = this.loginForm.value;
      console.log('Login Data:', credentials);
      // Here, integrate with your backend or authentication service
      this.authService.login(credentials).subscribe( (response: JwtPayload) => {
        // console.log(response);
        this.router.navigate(['/']);
      })

    }
  }

  

  get userControl(): FormControl {
    return this.loginForm.get('user') as FormControl;
  }
  
  get passwordControl(): FormControl {
    return this.loginForm.get('password') as FormControl;
  }

}
