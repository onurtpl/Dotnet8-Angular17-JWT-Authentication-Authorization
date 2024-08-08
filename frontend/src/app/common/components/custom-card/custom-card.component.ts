import { CustomCardModel } from './../../models/custom-card-model';
import { Component, Input } from '@angular/core';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-custom-card',
  standalone: true,
  imports: [
    RouterLink
  ],
  templateUrl: './custom-card.component.html',
  styleUrl: './custom-card.component.scss'
})
export class CustomCardComponent {
  @Input() data!: CustomCardModel[]
  // https://cdn.pixabay.com/photo/2018/03/30/15/11/deer-3275594_960_720.jpg
}
