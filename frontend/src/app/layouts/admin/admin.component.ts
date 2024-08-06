import { Component } from '@angular/core';
import { AppCommonModule } from '../../common/modules/app-common/app-common.module';

@Component({
  selector: 'app-admin',
  standalone: true,
  imports: [AppCommonModule],
  templateUrl: './admin.component.html',
  styleUrl: './admin.component.scss'
})
export class AdminComponent {

}
