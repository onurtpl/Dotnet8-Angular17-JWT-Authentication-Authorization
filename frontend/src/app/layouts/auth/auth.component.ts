import { Component } from '@angular/core';
import { AppCommonModule } from '../../common/modules/app-common/app-common.module';
import { NavbarComponent } from '../../common/components/navbar/navbar.component';

@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [AppCommonModule, NavbarComponent],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.scss'
})
export class AuthComponent {

}
