import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private snackBar: MatSnackBar) { }

  // Method to display a notification
  public notify(message: string, action: string = 'OK', config?: any): void {
    const defaultConfig = {
      
      horizontalPosition: 'right',
      verticalPosition: 'bottom',
      ...config
    };
    this.snackBar.open(message, action, defaultConfig);
  }
}
