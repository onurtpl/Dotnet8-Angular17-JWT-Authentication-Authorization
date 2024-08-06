import { Component } from '@angular/core';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatCardModule} from '@angular/material/card';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-image-hover-card',
  standalone: true,
  imports: [
    CommonModule,
    MatGridListModule,
    MatCardModule
  ],
  templateUrl: './image-hover-card.component.html',
  styleUrl: './image-hover-card.component.scss'
})
export class ImageHoverCardComponent {
  cards: {title: string; content: string; image: string;
  }[] = [
    { title: 'PAKETLEME', content: 'Details about PAKETLEME', image: 'assets/images/kodlama.png' },
    { title: 'KODLAMA', content: 'Details about KODLAMA', image: 'assets/images/kodlama.png' },
    { title: 'ETIKETLEME', content: 'Details about ETIKETLEME', image: 'assets/images/kodlama.png' },
    { title: 'AR-GE', content: 'Details about AR-GE', image: 'assets/images/kodlama.png' }
  ];


}
