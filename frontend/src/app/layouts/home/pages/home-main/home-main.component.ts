import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomCardComponent } from '../../../../common/components/custom-card/custom-card.component';
import { CustomCardModel } from '../../../../common/models/custom-card-model';

@Component({
  selector: 'app-home-main',
  standalone: true,
  imports: [
    CommonModule,
    CustomCardComponent
  ],
  templateUrl: './home-main.component.html',
  styleUrl: './home-main.component.scss'
})
export class HomeMainComponent {
   cards: CustomCardModel[] = [ 
    { title: 'Title 01', content:"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", imgSrc: 'https://cdn.pixabay.com/photo/2018/03/30/15/11/deer-3275594_960_720.jpg', link: '/go-to-link'},
    { title: 'Title 02', content:"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", imgSrc: 'https://cdn.pixabay.com/photo/2018/03/30/15/11/deer-3275594_960_720.jpg', link: '/go-to-link'},
    { title: 'Title 03', content:"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", imgSrc: 'https://cdn.pixabay.com/photo/2018/03/30/15/11/deer-3275594_960_720.jpg', link: '/go-to-link'},
    { title: 'Title 04', content:"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", imgSrc: 'https://cdn.pixabay.com/photo/2018/03/30/15/11/deer-3275594_960_720.jpg', link: '/go-to-link'},
    { title: 'Title 05', content:"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", imgSrc: 'https://cdn.pixabay.com/photo/2018/04/09/19/55/low-poly-3305284_960_720.jpg', link: '/go-to-link'},
    { title: 'Title 06', content:"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", imgSrc: 'https://cdn.pixabay.com/photo/2018/04/09/19/55/low-poly-3305284_960_720.jpg', link: '/go-to-link'},
    { title: 'Title 07', content:"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", imgSrc: 'https://cdn.pixabay.com/photo/2018/04/09/19/55/low-poly-3305284_960_720.jpg', link: '/go-to-link'},
    { title: 'Title 08', content:"Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", imgSrc: 'https://cdn.pixabay.com/photo/2018/04/09/19/55/low-poly-3305284_960_720.jpg', link: '/go-to-link'},
  ]
}
