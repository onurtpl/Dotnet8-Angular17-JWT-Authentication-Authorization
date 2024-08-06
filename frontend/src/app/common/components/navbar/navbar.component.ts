import { Component, inject } from '@angular/core';

import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { AppCommonModule } from '../../modules/app-common/app-common.module';
import { AuthService } from '../../../layouts/auth/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [
    AppCommonModule,
    MatMenuModule,
    MatButtonModule
  ],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent {
  authService = inject(AuthService);
  router = inject(Router);
  logout = () => {
    this.authService.logout();
    this.router.navigate(['/']);
  }

  get fullName(): string {
    return this.authService.getUserDetail()?.fullname as string;
  }
}
