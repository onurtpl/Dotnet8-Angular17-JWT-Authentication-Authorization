import { NavbarComponent } from '../../common/components/navbar/navbar.component';
import { Component } from '@angular/core';
import { AppCommonModule } from '../../common/modules/app-common/app-common.module';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    NavbarComponent,
    AppCommonModule, 
  ],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {

}
