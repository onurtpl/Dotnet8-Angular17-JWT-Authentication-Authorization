import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';
import {  MatSnackBarModule } from '@angular/material/snack-bar'



@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    MatSnackBarModule,
    
    // HttpClientModule,
    RouterOutlet,
    RouterLink
  ],
  exports: [
    CommonModule,
    // HttpClientModule,
    MatSnackBarModule,
    RouterOutlet,
    RouterLink
  ]
})
export class AppCommonModule { }
