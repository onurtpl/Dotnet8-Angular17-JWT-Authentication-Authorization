import { Component, effect, inject, Injector, OnInit } from '@angular/core';

import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';
import { AppCommonModule } from '../../modules/app-common/app-common.module';
import { AuthService } from '../../../layouts/auth/services/auth.service';
import { Router } from '@angular/router';
import { DropdownDirective } from '../../directives/dropdown.directive';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [
    AppCommonModule,
    MatMenuModule,
    MatButtonModule,
    DropdownDirective
  ],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss'
})
export class NavbarComponent implements OnInit {

  authService = inject(AuthService);
  router = inject(Router);
  injector = inject(Injector);
  isLoggedIn = false;

  ngOnInit(): void {
    effect(() => {
      this.isLoggedIn  = this.authService.isAuthenticated();
    }, {injector: this.injector});
  }
  
  logout = () => {
    this.authService.logout();
    this.router.navigate(['/']);
    this.isLoggedIn = false;
  }


  loggedIn() {
    return true;
  }
  get fullName(): string {
    return this.authService.getUserDetail()?.fullname as string;
  }
}
