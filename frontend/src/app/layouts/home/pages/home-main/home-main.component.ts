import { Component } from '@angular/core';
import { ImageHoverCardComponent } from '../../../../common/components/image-hover-card/image-hover-card.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-home-main',
  standalone: true,
  imports: [
    CommonModule,
    ImageHoverCardComponent],
  templateUrl: './home-main.component.html',
  styleUrl: './home-main.component.scss'
})
export class HomeMainComponent {

}
