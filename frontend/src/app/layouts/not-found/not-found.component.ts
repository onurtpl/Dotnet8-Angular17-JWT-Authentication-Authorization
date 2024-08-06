import { Component } from '@angular/core';
import { AppCommonModule } from '../../common/modules/app-common/app-common.module';

@Component({
  selector: 'app-not-found',
  standalone: true,
  imports: [AppCommonModule],
  templateUrl: './not-found.component.html',
  styleUrl: './not-found.component.scss'
})
export class NotFoundComponent {

}
