import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../../layouts/auth/services/auth.service';
import { NotificationService } from '../services/notification.service';

export const roleGuard: CanActivateFn = (route, state) => {

  const roles = route.data["roles"] as string[];
  const authService = inject(AuthService);
  const notifySrv = inject(NotificationService);
  const router = inject(Router);

  if (!authService.isAuthenticated()) {
    router.navigate(['/login']);
    notifySrv.notify('You must be logged in to view this page ', 'OK', {
      duration: 3000,
      horizontalPosition: 'center'
    });
    return false;
  }

  const userRoles = authService.getRoles();
  console.log(`user roles: ${userRoles}`);
  if(roles.some((role) => userRoles?.includes(role))) return true;
  router.navigate(['/']);
    notifySrv.notify('You do not have permission top view this page.', 'OK', {
      duration: 3000,
      horizontalPosition: 'center'
    });
    return false;
};