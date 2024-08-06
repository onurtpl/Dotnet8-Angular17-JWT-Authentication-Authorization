import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { FormControl, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-reactive-text-input',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './reactive-text-input.component.html',
  styleUrl: './reactive-text-input.component.scss'
})
export class ReactiveTextInputComponent {
  @Input() control?: FormControl;
  @Input() id!: string;
  @Input() type: string = 'text';
  @Input() placeholder!: string;
  @Input() labelText!: string;
}
